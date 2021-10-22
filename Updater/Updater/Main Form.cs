using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Updater
{
    public partial class Main_Form : Form
    {
        private TaskbarManager taskbar = TaskbarManager.Instance;
        private readonly string Domain = "www.JacobTech.com", Process_Name, RemoteDir, exe;
        private string[] Files = null;
        public double scale = 1, filscale = 1;
        private ulong before = 0, fil = 0, last = 0;

        public Main_Form(string Process, string Programdir, string exefile, string[] files)
        {
            InitializeComponent();
            Process_Name = Process;
            RemoteDir = Uri.EscapeDataString(Programdir);
            exe = exefile;
            if (files != null) Files = files;
        }

        private void Main_Form_Shown(object sender, EventArgs e)
        {
            Current_Process.Style = ProgressBarStyle.Marquee;
            taskbar.SetProgressState(TaskbarProgressBarState.Indeterminate);
            Wait.RunWorkerAsync();
            Speed.Start();
        }

        private void ChangeProcessText(string Process)
        {
            if (Current_Process_Label.InvokeRequired) Current_Process_Label.Invoke(new Action(() => { Current_Process_Label.Text = $"Current Process: {Process}"; }));
            else Current_Process_Label.Text = $"Current Process: {Process}";
        }

        private bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcessesByName(name.ToLower()))
            {
                if (clsProcess.ProcessName.ToLower().Contains(name.ToLower()))
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
        bool good = true;
        bool downloading = true;
        private void Download_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (WebClient web = new WebClient())
            {
                string type = "https";
                string rem = "";
                int max;
                ulong realmax;

                ChangeProcessText("Getting update info");
                try
                {
                    rem = web.DownloadString($"{type}://{Domain}/Updater/Files/{RemoteDir}");
                }
                catch (WebException ex)
                {
                    if (ex.Message == "Unable to connect to the remote server")
                    {
                        try
                        {
                            type = "http";
                            rem = web.DownloadString($"{type}://{Domain}/Updater/Files/{RemoteDir}");
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.Message);
                            Application.Exit();
                        }
                    }
                    else if (ex.Message == $"The remote name could not be resolved: '{Domain.ToLower()}'")
                    {
                        MessageBox.Show($"The Domain '{Domain}' is currently down.\nPlease try to update the program latter", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                        Application.Exit();
                    }
                }
                string uri;
                try
                {
                    realmax = ulong.Parse(web.DownloadString($"{type}://{Domain}/Updater/GetSize/{RemoteDir}"));
                    if (realmax > int.MaxValue)
                    {
                        scale = (double)int.MaxValue /(double)realmax;
                        max = int.MaxValue;
                    }
                    else max = (int)realmax;
                    web.DownloadProgressChanged += Web_DownloadProgressChanged;
                    web.DownloadFileCompleted += Web_DownloadFileCompleted;
                    Total_Downloaded.Invoke(new Action(() => { Total_Downloaded.Text = TotalDownloadAmountNeat(realmax); }));
                    foreach (string file in rem.Split('\n'))
                    {
                        if (string.IsNullOrEmpty(file)) return;
                        bool f = true;
                        while (f)
                        {
                            while (good)
                            {
                                while (!web.IsBusy)
                                {
                                    uri = $"{type}://{Domain}/Updater/GetFileSize/{RemoteDir}/{Uri.EscapeDataString(file)}";
                                    fil = ulong.Parse(web.DownloadString(uri));
                                    int locfil;
                                    filscale = 1;
                                    if (fil > int.MaxValue)
                                    {
                                        locfil = int.MaxValue;
                                        filscale = (double)int.MaxValue / (double)fil;
                                    }
                                    else locfil = (int)fil;
                                    if (Current_Process.InvokeRequired)
                                    {
                                        Total_Progress.Invoke(new Action(() => { Total_Progress.Maximum = max; }));
                                        string file2 = Uri.UnescapeDataString(file);
                                        Current_Process.Invoke(new Action(() => { Current_Process.Maximum = locfil; }));
                                    }
                                    else
                                    {
                                        Total_Progress.Maximum = max;
                                        Current_Process.Maximum = locfil;
                                    }
                                    string name = file.Replace("%20", " ").Replace("%28", "(").Replace("%29", ")");
                                    Uri u = new Uri($"{type}://{Domain}/Updater/GetFile/{RemoteDir}/{Uri.EscapeDataString(file)}");
                                    downloading = true;
                                    ChangeProcessText($"Downloading {name}");
                                    good = false;
                                    web.DownloadFileAsync(u, name);
                                    break;
                                }
                                f = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Web_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            downloading = false;
            before += fil;
            good = true;
        }

        private void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ulong ctemp = (ulong)Math.Round((ulong)e.BytesReceived * filscale, 0);
            if (ctemp > int.MaxValue) ctemp = int.MaxValue;
            int ctol = (int)ctemp;
            ulong total = before + (ulong)e.BytesReceived;
            ulong temp = (ulong)Math.Round(total * scale, 0);
            if (temp > int.MaxValue) temp = int.MaxValue;
            int tol = (int)temp;
            if (Current_Process.InvokeRequired)
            {
                Current_Process.Invoke(new Action(() => { Current_Process.Value = ctol; }));
                if (tol > Total_Progress.Maximum) tol = Total_Progress.Maximum;
                Total_Progress.Invoke(new Action(() => { Total_Progress.Value = tol; }));
                Total_Downloaded.Invoke(new Action(() => { Total_Downloaded.Text = Downloaded_Amount_Neat(total, Total_Downloaded.Text); }));
            }
            else
            {
                Current_Process.Value = ctol;
                if (tol > Total_Progress.Maximum) tol = Total_Progress.Maximum;
                Total_Progress.Value = tol;
                Total_Downloaded.Text = Downloaded_Amount_Neat(total, Total_Downloaded.Text);
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

        private string TotalDownloadAmountNeat(double Number)
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
            ulong BitesPertenthSec = ((ulong)Math.Round(Total_Progress.Value/scale, 0)) - last;
            last = ((ulong)Math.Round(Total_Progress.Value / scale, 0));
            Transfer_Speed.Text = Download_Speed_Neat(BitesPertenthSec);
        }

        private void Download_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Start.RunWorkerAsync();
        }

        private void Start_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool good = true;
            while (good)
            {
                if (!downloading)
                {
                    good = false;
                    Process p = new Process();
                    p.StartInfo.FileName = exe;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    p.Start();
                    Application.Exit();
                }
            }
        }
    }
}
