using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CameraCtrl;
using MultiCameraDisplay;
using NAudio.MediaFoundation;
using System.Globalization;


namespace Silvia_s_Capture
{
    public partial class frmMain : Form
    {
        private List<CameraCtrl.CameraCtrl> _cameras = new List<CameraCtrl.CameraCtrl>();
        private DataTable _schedule = new DataTable();
        private DataTable _schedule_otherCamera = new DataTable();
        private Settings.Settings _settings = new Settings.Settings();
        //ADDED_BY_IRIS
        // public List<string> ScheduleList = new List<string>();
        // public List<string> DateList = new List<string>();
        private int i = 0;
        public List<DataTable> _allSchedule = new List<DataTable>();

        //public DateTime[] StartRecordTime = { new DateTime(), new DateTime() };//gives no real time
        //public DateTime[] StopRecordTime = { new DateTime(), new DateTime() };

        //
        private Queue<DateTime>[] collectionTime = { new Queue<DateTime>(), new Queue<DateTime>() }; //collects all the time to get-create a queque for eachcamera

        //

        public bool[] recordingIsOn = { false, false };
        private DateTime[] _startRecordTime = { new DateTime(), new DateTime() };
        private DateTime[] _stopRecordTime = { new DateTime(), new DateTime() };


        //public int[] number_day = { 1, 1 };
        //public int[] number_time = { 0, 0 };
        //public int[] number_columns = { 0, 0 };
        //public int[] number_rows = { 0, 0 };

        //public int number_columns = 0;
        // public int number_rows = 0;


        // public int number_day = 1;
        // public int number_time = 0;

        // public bool recordingIsOn = false;
        // public DateTime StartRecordTime;
        // public DateTime StopRecordTime;
        public frmMain()
        {
            MediaFoundationApi.Startup();
            InitializeComponent();
            _settings.Restore();
            this._startRecordTime[0] =DateTime.ParseExact("01/01/0001 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
            this._stopRecordTime[0] = DateTime.ParseExact("01/01/0001 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
            this._startRecordTime[1] = DateTime.ParseExact("01/01/0001 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
            this._stopRecordTime[1] = DateTime.ParseExact("01/01/0001 00:00:00", "dd/MM/yyyy HH:mm:ss", null);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            int l = 0;
            int h = -1;
            int cols = 2;

            if (_settings.Controls > 12)
                cols = 5;

            for (int i = 0; i < _settings.Controls; i++)
            {

                CameraCtrl.CameraCtrl cam = new CameraCtrl.CameraCtrl(i);
                cam.Parent = this;
                if (i % cols == 0)
                {
                    l = 0;
                    h++;
                }
                cam.Left = 10 + l * cam.Width;
                cam.Top = 15 + menuStrip1.Height + h * cam.Height;
                l++;
                _cameras.Add(cam);
            }

            this.Width = cols * _cameras[0].Width + 40;
            this.Height = (h + 1) * _cameras[0].Height + 70 + menuStrip1.Height;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _settings.Controls; i++)
            {
                _cameras[i].StopDevice();
            }
            Close();
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _settings.Controls; i++)
            {
                _cameras[i].StopDevice();
            }
            MultiCameraDisplay.OptionDialog options = new MultiCameraDisplay.OptionDialog(_settings);
            if (options.ShowDialog() == DialogResult.OK)
            {
                //ADDED_BY_IRIS           
                _schedule = options.TableFinal;
                _schedule_otherCamera = options.TableFinal_otherCamera;
                _allSchedule.Add(_schedule);
                _allSchedule.Add(_schedule_otherCamera);
                _settings.Save();
            }
            for (int i = 0; i < _settings.Controls; i++)
            {
                _cameras[i].StartDevice();
            }

        }

        private void prepareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _settings.Controls; i++)
            {
                Console.WriteLine(_settings.Controls);
                _cameras[i].prepareCapture(_settings.ImagePath);
            }
            startToolStripMenuItem.Enabled = true;
            prepareToolStripMenuItem.Enabled = false;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            for (int i = 0; i < _settings.Controls; i++)
            {
                _cameras[i].startCapture();
            }

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopToolStripMenuItem.Enabled = false;
            prepareToolStripMenuItem.Enabled = true;
            for (int i = 0; i < _settings.Controls; i++)
            {
                _cameras[i].stopCapture();
            }

        }

        private void startScheduleRecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ADDED_BY_IRIS
            //make here some kind of checking:
            startScheduleRecordingToolStripMenuItem.Enabled = false;
            stopScheduleRecordingToolStripMenuItem.Enabled = true;

            if (_schedule.Rows.Count > 0)
            {
                for (int i = 0; i < _settings.Controls; i++)
                {
                    try
                    {

                        RetrieveTimes(_allSchedule[i], i);

                        if (this.collectionTime[i].Count != 0)
                        {
                            this._startRecordTime[i] = this.collectionTime[i].Dequeue(); //returns the first element and removes it
                            this._stopRecordTime[i] = this._startRecordTime[i].AddMinutes(10); // add 10 minutes
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error");
                    }
                }
     

            }

        }
       
        private void RetrieveTimes(DataTable schedule, int num_camera)
        {
            string dateString = "";
            DateTime recordTime;

           

            if (schedule != null)
            {
                foreach (DataColumn column in schedule.Columns)
                {

                    if (column.ColumnName != "Begin recording")
                    {
                        foreach (DataRow row in schedule.Rows) //go through each row
                        {
                            if (String.Equals(row[column.ColumnName].ToString(), "1")) // only one is taken
                            {
                                dateString = column.ColumnName + " " + row["Begin recording"].ToString();
                                Console.WriteLine(dateString);


                                recordTime = DateTime.ParseExact(dateString, "dd/MM/yyyy HH:mm:ss", null);


                                // add to the queque
                                collectionTime[num_camera].Enqueue(recordTime);
                                //  StopRecordTime[num_cam] = StartRecordTime[num_cam].AddMinutes(10);

                            }
                        }
                    }

                }
            }
            else
            {
                throw new NullReferenceException("Forget to set up one of the schedule-Please set up the schedule for both cameras");
            }
        }


        //timer

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            for (int i = 0; i < _settings.Controls; i++)
            {
                DateTime dtnow = DateTimeHighResWin7.Now;
               
               

               if (!recordingIsOn[i] && dtnow >= this._startRecordTime[i] && dtnow <= this._stopRecordTime[i])
                {
                    StartRecordingNow(this._startRecordTime[i], i);

                    recordingIsOn[i] = true;
                    if (i == 0)
                    {
                        RecordingLable.Text = "RECORDING IS ON";
                    }
                    else if (i == 1)
                    {
                        RecordingLabel.Text = "RECORDING IS ON";
                    }
                }
                else if (recordingIsOn[i] && dtnow > this._stopRecordTime[i])
                {
                    StopRecordingNow(i);
                    recordingIsOn[i] = false;
                    if (i == 0)
                    {
                        RecordingLable.Text = "Camera 1 Recording IS OFF";
                    }
                    else if (i == 1)
                    {
                        RecordingLabel.Text = "Camera 2 Recording IS OFF";
                    }
                    //get new starting time
                    if (this.collectionTime[i].Count != 0)
                    {
                        this._startRecordTime[i] = this.collectionTime[i].Dequeue(); //returns the first element and removes it
                        this._stopRecordTime[i] = this._startRecordTime[i].AddMinutes(10); // add 10 minutes
                    }
                }
                //information about starting and stopping time
                if (i == 0)
                {
                    StartedLabel.Text = this._startRecordTime[i].ToString("dd.MM.yyy") + " " + "Start Record at: " + this._startRecordTime[i].ToShortTimeString();

                    StoppedLable.Text = "Stop Record  at: " + this._stopRecordTime[i].ToShortTimeString();
                }
                else if (i == 1)
                {
                    StartingLabel.Text = this._startRecordTime[i].ToString("dd.MM.yyy") + " " + "Start Record at: " + this._startRecordTime[i].ToShortTimeString();

                    StoppingLabel.Text = "Stop Record  at: " + this._stopRecordTime[i].ToShortTimeString();
                }

            }
        }

        
      public void StartRecordingNow(DateTime startRecordTime,int i)
        {
            
               _cameras[i].prepareCaptureIntervals(_settings.ImagePath,_settings.ImagePath_additional_Camera, this._startRecordTime[i], i);

               _cameras[i].startCapture();
           
        }

        public void StopRecordingNow(int i)
        {
          
                _cameras[i].stopCapture();
          
        }

        private void stopScheduleRecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startScheduleRecordingToolStripMenuItem.Enabled = true;
            stopScheduleRecordingToolStripMenuItem.Enabled = false;
            for (int num_camera = 0; num_camera < 2; num_camera++)
            {
                // clean queue
                //assure to clean deque before each time
                if (collectionTime[num_camera].Count > 0)
                {
                    collectionTime[num_camera].Clear();
                }
               
            }
            //clear the list of all schedule
            _allSchedule.Clear();
        }
    }
}
