using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace RenamingTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_SelectInputFolder_Click(object sender, EventArgs e)
        {
            this.lb_InputFolderPath.Text = "selected";
        }

        private void Btn_SelectOutputFolder_Click(object sender, EventArgs e)
        {
            this.lb_OutputFolderPath.Text = "selected";
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {

        }
    }
}
