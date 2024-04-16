using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission
{
    public partial class Form2 : Form
    {
        public RegControl RegControl { get; set; }
        public LogControl LogControl { get; set; }
        public Form2()
        {
            RegControl = new RegControl(this);
            LogControl = new LogControl(this);
            this.Controls.Add(RegControl);
            this.Controls.Add(LogControl);
            InitializeComponent();
            LogControl.Hide();
            RegControl.Show();
        }
    }
}
