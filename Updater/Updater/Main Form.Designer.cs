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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Total_Progress
            // 
            this.Total_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Total_Progress.Location = new System.Drawing.Point(20, 160);
            this.Total_Progress.Name = "Total_Progress";
            this.Total_Progress.Size = new System.Drawing.Size(573, 23);
            this.Total_Progress.TabIndex = 0;
            // 
            // Current_Process
            // 
            this.Current_Process.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Current_Process.Location = new System.Drawing.Point(20, 130);
            this.Current_Process.Name = "Current_Process";
            this.Current_Process.Size = new System.Drawing.Size(573, 23);
            this.Current_Process.TabIndex = 2;
            // 
            // Current_Process_Label
            // 
            this.Current_Process_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Current_Process_Label.AutoSize = true;
            this.Current_Process_Label.Location = new System.Drawing.Point(19, 68);
            this.Current_Process_Label.Name = "Current_Process_Label";
            this.Current_Process_Label.Size = new System.Drawing.Size(324, 20);
            this.Current_Process_Label.TabIndex = 3;
            this.Current_Process_Label.Text = "Current Process: Waiting for threads to close";
            // 
            // Transfer_Speed
            // 
            this.Transfer_Speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Transfer_Speed.AutoSize = true;
            this.Transfer_Speed.Location = new System.Drawing.Point(19, 106);
            this.Transfer_Speed.Name = "Transfer_Speed";
            this.Transfer_Speed.Size = new System.Drawing.Size(131, 20);
            this.Transfer_Speed.TabIndex = 4;
            this.Transfer_Speed.Text = "Download Speed";
            // 
            // Total_Downloaded
            // 
            this.Total_Downloaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total_Downloaded.AutoSize = true;
            this.Total_Downloaded.Location = new System.Drawing.Point(19, 87);
            this.Total_Downloaded.Name = "Total_Downloaded";
            this.Total_Downloaded.Size = new System.Drawing.Size(153, 20);
            this.Total_Downloaded.TabIndex = 5;
            this.Total_Downloaded.Text = "Download Ammount";
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
            this.label1.Location = new System.Drawing.Point(76, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "JacobTech";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Updater.Properties.Resources.Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(20, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 203);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Total_Downloaded);
            this.Controls.Add(this.Transfer_Speed);
            this.Controls.Add(this.Current_Process_Label);
            this.Controls.Add(this.Current_Process);
            this.Controls.Add(this.Total_Progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(99999, 203);
            this.MinimumSize = new System.Drawing.Size(613, 203);
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
    }
}