namespace Updater
{
    partial class Main_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.Total_Progress = new System.Windows.Forms.ProgressBar();
            this.Current_Process = new System.Windows.Forms.ProgressBar();
            this.Current_Process_Label = new System.Windows.Forms.Label();
            this.Transfer_Speed = new System.Windows.Forms.Label();
            this.Total_Downloaded = new System.Windows.Forms.Label();
            this.Wait = new System.ComponentModel.BackgroundWorker();
            this.Download = new System.ComponentModel.BackgroundWorker();
            this.Speed = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Start = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Total_Progress
            // 
            this.Total_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Total_Progress.Location = new System.Drawing.Point(24, 192);
            this.Total_Progress.Margin = new System.Windows.Forms.Padding(4);
            this.Total_Progress.Name = "Total_Progress";
            this.Total_Progress.Size = new System.Drawing.Size(700, 28);
            this.Total_Progress.TabIndex = 0;
            // 
            // Current_Process
            // 
            this.Current_Process.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Current_Process.Location = new System.Drawing.Point(24, 156);
            this.Current_Process.Margin = new System.Windows.Forms.Padding(4);
            this.Current_Process.Name = "Current_Process";
            this.Current_Process.Size = new System.Drawing.Size(700, 28);
            this.Current_Process.TabIndex = 2;
            // 
            // Current_Process_Label
            // 
            this.Current_Process_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Current_Process_Label.AutoSize = true;
            this.Current_Process_Label.Location = new System.Drawing.Point(23, 82);
            this.Current_Process_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Current_Process_Label.Name = "Current_Process_Label";
            this.Current_Process_Label.Size = new System.Drawing.Size(399, 25);
            this.Current_Process_Label.TabIndex = 3;
            this.Current_Process_Label.Text = "Current Process: Waiting for threads to close";
            // 
            // Transfer_Speed
            // 
            this.Transfer_Speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Transfer_Speed.AutoSize = true;
            this.Transfer_Speed.Location = new System.Drawing.Point(23, 127);
            this.Transfer_Speed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Transfer_Speed.Name = "Transfer_Speed";
            this.Transfer_Speed.Size = new System.Drawing.Size(162, 25);
            this.Transfer_Speed.TabIndex = 4;
            this.Transfer_Speed.Text = "Download Speed";
            // 
            // Total_Downloaded
            // 
            this.Total_Downloaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total_Downloaded.AutoSize = true;
            this.Total_Downloaded.Location = new System.Drawing.Point(23, 104);
            this.Total_Downloaded.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Total_Downloaded.Name = "Total_Downloaded";
            this.Total_Downloaded.Size = new System.Drawing.Size(172, 25);
            this.Total_Downloaded.TabIndex = 5;
            this.Total_Downloaded.Text = "Download Amount";
            // 
            // Wait
            // 
            this.Wait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Wait_DoWork);
            this.Wait.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Wait_RunWorkerCompleted);
            // 
            // Download
            // 
            this.Download.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Download_DoWork);
            this.Download.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Download_RunWorkerCompleted);
            // 
            // Speed
            // 
            this.Speed.Tick += new System.EventHandler(this.Speed_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(93, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 49);
            this.label1.TabIndex = 6;
            this.label1.Text = "JacobTech";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Updater.Properties.Resources.Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(24, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 60);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Start
            // 
            this.Start.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Start_DoWork);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 244);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Total_Downloaded);
            this.Controls.Add(this.Transfer_Speed);
            this.Controls.Add(this.Current_Process_Label);
            this.Controls.Add(this.Current_Process);
            this.Controls.Add(this.Total_Progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(122221, 244);
            this.MinimumSize = new System.Drawing.Size(749, 244);
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater";
            this.Shown += new System.EventHandler(this.Main_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Total_Progress;
        private System.Windows.Forms.ProgressBar Current_Process;
        private System.Windows.Forms.Label Current_Process_Label;
        private System.Windows.Forms.Label Transfer_Speed;
        private System.Windows.Forms.Label Total_Downloaded;
        private System.ComponentModel.BackgroundWorker Wait;
        private System.ComponentModel.BackgroundWorker Download;
        private System.Windows.Forms.Timer Speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker Start;
    }
}