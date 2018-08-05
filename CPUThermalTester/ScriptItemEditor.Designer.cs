namespace CPUThermalTester
{
    partial class ScriptItemEditor
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
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.numericUpDown_HeaterThreadCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Wait = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HeaterThreadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Wait)).BeginInit();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(43, 94);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(138, 94);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_HeaterThreadCount
            // 
            this.numericUpDown_HeaterThreadCount.Location = new System.Drawing.Point(139, 25);
            this.numericUpDown_HeaterThreadCount.Name = "numericUpDown_HeaterThreadCount";
            this.numericUpDown_HeaterThreadCount.Size = new System.Drawing.Size(91, 19);
            this.numericUpDown_HeaterThreadCount.TabIndex = 0;
            // 
            // numericUpDown_Wait
            // 
            this.numericUpDown_Wait.Location = new System.Drawing.Point(139, 50);
            this.numericUpDown_Wait.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Wait.Name = "numericUpDown_Wait";
            this.numericUpDown_Wait.Size = new System.Drawing.Size(91, 19);
            this.numericUpDown_Wait.TabIndex = 1;
            this.numericUpDown_Wait.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Heater thread count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wait";
            // 
            // ScriptItemEditor
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(258, 139);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_Wait);
            this.Controls.Add(this.numericUpDown_HeaterThreadCount);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Name = "ScriptItemEditor";
            this.Text = "ScriptItemEditor";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HeaterThreadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Wait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.NumericUpDown numericUpDown_HeaterThreadCount;
        private System.Windows.Forms.NumericUpDown numericUpDown_Wait;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}