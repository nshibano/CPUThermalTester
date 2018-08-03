using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace CPUThermalTester
{
    public static class CSVTools
    {
        public static void Save(string path, string header, string[][] rows)
        {
            var f = new StreamWriter(path, false, Encoding.ASCII);

            if (header != null) f.WriteLine(header);

            foreach (var row in rows)
            {
                f.WriteLine(String.Join(",", row));
            }

            f.Close();
        }

        public static void DialogSave(IWin32Window owner, string header, string[][] rows)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "CSV file|*.csv";

            var result = dialog.ShowDialog(owner);
            if (result == DialogResult.OK)
            {
                try
                {
                    Save(dialog.FileName, header, rows);
                }
                catch (Exception exn)
                {
                    MessageBox.Show(exn.Message);
                }
            }

            dialog.Dispose();
        }

        public static string[][] Load(string path)
        {
            var f = new StreamReader(path, Encoding.ASCII);
            var accu = new List<string[]>();

            try
            {
                var line = f.ReadLine();
                while (line != null)
                {
                    string[] cols = null;
                    try
                    {
                        cols = line.Split(',').ToArray();
                    }
                    catch { }
                    if (cols != null) accu.Add(cols);

                    line = f.ReadLine();
                }
            }
            finally
            {
                f.Close();
            }

            return accu.ToArray();
        }

        public static string[][] DialogLoad(IWin32Window owner)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "CSV file|*.csv";

            string[][] rows = null;

            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                try
                {
                    rows = CSVTools.Load(dialog.FileName);
                }
                catch (Exception exn)
                {
                    MessageBox.Show(exn.Message);
                }
            }

            dialog.Dispose();

            return rows;
        }

        public static Tuple<string, string[][]>[] DialogMultiLoad(IWin32Window owner)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "CSV file|*.csv";
            dialog.Multiselect = true;

            Tuple<string, string[][]>[] sheets = null;

            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                try
                {
                    sheets = dialog.FileNames.Select(path => Tuple.Create(path, CSVTools.Load(path))).ToArray();
                }
                catch (Exception exn)
                {
                    MessageBox.Show(exn.Message);
                }
            }

            dialog.Dispose();

            return sheets;
        }
    }
}
