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
        public static class GlobalVariables
        {
            //Variable to hold the warning message
            public static string warningMessage = "Please note that deploying cloud resources may result in charges to your account. By clicking the deploy button, you acknowledge and agree that you are responsible for any charges that may be incurred as a result of this action";
        }

        private void button1_Click(object sender, EventArgs e) //AWS deploy btn
        {
            //this if statement requires confirmation before running the code
            if (MessageBox.Show("Are you sure you want to perform this action?\r" + GlobalVariables.warningMessage, "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                textBox1.AppendText("Please wait...\r\n"); // prints in text box
                var ps1Apply = @"C:\\FYP_CLOUD_APP\\powershell\\TF_AWS_Apply.ps1"; // gives powershell path to a variable
                var startInfo = new ProcessStartInfo() //declaring the arguments for the process
                {
                    FileName = "powershell.exe", // this is the app we want to start
                    Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Apply}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true, // used to stream the output to gui 
                    CreateNoWindow = true // hide window 
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
        private void button2_Click(object sender, EventArgs e) //AWS Destroy btn
        {
            if (MessageBox.Show("Are you sure you want to perform this action?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
        }

        private void button3_Click(object sender, EventArgs e) //Azure deploy btn
        {
            if (MessageBox.Show("Are you sure you want to perform this action? \r" + GlobalVariables.warningMessage, "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //combox variables take the values from the boxes
                var cpuVar = comboBox1.Text;
                var imageRef = comboBox2.Text;
                if (imageRef == "Ubuntu Server 18.04")
                {
                    imageRef = "Canonical:UbuntuServer:18.04-LTS"; //if ubuntu was chosen the variable updates to this to hold publisher, offer and sku info
                }
                else 
                {
                    imageRef = "debian:debian-11:11-gen2";
                }
                //converting the string to array and splitting on colons so 
                string[] imageRefParts = imageRef.Split(':');
                string publisher = imageRefParts[0];
                string offer = imageRefParts[1];
                string sku = imageRefParts[2];
                textBox1.AppendText("Please wait...\r\n");
                var ps1Apply = @"C:\\FYP_CLOUD_APP\\powershell\\TF_Azure_Apply.ps1";
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Apply}\" \"{cpuVar}\" \"{publisher}\" \"{offer}\" \"{sku}\"", //passing variables to powershell
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

        private void button4_Click(object sender, EventArgs e) //Azure Destroy btn
        {
            if (MessageBox.Show("Are you sure you want to perform this action?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
        private void button5_Click(object sender, EventArgs e) //AWS bucket deploy
        {
            if (MessageBox.Show("Are you sure you want to perform this action? \r" + GlobalVariables.warningMessage, "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var userBucketName = textBox2.Text; // taking user input
                textBox1.AppendText("Please wait...\r\n");
                var ps1Destroy = @"C:\\FYP_CLOUD_APP\\powershell\\TF_AWS_Bucket_Apply.ps1";
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy unrestricted \"{ps1Destroy}\" \"{userBucketName}\"",
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

        private void button6_Click(object sender, EventArgs e) //AWS bucket destroy
        {
            if (MessageBox.Show("Are you sure you want to perform this action?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                textBox1.AppendText("Please wait...\r\n");
                var ps1Destroy = @"C:\\FYP_CLOUD_APP\\powershell\\TF_AWS_Bucket_Destroy.ps1";
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
}
