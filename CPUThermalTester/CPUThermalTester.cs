using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OpenHardwareMonitor.Hardware;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CPUThermalTester
{
    public partial class CPUThermalTester : Form
    {
        const int N = 1 << 15;
        const int M = 1 << 2;

        System.Windows.Forms.Timer Timer = new System.Windows.Forms.Timer();
        public class IntRef
        {
            public int content = 0;
            public IntRef(int init)
            {
                content = init;
            }
        }
        List<(IntRef, Thread)> Heaters = new List<(IntRef, Thread)>();
        List<int> LatestCounterValues = new List<int>();
        Int64 LatestTimestamp = Stopwatch.GetTimestamp();
        double LatestRate = 0.0;
        List<double> RateSamples = new List<double>();

        public class Data
        {
            public readonly int HeaterThreadCount;
            public readonly double Power;
            public readonly double Temp;
            public readonly int MFLOPS;
            
            public Data(int heaterThreadCount, double power, double temp, int mflops)
            {
                HeaterThreadCount = heaterThreadCount;
                Power = power;
                Temp = temp;
                MFLOPS = mflops;
            }
        }

        Data[] Curve = new Data[] { };
        Data[] LatestDrawnCurve = new Data[] { };
        Computer Computer = new Computer();

        (int, int)[] Script = new(int, int)[] { };
        int? PC = null;
        DateTime StepStart = DateTime.MinValue;
        Tuple<(int, int)[], int?> LatestDrawnScript = Tuple.Create<(int, int)[], int?>(new(int, int)[] { }, null);

        float? LatestPower = null;
        float? LatestTemp = null;

        const int SampleCount = 40; // 10sec
        List<float> PackagePowerSamples = new List<float>();
        List<float> TemperatureSamples = new List<float>();

        List<(string, PointD[])> RefData = new List<(string, PointD[])>();

        bool IsOpeningModalDialog = false;

        public CPUThermalTester()
        {
            InitializeComponent();

            blankControl_Plot.Paint += Plot_Paint;
            Timer.Tick += Tick;

            Computer.CPUEnabled = true;
            Computer.Open();


            Timer.Interval = 250;
            Timer.Enabled = true;

            var script = new List<(int, int)>();
            var processorCount = Environment.ProcessorCount;
            for (var i = 0; i <= processorCount; i++)
            {
                script.Add((i, 120));
            }
            Script = script.ToArray();

            comboBox_Xmax.SelectedIndex = 3; // this triggers Upd()
        }

        public (float?, float?) Computer_Read()
        {
            var cpu = Computer.Hardware.FirstOrDefault();
            if (cpu == null)
            {
                return (null, null);
            }

            cpu.Update();

            float? power = null;
            var powers = cpu.Sensors.Where(sensor => sensor.SensorType == SensorType.Power).ToArray();
            if (powers.Length == 0)
            {
                // give up
            }
            else if (powers.Length == 1)
            {
                power = powers[0].Value;
            }
            else
            {
                var package_powers = powers.Where(sensor => Regex.IsMatch(sensor.Name, "Package", RegexOptions.IgnoreCase)).ToArray();
                if (package_powers.Length == 1)
                {
                    power = package_powers[0].Value;
                }
                else
                {
                    // give up
                }
            }

            float? temp = null;
            var temps = cpu.Sensors.Where(sensor => sensor.SensorType == SensorType.Temperature).ToArray();
            if (temps.Length == 0)
            {
                // give up
            }
            else if (temps.Length == 1)
            {
                temp = temps[0].Value;
            }
            else
            {
                var package_temps = temps.Where(sensor => Regex.IsMatch(sensor.Name, "Package", RegexOptions.IgnoreCase)).ToArray();
                if (package_temps.Length == 1)
                {
                    temp = package_temps[0].Value;
                }
                else
                {
                    var tdie_temps = temps.Where(sensor => Regex.IsMatch(sensor.Name, "Tdie", RegexOptions.IgnoreCase)).ToArray();
                    if (tdie_temps.Length == 1)
                    {
                        temp = tdie_temps[0].Value;
                    }
                    else
                    {
                        // give up
                    }
                }
            }

            return (power, temp);
        }

        public void Tick(object sender, EventArgs e)
        {
            if (!IsOpeningModalDialog)
            {
                if (PC.HasValue)
                {
                    var elapsed = (int)((DateTime.Now - StepStart).TotalSeconds);
                    if (elapsed >= Script[PC.Value].Item2)
                    {
                        var newCurve = new List<Data>(Curve);
                        newCurve.Add(new Data((int)numericUpDown_HeaterCount.Value, PackagePowerSamples.Average(), TemperatureSamples.Average(), (int)(RateSamples.Average() / 1e6)));
                        Curve = newCurve.ToArray();

                        if (PC.Value == Script.Length - 1)
                        {
                            PC = null;
                            numericUpDown_HeaterCount.Value = 0;
                        }
                        else
                        {
                            PC = PC.Value + 1;
                            StepStart = DateTime.Now;
                            numericUpDown_HeaterCount.Value = Script[PC.Value].Item1;
                        }
                    }
                }

                var (power, temp) = Computer_Read();
                LatestPower = power;
                LatestTemp = temp;

                if (power.HasValue)
                {
                    PackagePowerSamples.Add(power.Value);
                    if (PackagePowerSamples.Count > SampleCount)
                    {
                        PackagePowerSamples.RemoveAt(0);
                    }
                }

                if (temp.HasValue)
                {
                    TemperatureSamples.Add(temp.Value);
                    if (TemperatureSamples.Count > SampleCount)
                    {
                        TemperatureSamples.RemoveAt(0);
                    }
                }

                var timestamp = Stopwatch.GetTimestamp();
                int sum = 0;
                for (var i = 0; i < Heaters.Count; i++)
                {
                    var count = Heaters[i].Item1.content;
                    sum = sum + count - LatestCounterValues[i];
                    LatestCounterValues[i] = count;
                }
                double rate = (double)N * (double)M * (double)Stopwatch.Frequency * (double)sum / (double)(timestamp - LatestTimestamp);
                LatestTimestamp = timestamp;
                LatestRate = rate;
                RateSamples.Add(rate);
                if (RateSamples.Count > SampleCount)
                {
                    RateSamples.RemoveAt(0);
                }

                Upd();
            }
        }

        public void Upd()
        {
            numericUpDown_HeaterCount.Enabled = !PC.HasValue;

            button_Start.Enabled = PackagePowerSamples.Count == SampleCount && TemperatureSamples.Count == SampleCount && !PC.HasValue;
            button_Stop.Enabled = PC.HasValue;
            button_ScriptAdd.Enabled = !PC.HasValue;
            button_ScriptClear.Enabled = !PC.HasValue;
            button_ScriptLoad.Enabled = !PC.HasValue;

            button_Add.Enabled = PackagePowerSamples.Count == SampleCount && TemperatureSamples.Count == SampleCount && !PC.HasValue;
            button_Clear.Enabled = !PC.HasValue;

            if (PC.HasValue)
            {
                var elapsed = (int)((DateTime.Now - StepStart).TotalSeconds);
                textBox_ScriptStatus.Text = String.Format("Run step {0}, {1}/{2}", PC.Value, elapsed, Script[PC.Value].Item2);
            }
            else
            {
                textBox_ScriptStatus.Text = "Stop";
            }

            if (Curve != LatestDrawnCurve)
            {
                listView_Curve.Items.Clear();
                for (var i = 0; i < Curve.Length; i++)
                {
                    listView_Curve.Items.Add(new ListViewItem(new string[] { Curve[i].HeaterThreadCount.ToString(), Curve[i].Power.ToString("F3"), Curve[i].Temp.ToString("F3"), Curve[i].MFLOPS.ToString() }));
                }

                LatestDrawnCurve = Curve;
            }

            if (!Tuple.Create<(int, int)[], int?>(Script, PC).Equals(LatestDrawnScript))
            {
                listView_Script.Items.Clear();
                for (var i = 0; i < Script.Length; i++)
                {
                    var item = new ListViewItem(new string[] { Script[i].Item1.ToString(), Script[i].Item2.ToString() });
                    if (PC.HasValue && PC.Value == i)
                    {
                        item.BackColor = Color.LightGreen;
                    }
                    listView_Script.Items.Add(item);
                }

                LatestDrawnScript = Tuple.Create<(int, int)[], int?>(Script, PC);
            }

            textBox_Power.Text = LatestPower.HasValue ? LatestPower.Value.ToString("F3") : "N/A";
            textBox_Temp.Text = LatestTemp.HasValue ? LatestTemp.Value.ToString("F3") : "N/A";

            textBox_AveragedPower.Text = PackagePowerSamples.Count == SampleCount ? PackagePowerSamples.Average().ToString("F3") : "N/A";
            textBox_AveragedTemp.Text = TemperatureSamples.Count == SampleCount ? TemperatureSamples.Average().ToString("F3") : "N/A";

            textBox_Rate.Text = (LatestRate / 1e6).ToString("F0");
            textBox_AverageRate.Text = RateSamples.Count == SampleCount ? (RateSamples.Average() / 1e6).ToString("F0") : "N/A";

            var sb = new StringBuilder();
            if (!LatestPower.HasValue)
            {
                sb.AppendLine("Reading of processor power is not available.");
            }
            if (!LatestTemp.HasValue)
            {
                sb.AppendLine("Reading of processor temperature is not available.");
            }
            if (!(PackagePowerSamples.Count == SampleCount && TemperatureSamples.Count == SampleCount))
            {
                sb.AppendFormat("The count of sampled data is not yet sufficient for averaging ({0}/{1}).", Math.Min(PackagePowerSamples.Count, TemperatureSamples.Count), SampleCount);
            }
            if (sb.Length == 0)
            {
                sb.AppendLine("OK");
            }
            textBox_Status.Text = sb.ToString();

            blankControl_Plot.Invalidate();
        }

        public void Plot_Paint(object sender, PaintEventArgs e)
        {
            var buffer = BufferedGraphicsManager.Current.Allocate(e.Graphics, blankControl_Plot.ClientRectangle);
            var g = buffer.Graphics;

            var plotRectangle = new Rectangle(50, 10, 300, 300);

            g.FillRectangle(Brushes.Black, g.VisibleClipBounds);

            int xmax = 100;
            Int32.TryParse((string)comboBox_Xmax.SelectedItem, out xmax);
            var xrange = new RangeD(0.0, 100.0);
            var xaxis = new[] { 0.0, 20.0, 40.0, 60.0, 80.0, 100.0 };
            switch (xmax)
            {
                case 20:
                    xrange = new RangeD(0.0, 20.0);
                    xaxis = new[] { 0.0, 5.0, 10.0, 15.0, 20.0 };
                    break;
                case 50:
                    xrange = new RangeD(0.0, 50.0);
                    xaxis = new[] { 0.0, 10.0, 20.0, 30.0, 40.0, 50.0 };
                    break;
                case 200:
                    xrange = new RangeD(0.0, 200.0);
                    xaxis = new[] { 0.0, 50.0, 100.0, 150.0, 200.0 };
                    break;
                case 300:
                    xrange = new RangeD(0.0, 300.0);
                    xaxis = new[] { 0.0, 100.0, 200.0, 300.0 };
                    break;
                case 100:
                default:
                    break;
            }

            var yrange = new RangeD(0.0, 120.0);
            var yaxis = new[] { 0.0, 20.0, 40.0, 60.0, 80.0, 100.0, 120.0 };

            var points = new List<Tuple<Color, PointD[]>>();
            for (var i = 0; i < RefData.Count; i++)
            {
                points.Add(Tuple.Create(PlotTool.ChooseColor(i), RefData[i].Item2));
            }
            points.Add(Tuple.Create(Color.White, Curve.Select(data => new PointD(data.Power, data.Temp)).ToArray()));

            PointD? marker = null;
            if (PackagePowerSamples.Count == SampleCount && TemperatureSamples.Count == SampleCount)
            {
                marker = new PointD(PackagePowerSamples.Average(), TemperatureSamples.Average());
            }

            PlotTool.Plot(
                g,
                plotRectangle,
                16.0f,
                Color.Gray,
                Color.White,
                xrange,
                yrange,
                xaxis.Select(x => Tuple.Create(x, x.ToString())).ToArray(),
                yaxis.Select(x => Tuple.Create(x, x.ToString())).ToArray(),
                true,
                points.ToArray(),
                marker);

            var font = new Font("Consolas", 16.0f, GraphicsUnit.Pixel);

            float y = plotRectangle.Top;
            for (var i = 0; i < RefData.Count; i++)
            {
                var brush = new SolidBrush(PlotTool.ChooseColor(i));
                g.DrawString(RefData[i].Item1, font, brush, new PointF(plotRectangle.Left, y));
                y += 16.0f;
            }

            g.DrawString("Power (W)", font, Brushes.White, new PointF(160f, 330f));
            g.RotateTransform(-90);
            g.DrawString("Temp (C)", font, Brushes.White, new PointF(-195f, 0f));
            g.ResetTransform();
            font.Dispose();

            buffer.Render();
            buffer.Dispose();
        }

        public static void HeaterProc(object parameter)
        {
            IntRef counter = (IntRef)parameter;
            Random random = new Random(0);
            double[] a = new double[N];
            double[] b = new double[N];
            double[] c = new double[N];

            for (int i = 0; i < N; i++)
            {
                a[i] = random.NextDouble();
                b[i] = random.NextDouble();
            }

            unsafe
            {
                fixed (double* pa = a)
                fixed (double* pb = b)
                fixed (double* pc = c)
                {
                    while (true)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            for (int i = 0; i < N; i++)
                            {
                                pc[i] = pa[i] * pb[i];
                            }
                        }
                        Interlocked.Increment(ref counter.content);
                    }
                }
            }
        }

        public void Heaters_Incr()
        {
            var counter = new IntRef(0);
            var heater = new Thread(HeaterProc);
            heater.Start(counter);
            Heaters.Add((counter, heater));
            LatestCounterValues.Add(0);
        }

        public void Heaters_Decr()
        {
            if (Heaters.Count > 0)
            {
                var i = Heaters.Count - 1;
                Heaters[i].Item2.Abort();
                Heaters.RemoveAt(i);
                LatestCounterValues.RemoveAt(i);
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (PackagePowerSamples.Count == SampleCount && TemperatureSamples.Count == SampleCount)
            {
                var newCurve = new List<Data>(Curve);
                newCurve.Add(new Data(Heaters.Count, PackagePowerSamples.Average(), TemperatureSamples.Average(), (int)(RateSamples.Average() / 1e6)));
                Curve = newCurve.ToArray();
                Upd();
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Curve = new Data[] { };
            Upd();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            var csv = new List<string[]>();
            foreach (var x in Curve)
            {
                csv.Add(new[] { x.HeaterThreadCount.ToString(), x.Power.ToString("F3"), x.Temp.ToString("F3") });
            }

            IsOpeningModalDialog = true;
            CSVTools.DialogSave(this, "HeaterThreadCount,Power(W),Temp(C)", csv.ToArray());
            IsOpeningModalDialog = false;
        }

        private void numericUpDown_HeaterCount_ValueChanged(object sender, EventArgs e)
        {
            var targetCount = numericUpDown_HeaterCount.Value;

            while (Heaters.Count < targetCount)
            {
                Heaters_Incr();
            }
            while (Heaters.Count > targetCount)
            {
                Heaters_Decr();
            }

            Upd();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            while (Heaters.Count > 0)
            {
                Heaters_Decr();
            }
            Computer.Close();

            base.OnFormClosed(e);
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            if (Script.Length > 0)
            {
                PC = 0;
                StepStart = DateTime.Now;
                numericUpDown_HeaterCount.Value = Script[0].Item1;
            }
            Upd();
        }

        void Stop()
        {
            numericUpDown_HeaterCount.Value = 0;
            PC = null;
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            Stop();
            Upd();
        }

        private void button_ScriptSave_Click(object sender, EventArgs e)
        {
            var csv = new List<string[]>();
            foreach (var x in Script)
            {
                csv.Add(new[] { x.Item1.ToString(), x.Item2.ToString() });
            }

            IsOpeningModalDialog = true;
            CSVTools.DialogSave(this, "HeaterThreadCount,Wait(seconds)", csv.ToArray());
            IsOpeningModalDialog = false;
        }

        private void button_ScriptLoad_Click(object sender, EventArgs e)
        {
            Stop();

            IsOpeningModalDialog = true;
            var csv = CSVTools.DialogLoad(this);
            IsOpeningModalDialog = false;

            var newScript = new List<(int, int)>();

            foreach (var row in csv)
            {
                try
                {
                    newScript.Add((Int32.Parse(row[0]), Int32.Parse(row[1])));
                }
                catch { }
            }

            Script = newScript.ToArray();
            Upd();
        }

        private void button_ScriptAdd_Click(object sender, EventArgs e)
        {
            Stop();

            var dialog = new ScriptItemEditor();
            IsOpeningModalDialog = true;
            var result = dialog.ShowDialog();
            IsOpeningModalDialog = false;

            var newScript = new List<(int, int)>(Script);
            var heaterThreadCount = (int)dialog.HeaterThreadCount.Value;
            var wait = (int)dialog.Wait.Value;
            newScript.Add((heaterThreadCount, wait));
            Script = newScript.ToArray();

            Upd();
        }

        private void button_ScriptClear_Click(object sender, EventArgs e)
        {
            Stop();
            Script = new(int, int)[] { };
            Upd();
        }

        private void comboBox_Xmax_SelectedIndexChanged(object sender, EventArgs e)
        {
            Upd();
        }

        private void button_OpenRef_Click(object sender, EventArgs e)
        {
            IsOpeningModalDialog = true;
            var csvs = CSVTools.DialogMultiLoad(this);
            IsOpeningModalDialog = false;

            if (csvs != null)
            {
                foreach (var (path, rows) in csvs)
                {
                    var accu = new List<PointD>();
                    foreach (var row in rows)
                    {
                        try
                        {
                            var power = Double.Parse(row[1]);
                            var temp = Double.Parse(row[2]);
                            accu.Add(new PointD(power, temp));
                        }
                        catch { }
                    }

                    RefData.Add((System.IO.Path.GetFileNameWithoutExtension(path), accu.ToArray()));
                }

                Upd();
            }
        }

        private void button_ClearRef_Click(object sender, EventArgs e)
        {
            RefData.Clear();
            Upd();
        }
    }
}
