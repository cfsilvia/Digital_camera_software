namespace CameraCtrl
{
    partial class CameraCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbCamera = new System.Windows.Forms.GroupBox();
            this._ic = new TIS.Imaging.ICImagingControl();
            this.icContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devicePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerGPIn = new System.Windows.Forms.Timer(this.components);
            this.gbCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ic)).BeginInit();
            this.icContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCamera
            // 
            this.gbCamera.Controls.Add(this._ic);
            this.gbCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCamera.Location = new System.Drawing.Point(0, 0);
            this.gbCamera.Name = "gbCamera";
            this.gbCamera.Size = new System.Drawing.Size(700, 700);
            this.gbCamera.TabIndex = 0;
            this.gbCamera.TabStop = false;
            this.gbCamera.Text = "groupBox1";
            // 
            // _ic
            // 
            this._ic.BackColor = System.Drawing.Color.White;
            this._ic.ContextMenuStrip = this.icContextMenu;
            this._ic.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
            this._ic.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
            this._ic.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ic.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded;
            this._ic.LiveDisplayPosition = new System.Drawing.Point(0, 0);
            this._ic.Location = new System.Drawing.Point(3, 16);
            this._ic.Name = "_ic";
            this._ic.Size = new System.Drawing.Size(694, 681);
            this._ic.TabIndex = 0;
            this._ic.Load += new System.EventHandler(this._ic_Load);
            // 
            // icContextMenu
            // 
            this.icContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDeviceToolStripMenuItem,
            this.devicePropertiesToolStripMenuItem});
            this.icContextMenu.Name = "icContextMenu";
            this.icContextMenu.Size = new System.Drawing.Size(166, 48);
            // 
            // selectDeviceToolStripMenuItem
            // 
            this.selectDeviceToolStripMenuItem.Name = "selectDeviceToolStripMenuItem";
            this.selectDeviceToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.selectDeviceToolStripMenuItem.Text = "Select Device";
            this.selectDeviceToolStripMenuItem.Click += new System.EventHandler(this.selectDeviceToolStripMenuItem_Click);
            // 
            // devicePropertiesToolStripMenuItem
            // 
            this.devicePropertiesToolStripMenuItem.Name = "devicePropertiesToolStripMenuItem";
            this.devicePropertiesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.devicePropertiesToolStripMenuItem.Text = "Device Properties";
            this.devicePropertiesToolStripMenuItem.Click += new System.EventHandler(this.devicePropertiesToolStripMenuItem_Click);
            // 
            // CameraCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCamera);
            this.Name = "CameraCtrl";
            this.Size = new System.Drawing.Size(700, 700);
            this.gbCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ic)).EndInit();
            this.icContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCamera;
        private TIS.Imaging.ICImagingControl _ic;
        private System.Windows.Forms.ContextMenuStrip icContextMenu;
        private System.Windows.Forms.ToolStripMenuItem selectDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devicePropertiesToolStripMenuItem;
        private System.Windows.Forms.Timer timerGPIn;
    }
}
