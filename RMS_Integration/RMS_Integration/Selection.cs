using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS_Integration
{
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private RMSApp newForm;

        private void bttnAccel_Click(object sender, EventArgs e)
        {
            //Minimize current window
            this.WindowState = FormWindowState.Minimized;

            //Open Accelerometer Window
            if (newForm == null)
            {
                newForm = new RMSApp();
                newForm.FormClosing += new FormClosingEventHandler(newForm_FormClosing);
            }
            newForm.Show();
            
            //If accelerometer window is close, Selection window will open
            //this.WindowState = FormWindowState.Normal;
        }

        void newForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            newForm = null;
            this.WindowState = FormWindowState.Normal;
        }

        private void bttnPres_Click(object sender, EventArgs e)
        {
            //Open Pressure Sensor Window
        }

        private void bttnLight_Click(object sender, EventArgs e)
        {
            //Open Light Absorption
        }
    }
}
