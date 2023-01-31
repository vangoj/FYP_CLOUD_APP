using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace FYP_CLOUD_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ps1Apply = @"C:\\FYP_APP\\powershell\\terraformapply.ps1"; //assign the variable the path of the ps1 file
            var startInfo = new ProcessStartInfo() //used to specify the properties of a process
            {
                FileName = "powershell.exe", //run powershell
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Apply}\"", //run it with these arguments 
                UseShellExecute = false //starts directly using no shell
            };
            Process.Start(startInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ps1Destroy = @"C:\\FYP_APP\\powershell\\terraformDestroy.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Destroy}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }
    }
}
