using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace MultiCameraDisplay
{
    public partial class OptionDialog : Form
    {
        private Settings.Settings _programSettings;
        public DataTable TableFinal { get => tableFinal; set => tableFinal = value; }
        public List<string> ScheduleList = new List<string>();
        private DataTable tableFinal;
        public DataTable TableFinal_otherCamera { get => tableFinal_otherCamera; set => tableFinal_otherCamera = value; }
        private DataTable tableFinal_otherCamera;
        private int _Number = 0;
        private string _pathFileSchedule;
        private string _currentDirectory;

        public OptionDialog(Settings.Settings programSettings)
        {
            InitializeComponent();
            _programSettings = programSettings;

            tbCameras.Text = _programSettings.Controls.ToString();
            textBoxPath.Text = _programSettings.ImagePath;
            textBoxPath1.Text = _programSettings.ImagePath_additional_Camera;
            // this._pathFileSchedule = "D:\\ScheduleCameras\\Schedule.xlsx";
            this._currentDirectory = System.IO.Directory.GetCurrentDirectory();
            
            this._pathFileSchedule = this._currentDirectory + "\\ScheduleCameras\\Schedule.xlsx";
            //       checkBox1.Checked = _programSettings.ControlsCheck;
            dateTimePicker1.Value = DateTime.Now; 
            //  dateTimePicker2.Value = _programSettings.TheTime;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBoxPath.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _programSettings.ImagePath = textBoxPath.Text;
            _programSettings.ImagePath_additional_Camera = textBoxPath1.Text;
            //    _programSettings.ControlsCheck = checkBox1.Checked;
            // _programSettings.TheDate = dateTimePicker1.Value;
            //  _programSettings.TheTime = dateTimePicker2.Value;
            try
            {
                _programSettings.Controls = Convert.ToInt32(tbCameras.Text);
            }
            catch { }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void tbCameras_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select file";
            fdlg.InitialDirectory = @"D:\";
            fdlg.FileName = " ";
            fdlg.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                // txtFileName.Text = fdlg.FileName;
                //  Import();
                Application.DoEvents();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OptionDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
              //  this.textBox_pathFile.Text = openFileDialog1.FileName;

            }
        }

        private void textBox_pathFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_load_Click(object sender, EventArgs e)
        {
            string sheetName;
            int count = textBox_sheet.SelectedIndex;

            OleDbConnection myconnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + _pathFileSchedule + ";Extended Properties='Excel 12.0 Xml;HDR=YES';");
            myconnection.Open();


            DataTable dtExcelSchema = myconnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            OleDbCommand cmd = new OleDbCommand();
            for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
            {
                sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                DataTable dt = new DataTable(sheetName);
                cmd.Connection = myconnection;
                textBox_sheet.Items.Add(sheetName);
            }
            textBox_sheet.Text = textBox_sheet.Items[count].ToString();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from [" + textBox_sheet.Text + "$]", myconnection);
            oda.Fill(ds);

            ds.Tables[0].Columns[1].ColumnName = "0";
            ds.Tables[0].Columns[2].ColumnName = "1";
            ds.Tables[0].Columns[3].ColumnName = "2";
            ds.Tables[0].Columns[4].ColumnName = "3";
            ds.Tables[0].Columns[5].ColumnName = "4";
            ds.Tables[0].Columns[6].ColumnName = "5";
            ds.Tables[0].Columns[7].ColumnName = "6";



            ds.Tables[0].Columns[1].ColumnName = dateTimePicker1.Value.ToString("dd/MM/yyy");
            ds.Tables[0].Columns[2].ColumnName = dateTimePicker1.Value.AddDays(1).ToString("dd/MM/yyy");
            ds.Tables[0].Columns[3].ColumnName = dateTimePicker1.Value.AddDays(2).ToString("dd/MM/yyy");
            ds.Tables[0].Columns[4].ColumnName = dateTimePicker1.Value.AddDays(3).ToString("dd/MM/yyy");
            ds.Tables[0].Columns[5].ColumnName = dateTimePicker1.Value.AddDays(4).ToString("dd/MM/yyy");
            ds.Tables[0].Columns[6].ColumnName = dateTimePicker1.Value.AddDays(5).ToString("dd/MM/yyy");
            ds.Tables[0].Columns[7].ColumnName = dateTimePicker1.Value.AddDays(6).ToString("dd/MM/yyy");

            dataGridView1.DataSource = ds.Tables[0];


            if (String.Equals(textBox_sheet.Text, "Camera1"))
            {
                TableFinal = ds.Tables[0];
            }
            else if (String.Equals(textBox_sheet.Text, "Camera2"))
            {
                TableFinal_otherCamera = ds.Tables[0];
            }


            myconnection.Close();
        }






        private void list_sheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_sheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void load_grid(object sender, EventArgs e)
        {
            button_load_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBoxPath1.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxPath1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void textBoxPath1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_init_Camera1_Click(object sender, EventArgs e)
        {
            initDevices(0);
            return;
            TIS.Imaging.ICImagingControl icImagingControl = new TIS.Imaging.ICImagingControl();


            if (!icImagingControl.DeviceValid)

            {

                try
                {
                    icImagingControl.LoadDeviceStateFromFile(this._currentDirectory + "\\DeviceData\\device0.xml", true);
                }
                catch
                {

                }
                icImagingControl.ShowDeviceSettingsDialog();
            }
            if (!icImagingControl.DeviceValid)
            {
                Close();
                return;
            }

            icImagingControl.SaveDeviceStateToFile(this._currentDirectory + "\\DeviceData\\device0.xml");
        }

        private void button_init_Camera2_Click(object sender, EventArgs e)
        {
            initDevices(1);
            return;
            TIS.Imaging.ICImagingControl icImagingControl = new TIS.Imaging.ICImagingControl();


            if (!icImagingControl.DeviceValid)

            {

                try
                {
                    icImagingControl.LoadDeviceStateFromFile(this._currentDirectory + "\\DeviceData\\device1.xml", true);
                }
                catch
                {

                }
                icImagingControl.ShowDeviceSettingsDialog();
            }
            if (!icImagingControl.DeviceValid)
            {
                Close();
                return;
            }
            icImagingControl.SaveDeviceStateToFile(this._currentDirectory + "\\DeviceData\\device1.xml");
        }

        private void initDevices(int number)
        {
            TIS.Imaging.ICImagingControl icImagingControl = new TIS.Imaging.ICImagingControl();
            
            try
            {
                icImagingControl.LoadDeviceStateFromFile($"DeviceData\\device{number}.xml", true);
            }
            catch
            {

            }
            icImagingControl.ShowDeviceSettingsDialog();

            if (icImagingControl.DeviceValid)
            {
                icImagingControl.SaveDeviceStateToFile($"DeviceData\\device{number}.xml");
            }
            // IC will be deleted here, so the camera should be closed.

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_2(object sender, EventArgs e)
        {
            
        }


        /*Update excel file when the user changes the data grid view*/
        private void update_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application excl = new Microsoft.Office.Interop.Excel.Application();
           // excl.Application.Workbooks.Add(this.textBox_pathFile.Text);

            if (String.Equals(textBox_sheet.Text, "Camera1"))
            {
               excl.Application.Workbooks.Open(this._pathFileSchedule);
               excl.Worksheets[1].activate(); 
                
            }
            else if (String.Equals(textBox_sheet.Text, "Camera2"))
            {
                excl.Application.Workbooks.Open(this._pathFileSchedule);
                excl.Worksheets[2].activate();

            }
           
            for (int i = 2; i < dataGridView1.Columns.Count; i++)
            {
                excl.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for(int i=0; i< dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        {
                            excl.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString(); ;
                          
                        }
                    }
            }

            excl.Columns.AutoFit();
            excl.Visible = true;


        }

        /*User saved the excel calendar*/
        private void Save_click(object sender, MouseEventArgs e)
        {
           
           

                Microsoft.Office.Interop.Excel.Application excl = new Microsoft.Office.Interop.Excel.Application();
                excl.Application.Workbooks.Add(this._pathFileSchedule);
            if (String.Equals(textBox_sheet.Text, "Camera1"))
            {
              //  excl.Application.Workbooks.Open(this.textBox_pathFile.Text);
                excl.Worksheets[1].activate();

            }
            else if (String.Equals(textBox_sheet.Text, "Camera2"))
            {
              //  excl.Application.Workbooks.Open(this.textBox_pathFile.Text);
                excl.Worksheets[2].activate();

            }

            for (int i = 2; i < dataGridView1.Columns.Count; i++)
            {
                excl.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        {
                            excl.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString(); ;

                        }
                    }
            }

            excl.Columns.AutoFit();
            excl.Visible = true;


        

    }

        private void SelectionSchedule_Click(object sender, EventArgs e)
        {
          
        }

       
    }
}