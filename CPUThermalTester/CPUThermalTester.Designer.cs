namespace CPUThermalTester
{
    partial class CPUThermalTester
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_Script = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_Curve = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Power = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_AveragedPower = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Temp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_AveragedTemp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.numericUpDown_HeaterCount = new System.Windows.Forms.NumericUpDown();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_ScriptStatus = new System.Windows.Forms.TextBox();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_ScriptSave = new System.Windows.Forms.Button();
            this.button_ScriptLoad = new System.Windows.Forms.Button();
            this.button_ScriptAdd = new System.Windows.Forms.Button();
            this.button_ScriptClear = new System.Windows.Forms.Button();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.comboBox_Xmax = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_OpenRef = new System.Windows.Forms.Button();
            this.button_ClearRef = new System.Windows.Forms.Button();
            this.textBox_Rate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.blankControl_Plot = new CPUCoolerTester.BlankControl();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_AverageRate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HeaterCount)).BeginInit();
            this.SuspendLayout();
            // 
            // listView_Script
            // 
            this.listView_Script.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_Script.Location = new System.Drawing.Point(236, 12);
            this.listView_Script.Name = "listView_Script";
            this.listView_Script.Size = new System.Drawing.Size(177, 238);
            this.listView_Script.TabIndex = 0;
            this.listView_Script.UseCompatibleStateImageBehavior = false;
            this.listView_Script.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Heater count";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Wait";
            this.columnHeader2.Width = 70;
            // 
            // listView_Curve
            // 
            this.listView_Curve.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView_Curve.Location = new System.Drawing.Point(419, 12);
            this.listView_Curve.Name = "listView_Curve";
            this.listView_Curve.Size = new System.Drawing.Size(279, 263);
            this.listView_Curve.TabIndex = 0;
            this.listView_Curve.UseCompatibleStateImageBehavior = false;
            this.listView_Curve.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Heater count";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Power";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Temp";
            this.columnHeader5.Width = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Heater thread count";
            // 
            // textBox_Power
            // 
            this.textBox_Power.Location = new System.Drawing.Point(153, 37);
            this.textBox_Power.Name = "textBox_Power";
            this.textBox_Power.ReadOnly = true;
            this.textBox_Power.Size = new System.Drawing.Size(77, 19);
            this.textBox_Power.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Power (W)";
            // 
            // textBox_AveragedPower
            // 
            this.textBox_AveragedPower.Location = new System.Drawing.Point(153, 62);
            this.textBox_AveragedPower.Name = "textBox_AveragedPower";
            this.textBox_AveragedPower.ReadOnly = true;
            this.textBox_AveragedPower.Size = new System.Drawing.Size(77, 19);
            this.textBox_AveragedPower.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Power 10s avg (W)";
            // 
            // textBox_Temp
            // 
            this.textBox_Temp.Location = new System.Drawing.Point(153, 87);
            this.textBox_Temp.Name = "textBox_Temp";
            this.textBox_Temp.ReadOnly = true;
            this.textBox_Temp.Size = new System.Drawing.Size(77, 19);
            this.textBox_Temp.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Temp (C)";
            // 
            // textBox_AveragedTemp
            // 
            this.textBox_AveragedTemp.Location = new System.Drawing.Point(153, 112);
            this.textBox_AveragedTemp.Name = "textBox_AveragedTemp";
            this.textBox_AveragedTemp.ReadOnly = true;
            this.textBox_AveragedTemp.Size = new System.Drawing.Size(77, 19);
            this.textBox_AveragedTemp.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Temp 10s avg  (C)";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(419, 281);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 4;
            this.button_Add.Text = "Add";
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(520, 281);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 4;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(623, 281);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Save";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // numericUpDown_HeaterCount
            // 
            this.numericUpDown_HeaterCount.Location = new System.Drawing.Point(153, 12);
            this.numericUpDown_HeaterCount.Name = "numericUpDown_HeaterCount";
            this.numericUpDown_HeaterCount.Size = new System.Drawing.Size(77, 19);
            this.numericUpDown_HeaterCount.TabIndex = 5;
            this.numericUpDown_HeaterCount.ValueChanged += new System.EventHandler(this.numericUpDown_HeaterCount_ValueChanged);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(236, 281);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 4;
            this.button_Start.Text = "Start";
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // textBox_ScriptStatus
            // 
            this.textBox_ScriptStatus.Location = new System.Drawing.Point(236, 256);
            this.textBox_ScriptStatus.Name = "textBox_ScriptStatus";
            this.textBox_ScriptStatus.ReadOnly = true;
            this.textBox_ScriptStatus.Size = new System.Drawing.Size(177, 19);
            this.textBox_ScriptStatus.TabIndex = 2;
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(338, 281);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 23);
            this.button_Stop.TabIndex = 4;
            this.button_Stop.Text = "Stop";
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_ScriptSave
            // 
            this.button_ScriptSave.Location = new System.Drawing.Point(236, 339);
            this.button_ScriptSave.Name = "button_ScriptSave";
            this.button_ScriptSave.Size = new System.Drawing.Size(75, 23);
            this.button_ScriptSave.TabIndex = 4;
            this.button_ScriptSave.Text = "Save";
            this.button_ScriptSave.Click += new System.EventHandler(this.button_ScriptSave_Click);
            // 
            // button_ScriptLoad
            // 
            this.button_ScriptLoad.Location = new System.Drawing.Point(338, 339);
            this.button_ScriptLoad.Name = "button_ScriptLoad";
            this.button_ScriptLoad.Size = new System.Drawing.Size(75, 23);
            this.button_ScriptLoad.TabIndex = 4;
            this.button_ScriptLoad.Text = "Load";
            this.button_ScriptLoad.Click += new System.EventHandler(this.button_ScriptLoad_Click);
            // 
            // button_ScriptAdd
            // 
            this.button_ScriptAdd.Location = new System.Drawing.Point(236, 310);
            this.button_ScriptAdd.Name = "button_ScriptAdd";
            this.button_ScriptAdd.Size = new System.Drawing.Size(75, 23);
            this.button_ScriptAdd.TabIndex = 4;
            this.button_ScriptAdd.Text = "Add";
            this.button_ScriptAdd.Click += new System.EventHandler(this.button_ScriptAdd_Click);
            // 
            // button_ScriptClear
            // 
            this.button_ScriptClear.Location = new System.Drawing.Point(338, 310);
            this.button_ScriptClear.Name = "button_ScriptClear";
            this.button_ScriptClear.Size = new System.Drawing.Size(75, 23);
            this.button_ScriptClear.TabIndex = 4;
            this.button_ScriptClear.Text = "Clear";
            this.button_ScriptClear.Click += new System.EventHandler(this.button_ScriptClear_Click);
            // 
            // textBox_Status
            // 
            this.textBox_Status.Location = new System.Drawing.Point(19, 187);
            this.textBox_Status.Multiline = true;
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.ReadOnly = true;
            this.textBox_Status.Size = new System.Drawing.Size(211, 175);
            this.textBox_Status.TabIndex = 2;
            // 
            // comboBox_Xmax
            // 
            this.comboBox_Xmax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Xmax.FormattingEnabled = true;
            this.comboBox_Xmax.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "200",
            "300"});
            this.comboBox_Xmax.Location = new System.Drawing.Point(479, 312);
            this.comboBox_Xmax.Name = "comboBox_Xmax";
            this.comboBox_Xmax.Size = new System.Drawing.Size(74, 20);
            this.comboBox_Xmax.TabIndex = 6;
            this.comboBox_Xmax.SelectedIndexChanged += new System.EventHandler(this.comboBox_Xmax_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(419, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "Xmax (W)";
            // 
            // button_OpenRef
            // 
            this.button_OpenRef.Location = new System.Drawing.Point(520, 339);
            this.button_OpenRef.Name = "button_OpenRef";
            this.button_OpenRef.Size = new System.Drawing.Size(75, 23);
            this.button_OpenRef.TabIndex = 4;
            this.button_OpenRef.Text = "Open Ref";
            this.button_OpenRef.UseVisualStyleBackColor = true;
            this.button_OpenRef.Click += new System.EventHandler(this.button_OpenRef_Click);
            // 
            // button_ClearRef
            // 
            this.button_ClearRef.Location = new System.Drawing.Point(623, 339);
            this.button_ClearRef.Name = "button_ClearRef";
            this.button_ClearRef.Size = new System.Drawing.Size(75, 23);
            this.button_ClearRef.TabIndex = 4;
            this.button_ClearRef.Text = "Clear Ref";
            this.button_ClearRef.UseVisualStyleBackColor = true;
            this.button_ClearRef.Click += new System.EventHandler(this.button_ClearRef_Click);
            // 
            // textBox_Rate
            // 
            this.textBox_Rate.Location = new System.Drawing.Point(153, 137);
            this.textBox_Rate.Name = "textBox_Rate";
            this.textBox_Rate.ReadOnly = true;
            this.textBox_Rate.Size = new System.Drawing.Size(77, 19);
            this.textBox_Rate.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Rate (MFLOPS)";
            // 
            // blankControl_Plot
            // 
            this.blankControl_Plot.Location = new System.Drawing.Point(704, 12);
            this.blankControl_Plot.Name = "blankControl_Plot";
            this.blankControl_Plot.Size = new System.Drawing.Size(370, 350);
            this.blankControl_Plot.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "Rate 10s avg (MFLOPS)";
            // 
            // textBox_AverageRate
            // 
            this.textBox_AverageRate.Location = new System.Drawing.Point(153, 162);
            this.textBox_AverageRate.Name = "textBox_AverageRate";
            this.textBox_AverageRate.ReadOnly = true;
            this.textBox_AverageRate.Size = new System.Drawing.Size(77, 19);
            this.textBox_AverageRate.TabIndex = 7;
            // 
            // CPUThermalTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 371);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_AverageRate);
            this.Controls.Add(this.comboBox_Xmax);
            this.Controls.Add(this.numericUpDown_HeaterCount);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_ClearRef);
            this.Controls.Add(this.button_OpenRef);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_ScriptLoad);
            this.Controls.Add(this.button_ScriptClear);
            this.Controls.Add(this.button_ScriptAdd);
            this.Controls.Add(this.button_ScriptSave);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Rate);
            this.Controls.Add(this.textBox_AveragedTemp);
            this.Controls.Add(this.textBox_Temp);
            this.Controls.Add(this.textBox_AveragedPower);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.textBox_ScriptStatus);
            this.Controls.Add(this.textBox_Power);
            this.Controls.Add(this.blankControl_Plot);
            this.Controls.Add(this.listView_Curve);
            this.Controls.Add(this.listView_Script);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CPUThermalTester";
            this.Text = "CPUThermalTester";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HeaterCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Script;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listView_Curve;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private CPUCoolerTester.BlankControl blankControl_Plot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Power;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_AveragedPower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Temp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_AveragedTemp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.NumericUpDown numericUpDown_HeaterCount;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_ScriptStatus;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_ScriptSave;
        private System.Windows.Forms.Button button_ScriptLoad;
        private System.Windows.Forms.Button button_ScriptAdd;
        private System.Windows.Forms.Button button_ScriptClear;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.ComboBox comboBox_Xmax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_OpenRef;
        private System.Windows.Forms.Button button_ClearRef;
        private System.Windows.Forms.TextBox textBox_Rate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_AverageRate;
    }
}

