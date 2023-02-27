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

        private void button1_Click(object sender, EventArgs e) //AWS deploy btn
        {
            textBox1.AppendText("Please wait...\r\n");
            var ps1Apply = @"C:\\FYP_CLOUD_APP\\powershell\\TF_AWS_Apply.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Apply}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var process = new Process()
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (s, args) =>
            {
                
                if (!string.IsNullOrEmpty(args.Data))
                {
                    // Append the output to textBox1
                    textBox1.Invoke((MethodInvoker)delegate
                    {
                        textBox1.AppendText(args.Data + Environment.NewLine);
                    });
                }
            };
            process.Start();
            process.BeginOutputReadLine();
        }
        private void button2_Click(object sender, EventArgs e) //AWS Destroy btn
        {
            textBox1.AppendText("Please wait...\r\n");
            var ps1Destroy = @"C:\\FYP_CLOUD_APP\\powershell\\TF_AWS_Destroy.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Destroy}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var process = new Process()
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };
            process.OutputDataReceived += (s, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    // Append the output to textBox1
                    textBox1.Invoke((MethodInvoker)delegate
                    {
                        textBox1.AppendText(args.Data + Environment.NewLine);
                    });
                }
            };
            process.Start();
            process.BeginOutputReadLine();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //Azure deploy btn
        {
            textBox1.AppendText("Please wait...\r\n");
            var ps1Apply = @"C:\\FYP_CLOUD_APP\\powershell\\TF_Azure_Apply.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Apply}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var process = new Process()
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };
            process.OutputDataReceived += (s, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    // Append the output to textBox1
                    textBox1.Invoke((MethodInvoker)delegate
                    {
                        textBox1.AppendText(args.Data + Environment.NewLine);
                    });
                }
            };
            process.Start();
            process.BeginOutputReadLine();
        }

        private void button4_Click(object sender, EventArgs e) //Azure Destroy btn
        {
            textBox1.AppendText("Please wait...\r\n");
            var ps1Destroy = @"C:\\FYP_CLOUD_APP\\powershell\\TF_Azure_Destroy.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Destroy}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var process = new Process()
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };
            process.OutputDataReceived += (s, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    // Append the output to textBox1
                    textBox1.Invoke((MethodInvoker)delegate
                    {
                        textBox1.AppendText(args.Data + Environment.NewLine);
                    });
                }
            };
            process.Start();
            process.BeginOutputReadLine();
        
    }
    }
}
