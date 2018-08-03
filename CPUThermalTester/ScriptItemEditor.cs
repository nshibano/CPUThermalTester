using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUThermalTester
{
    public partial class ScriptItemEditor : Form
    {
        public NumericUpDown HeaterThreadCount { get { return numericUpDown_HeaterThreadCount; } }
        public NumericUpDown Wait { get { return numericUpDown_Wait; } }

        public ScriptItemEditor()
        {
            InitializeComponent();
        }
    }
}
