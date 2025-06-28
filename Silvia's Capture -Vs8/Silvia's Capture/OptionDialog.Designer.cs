using System.Windows.Forms;

namespace MultiCameraDisplay
{
    partial class OptionDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCameras = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_sheet = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPath1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button_init_Camera1 = new System.Windows.Forms.Button();
            this.button_init_Camera2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Update = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save camera 1:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(110, 43);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(219, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(335, 41);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(822, 187);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(966, 187);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Count of cameras:";
            // 
            // tbCameras
            // 
            this.tbCameras.Location = new System.Drawing.Point(111, 6);
            this.tbCameras.Name = "tbCameras";
            this.tbCameras.Size = new System.Drawing.Size(41, 20);
            this.tbCameras.TabIndex = 6;
            this.tbCameras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCameras.TextChanged += new System.EventHandler(this.tbCameras_TextChanged);
            // 
            // button_load
            // 
            this.button_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_load.Location = new System.Drawing.Point(303, 200);
            this.button_load.Margin = new System.Windows.Forms.Padding(2);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(258, 25);
            this.button_load.TabIndex = 10;
            this.button_load.Text = "2-  Load Schedule for each camera";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Change needs a program restart";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView1.Location = new System.Drawing.Point(46, 229);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.Size = new System.Drawing.Size(863, 277);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Click += new System.EventHandler(this.SelectionSchedule_Click);
            // 
            // textBox_sheet
            // 
            this.textBox_sheet.DisplayMember = "No selection";
            this.textBox_sheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox_sheet.FormattingEnabled = true;
            this.textBox_sheet.Items.AddRange(new object[] {
            "No selection",
            "Camera1",
            "Camera2"});
            this.textBox_sheet.Location = new System.Drawing.Point(35, 200);
            this.textBox_sheet.Name = "textBox_sheet";
            this.textBox_sheet.Size = new System.Drawing.Size(253, 26);
            this.textBox_sheet.TabIndex = 14;
            this.textBox_sheet.Text = "No selection";
            this.textBox_sheet.SelectedIndexChanged += new System.EventHandler(this.textBox_sheet_SelectedIndexChanged);
            this.textBox_sheet.Click += new System.EventHandler(this.SelectionSchedule_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Save camera 2:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxPath1
            // 
            this.textBoxPath1.Location = new System.Drawing.Point(110, 83);
            this.textBoxPath1.Name = "textBoxPath1";
            this.textBoxPath1.ReadOnly = true;
            this.textBoxPath1.Size = new System.Drawing.Size(219, 20);
            this.textBoxPath1.TabIndex = 16;
            this.textBoxPath1.TextChanged += new System.EventHandler(this.textBoxPath1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_init_Camera1
            // 
            this.button_init_Camera1.Location = new System.Drawing.Point(448, 33);
            this.button_init_Camera1.Name = "button_init_Camera1";
            this.button_init_Camera1.Size = new System.Drawing.Size(113, 38);
            this.button_init_Camera1.TabIndex = 18;
            this.button_init_Camera1.Text = "Initialization\r\nCamera 1\r\n";
            this.button_init_Camera1.UseVisualStyleBackColor = true;
            this.button_init_Camera1.Click += new System.EventHandler(this.button_init_Camera1_Click);
            // 
            // button_init_Camera2
            // 
            this.button_init_Camera2.Location = new System.Drawing.Point(604, 33);
            this.button_init_Camera2.Name = "button_init_Camera2";
            this.button_init_Camera2.Size = new System.Drawing.Size(99, 38);
            this.button_init_Camera2.TabIndex = 19;
            this.button_init_Camera2.Text = "Initialization\r\nCamera 2\r\n";
            this.button_init_Camera2.UseVisualStyleBackColor = true;
            this.button_init_Camera2.Click += new System.EventHandler(this.button_init_Camera2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dateTimePicker1.Location = new System.Drawing.Point(11, 154);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 20;
            this.dateTimePicker1.Value = new System.DateTime(2023, 2, 19, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_2);
            // 
            // Update
            // 
            this.Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Update.Location = new System.Drawing.Point(356, 523);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(179, 23);
            this.Update.TabIndex = 21;
            this.Update.Text = "3-  Update default schedule";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.update_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox2.ForeColor = System.Drawing.Color.Purple;
            this.textBox2.Location = new System.Drawing.Point(15, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 19);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "1-  Set the time to begin experiment\r\n";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button4.Location = new System.Drawing.Point(630, 521);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(279, 26);
            this.button4.TabIndex = 23;
            this.button4.Text = "4-  Save your schedule in your personal folders";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Save_click);
            // 
            // OptionDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1387, 661);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button_init_Camera2);
            this.Controls.Add(this.button_init_Camera1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxPath1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_sheet);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.tbCameras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionDialog";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.OptionDialog_Load);
            this.DoubleClick += new System.EventHandler(this.SelectionSchedule_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCameras;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private ComboBox textBox_sheet;
        private Label label4;
        private TextBox textBoxPath1;
        private Button button2;
        private Button button_init_Camera1;
        private Button button_init_Camera2;
        private DateTimePicker dateTimePicker1;
        private Button Update;
        private TextBox textBox2;
        private Button button4;
    }
}