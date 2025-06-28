using System.Windows.Forms;

namespace Silvia_s_Capture
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prepareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startScheduleRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.RecordingLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.StartedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StoppedLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.RecordingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StartingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StoppingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stopScheduleRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prepareToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.startScheduleRecordingToolStripMenuItem,
            this.stopScheduleRecordingToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(49, 22);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // prepareToolStripMenuItem
            // 
            this.prepareToolStripMenuItem.Name = "prepareToolStripMenuItem";
            this.prepareToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.prepareToolStripMenuItem.Text = "Prepare";
            this.prepareToolStripMenuItem.Click += new System.EventHandler(this.prepareToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // startScheduleRecordingToolStripMenuItem
            // 
            this.startScheduleRecordingToolStripMenuItem.Name = "startScheduleRecordingToolStripMenuItem";
            this.startScheduleRecordingToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.startScheduleRecordingToolStripMenuItem.Text = "Start Schedule Recording";
            this.startScheduleRecordingToolStripMenuItem.Click += new System.EventHandler(this.startScheduleRecordingToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem1});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem1.Text = "Options";
            this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(3);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RecordingLable,
            this.StartedLabel,
            this.StoppedLable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 530);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1484, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "Status now is:";
            // 
            // RecordingLable
            // 
            this.RecordingLable.ForeColor = System.Drawing.Color.Navy;
            this.RecordingLable.Name = "RecordingLable";
            this.RecordingLable.Size = new System.Drawing.Size(167, 17);
            this.RecordingLable.Text = "Camera 1-Recording status is :";
            // 
            // StartedLabel
            // 
            this.StartedLabel.Name = "StartedLabel";
            this.StartedLabel.Size = new System.Drawing.Size(63, 17);
            this.StartedLabel.Text = "Started at: ";
            // 
            // StoppedLable
            // 
            this.StoppedLable.Name = "StoppedLable";
            this.StoppedLable.Size = new System.Drawing.Size(67, 17);
            this.StoppedLable.Text = "Stopped at:";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RecordingLabel,
            this.StartingLabel,
            this.StoppingLabel});
            this.statusStrip2.Location = new System.Drawing.Point(0, 508);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1484, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "Status now is:";
            // 
            // RecordingLabel
            // 
            this.RecordingLabel.ForeColor = System.Drawing.Color.Maroon;
            this.RecordingLabel.Name = "RecordingLabel";
            this.RecordingLabel.Size = new System.Drawing.Size(161, 17);
            this.RecordingLabel.Text = "Camera2-Recording status is:";
            // 
            // StartingLabel
            // 
            this.StartingLabel.Name = "StartingLabel";
            this.StartingLabel.Size = new System.Drawing.Size(72, 17);
            this.StartingLabel.Text = "StartedLabel";
            // 
            // StoppingLabel
            // 
            this.StoppingLabel.Name = "StoppingLabel";
            this.StoppingLabel.Size = new System.Drawing.Size(83, 17);
            this.StoppingLabel.Text = "StoppingLabel";
            // 
            // stopScheduleRecordingToolStripMenuItem
            // 
            this.stopScheduleRecordingToolStripMenuItem.Name = "stopScheduleRecordingToolStripMenuItem";
            this.stopScheduleRecordingToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.stopScheduleRecordingToolStripMenuItem.Text = "Stop Schedule Recording";
            this.stopScheduleRecordingToolStripMenuItem.Click += new System.EventHandler(this.stopScheduleRecordingToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 552);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Capture program developed by Tali Kimchi\'s lab-Weizmann Institute";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem prepareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startScheduleRecordingToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ToolStripStatusLabel RecordingLable;
        private ToolStripStatusLabel StartedLabel;
        private ToolStripStatusLabel StoppedLable;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel RecordingLabel;
        private ToolStripStatusLabel StartingLabel;
        private ToolStripStatusLabel StoppingLabel;
        private ToolStripMenuItem stopScheduleRecordingToolStripMenuItem;
    }
}

