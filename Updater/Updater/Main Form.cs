using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shell;

namespace Updater
{
    public partial class Main_Form : Form
    {
        private TaskbarManager taskbar = TaskbarManager.Instance;
        private string[] Files = null;
        private string Process_Name;
        private string RemoteDir;
        private string exe;
       // private int current = 0;
        private int before = 0;
        private int fil = 0;
        private int last = 0;

        public Main_Form(string Process, string Programdir, string exefile, string files)
        {
            InitializeComponent();
            Process_Name = Process;
            RemoteDir = Programdir;
            exe = exefile;
            if (files != null) Files = files.Split('|');
        }

        

        private void Main_Form_Shown(object sender, EventArgs e)
        {
            Current_Process.Style = ProgressBarStyle.Marquee;
            taskbar.SetProgressState(TaskbarProgressBarState.Indeterminate);
            Wait.RunWorkerAsync();
            //Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            //Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 4, Location.Y);
            
        }

        private void ChangeProcessText(string Process)
        {
            if (Current_Process_Label.InvokeRequired) Current_Process_Label.Invoke(new Action(() => { Current_Process_Label.Text = $"Current Process: {Process}"; }));
            else Current_Process_Label.Text = $"Current Process: {Process}";
        }

        private bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcessesByName(name))
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }

        private void Wait_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool good = true;
            while (good)
            {
                while (!IsProcessOpen(Process_Name))
                {
                    good = false;
                    break;
                }
            }
        }

        private void Wait_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Speed.Start();
            taskbar.SetProgressState(TaskbarProgressBarState.Normal);
            if (Current_Process.InvokeRequired) Current_Process.Invoke(new Action(() => { Current_Process.Style = ProgressBarStyle.Continuous; }));
            else Current_Process.Style = ProgressBarStyle.Continuous;
            if (Files != null)
            {
                ChangeProcessText("Deleting old program files");
                Current_Process.Maximum = Files.Length;
                foreach (string file in Files)
                {
                    File.Delete(file);
                    Current_Process.Value++;
                }
            }
            Download.RunWorkerAsync();
        }

        private void Download_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (WebClient web = new WebClient())
            {
                string type = "https";
                string rem = "";
                int max;
                
                ChangeProcessText("Getting update info");
                try
                {
                    rem = web.DownloadString($"{type}://jacobtech.org/Programs/Files/{RemoteDir}");
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Unable to connect to the remote server")
                    {
                        try
                        {
                            type = "http";
                            rem = web.DownloadString($"{type}://jacobtech.org/Programs/Files/{RemoteDir}");
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                try
                {
                    max = int.Parse(web.DownloadString($"{type}://jacobtech.org/Programs/GetSize/{RemoteDir}"));
                    web.DownloadProgressChanged += Web_DownloadProgressChanged;
                    web.DownloadFileCompleted += Web_DownloadFileCompleted;
                    Total_Downloaded.Invoke(new Action(() => { Total_Downloaded.Text = TotalDownloadAmmountNeat(max); }));
                    foreach (string file in rem.Split('|'))
                    {
                        bool good = true;
                        while (good)
                        {
                            while (!web.IsBusy)
                            {
                                string[] split = file.Split('.');
                                string fill = "";
                                foreach (string fillll in split)
                                {
                                    fill = fill + fillll + Uri.EscapeDataString("|");
                                }
                                fill = fill.Remove(fill.Length - Uri.EscapeDataString("|").Length, Uri.EscapeDataString("|").Length);
                                string uri = $"{type}://jacobtech.org/Programs/GetFileSize/{RemoteDir}{Uri.EscapeDataString("|")}{fill}";
                                fil = int.Parse(web.DownloadString(uri));
                                if (Current_Process.InvokeRequired)
                                {
                                    Total_Progress.Invoke(new Action(() => { Total_Progress.Maximum = max; }));
                                    string file2 = Uri.UnescapeDataString(file);
                                    Current_Process.Invoke(new Action(() => { Current_Process.Maximum = int.Parse(web.DownloadString(uri)); }));
                                }
                                else
                                {
                                    Total_Progress.Maximum = max;
                                    Current_Process.Maximum = int.Parse(web.DownloadString(uri));
                                }
                                string name = file.Replace("%20", " ").Replace("%28", "(").Replace("%29", ")");
                                Uri u = new Uri($"{type}://jacobtech.org/Programs/{RemoteDir}/Files/{file}");
                                ChangeProcessText($"Downloading {name}");
                                web.DownloadFileAsync(u, name);
                                good = false;
                                break;
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Web_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            before = before + fil;
        }

        private void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (Current_Process.InvokeRequired)
            {
                Current_Process.Invoke(new Action(() => { Current_Process.Value = int.Parse(e.BytesReceived.ToString()); }));
                Total_Progress.Invoke(new Action(() => { Total_Progress.Value = before + int.Parse(e.BytesReceived.ToString()); }));
                Total_Downloaded.Invoke(new Action(() => { Total_Downloaded.Text = Downloaded_Amount_Neat(Total_Progress.Value, Total_Downloaded.Text); }));
            }
            else
            {
                Current_Process.Value = int.Parse(e.BytesReceived.ToString());
                Total_Progress.Value = before + int.Parse(e.BytesReceived.ToString());
                Total_Downloaded.Text = Downloaded_Amount_Neat(Total_Progress.Value, Total_Downloaded.Text);
            }
            taskbar.SetProgressValue(Total_Progress.Value, Total_Progress.Maximum);
        }

        #region Neat
        private string Download_Speed_Neat(double Number)
        {
            string Size = SizeName(Number);
            int Exponet;
            if (Number / 1024 >= 1)
                if (Number / Math.Pow(1024, 2) >= 1)
                    if (Number / Math.Pow(1024, 3) >= 1) Exponet = 3;
                    else Exponet = 2;
                else Exponet = 1;
            else Exponet = 0;

            Number = Math.Round(Number / Math.Pow(1024, Exponet), 2, MidpointRounding.ToEven);
            if (!Number.ToString().Contains("."))
            {
                return $"{Number}.00{Size}s           ";
            }
            else
            {
                if (Number.ToString().Remove(0, Number.ToString().IndexOf('.')).Length == 1)
                {
                    return $"{Number}0{Size}s           ";
                }
                else
                {
                    return $"{Number}{Size}s           ";
                }
            }
        }

        private string Downloaded_Amount_Neat(double Number, string Old_Text)
        {
            int Exponet = 0;
            string Size = SizeName(Number);
            if (Size == "Gb") Exponet = 3;
            else if (Size == "Mb") Exponet = 2;
            else if (Size == "Kb") Exponet = 1;
            Number = Math.Round(Number / Math.Pow(1024, Exponet), 2, MidpointRounding.ToEven);

            string text = Old_Text.Remove(0, Old_Text.IndexOf(' '));
            text = text.Replace("           ", "");
            if (!Number.ToString().Contains("."))
            {
                text = $"{Number}.00{Size}{text}           ";
            }
            else
            {
                if (Number.ToString().Remove(0, Number.ToString().IndexOf('.')).Length == 1)
                {
                    text = $"{Number}0{Size}{text}           ";
                }
                else
                {
                    text = $"{Number}{Size}{text}           ";
                }
            }
            return text;
        }

        private string TotalDownloadAmmountNeat(double Number)
        {
            string Output;
            int Exponet;
            if (Number / 1024 >= 1)
                if (Number / Math.Pow(1024, 2) >= 1)
                    if (Number / Math.Pow(1024, 3) >= 1) Exponet = 3;
                    else Exponet = 2;
                else Exponet = 1;
            else Exponet = 0;
            Output = $"0{SizeName(Number)} / {Math.Round(Number / Math.Pow(1024, Exponet), 2, MidpointRounding.ToEven)}{SizeName(Number)}           ";
            return Output;
        }

        private string SizeName(double Number)
        {
            string Size;
            if (Number / 1024 >= 1)
                if (Number / Math.Pow(1024, 2) >= 1)
                    if (Number / Math.Pow(1024, 3) >= 1) Size = "Gb";
                    else Size = "Mb";
                else Size = "Kb";
            else Size = "b";
            return Size;
        }
        #endregion

        private void Speed_Tick(object sender, EventArgs e)
        {
            double BitesPertenthSec = Total_Progress.Value - last;
            last = Total_Progress.Value;
            Transfer_Speed.Text = Download_Speed_Neat(BitesPertenthSec * 10);
        }

        private void Download_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Speed.Stop();
            Process p = new Process();
            p.StartInfo.FileName = exe;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
            Application.Exit();
        }
    }
}
