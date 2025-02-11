using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TIS.Imaging;
using System.Timers;
using Silvia_s_Capture;

namespace CameraCtrl
{
     public partial class CameraCtrl : UserControl
    {
        private int _Number;
        private int _videocount = 0;
        private bool _capture = false;
       
        // private static string _DataDir = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        //  "SilviasCapture\\");
        private static string _DataDir =  "DeviceData\\";


        private String _videofilename = "";
        private String _csvfilename = "";
        private DateTime _receivedTimestamp;
        private StringBuilder _csv;

        private MFTestSharp.H264Writer _writer;
        
        private FrameQueueSink _sink;

        public CameraCtrl(int i)
        {
            if (!System.IO.Directory.Exists(_DataDir))
                System.IO.Directory.CreateDirectory(_DataDir);

            InitializeComponent();

            timerGPIn.Interval = 50;
            timerGPIn.Enabled = false;

            _Number = i;
            gbCamera.Text = String.Format("Camera {0}", _Number +1);

            _sink = new TIS.Imaging.FrameQueueSink((img) => ProcessImage(img), MediaSubtypes.RGB32, 5);
            _ic.Sink = _sink;
            try
            {
                _ic.LoadDeviceStateFromFile(Path.Combine(_DataDir, String.Format("device{0}.xml", _Number)), true);
                StartDevice();
            }
            catch {
                if (!_ic.DeviceValid)
                {
                    _ic.ShowDeviceSettingsDialog();
                    _ic.SaveDeviceStateToFile(Path.Combine(_DataDir, String.Format("device{0}.xml", _Number)));
                    StartDevice();
                    
                }
            
            }

          _ic.LiveDisplayDefault = false; //Change by Silvia
           
          _ic.LiveDisplayWidth = _ic.Width;//Change by Silvia
           _ic.LiveDisplayHeight = _ic.Height;//Change by Silvia
           
        }

        private TIS.Imaging.FrameQueuedResult ProcessImage(IFrameQueueBuffer imgBuffer)
        {
            if (_capture)
            {
                _receivedTimestamp = DateTimeHighResWin7.Now;
                BeginInvoke(new SaveImageDelegate(SaveImage), imgBuffer);
                return TIS.Imaging.FrameQueuedResult.SkipReQueue;
            }
            else
            {
                return TIS.Imaging.FrameQueuedResult.ReQueue;
            }
        }

        public delegate void SaveImageDelegate(IFrameQueueBuffer imgBuffer);
        private void SaveImage(IFrameQueueBuffer imgBuffer)
        {
           
          
            if (_capture)
            {

                Font font = (_ic.LiveDisplayOutputWidth == 1024) ? new Font("Times New Roman", 30, FontStyle.Bold, GraphicsUnit.Pixel) : new Font("Times New Roman", 60, FontStyle.Bold, GraphicsUnit.Pixel); //for 2000 resolution
               
                
                string time = _receivedTimestamp.ToString("dd/M/yyyy HH:mm:ss.fff");
                //add silvia
                Size sizeOfText = TextRenderer.MeasureText(time, font);
                //
                //Console.WriteLine(time); //close by Silvia
                Image currentpicture = imgBuffer.CreateBitmapWrap();
                Graphics g = Graphics.FromImage(currentpicture);
                //add Silvia background on the timestamp

                Rectangle rect = (_ic.LiveDisplayOutputWidth == 1024) ? new Rectangle(new Point(0, 950), sizeOfText) : new Rectangle(new Point(0, 1900), sizeOfText); 

                //  Rectangle rect = new Rectangle(new Point(0, 1900), sizeOfText);
               // Rectangle rect = new Rectangle(new Point(0, 950), sizeOfText);
                g.FillRectangle(Brushes.Black, rect);

                if (_ic.LiveDisplayOutputWidth == 1024)
                {
                    g.DrawString(time, font, Brushes.White, new System.Drawing.Point(0, 950));
                } else
                {
                    g.DrawString(time, font, Brushes.White, new System.Drawing.Point(0, 1900));
                }

                //
               // 
               
                g.Dispose();

               
                
                    _writer.Write(imgBuffer);

                    string first = _receivedTimestamp.ToString("dd/M/yyyy");
                    string second = _receivedTimestamp.ToString("HH:mm:ss.fff");
                    var newLine = string.Format("{0},{1}", first, second);
                    _csv.AppendLine(newLine);
                
            }

            _sink.QueueBuffer(imgBuffer);
        }

        private void selectDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopDevice();

            _ic.ShowDeviceSettingsDialog();

            if (_ic.DeviceValid)
            {
                _ic.SaveDeviceStateToFile(System.IO.Path.Combine(_DataDir, String.Format("device{0}.xml", _Number)));
                StartDevice();
            }

        }

        private void devicePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ic!= null && _ic.DeviceValid)
            {
                _ic.ShowPropertyDialog();
                _ic.SaveDeviceStateToFile(Path.Combine(_DataDir, String.Format("device{0}.xml", _Number)));
            }
        }

        internal void prepareCapture(string imagePath)
        {
            _videocount++;
            _capture = false;
            int BITRATE = 60 * 1000000;
           // int BITRATE = 60 * 100000;
            //create name for each camera


            _videofilename = System.IO.Path.Combine(imagePath, String.Format("video_{0:00}_{1:000}.mp4", _Number + 1, _videocount));
                _csvfilename = System.IO.Path.Combine(imagePath, String.Format("video_{0:00}_{1:000}.csv", _Number + 1, _videocount));
        

            _writer = new MFTestSharp.H264Writer(_videofilename, _sink.OutputFrameType, (int)_ic.DeviceFrameRate, BITRATE);
           
            _csv = new StringBuilder();
            _writer.Begin();
        }

        internal void prepareCaptureIntervals(string imagePath, string ImagePath_additional_Camera, DateTime StartRecordTime, int num_camera)
        {
            int BITRATE;
            _videocount++;
            _capture = false;
            // int BITRATE = 60 * 1000000;
            // int BITRATE = 60 * 250000;
            // int BITRATE = 60 * 500000;
            // int BITRATE = 40 * 1000000;
           
            if (_ic.LiveDisplayOutputWidth == 1024) {
                BITRATE = 60 * 250000;
            }
            else if(_ic.Width == 2000) {
                BITRATE = 60 * 1000000;
            }
            else
            {
                BITRATE = 60 * 1000000;
            }

            //create name for each camera
            //Add by Silvia

            try
            {
                StopDevice();
            }
            catch { };
            try
            {
                StartDevice();
            }
            catch { }
            //Add by Silvia

            if (num_camera == 0)
            {
                string timeTitle = StartRecordTime.ToString("dd.M.yyyy- HH.mm.ss.fff");
                string FileToSaveVideo = timeTitle + "(Camera-1)" + ".mp4";
                string FileToSaveCsv = timeTitle + "(Camera-1)" + ".csv";
                // create directory for each day
                string nameDir = StartRecordTime.ToString("dd.MM.yyyy");
                string imagePathFinal = imagePath + '\\' + nameDir;
                imagePath = imagePathFinal;
                //verify if directory exists
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }

                //
                _videofilename = System.IO.Path.Combine(imagePath, FileToSaveVideo);
                _csvfilename = System.IO.Path.Combine(imagePath, FileToSaveCsv);

               // _videofilename = System.IO.Path.Combine(imagePath, String.Format("video_{0:00}_{1:000}.mp4", _Number + 1, _videocount));
               // _csvfilename = System.IO.Path.Combine(imagePath, String.Format("video_{0:00}_{1:000}.csv", _Number + 1, _videocount));
            } else if(num_camera == 1)
            {
                string timeTitle = StartRecordTime.ToString("dd.M.yyyy- HH.mm.ss.fff");
                string FileToSaveVideo = timeTitle + "(Camera-2)" + ".mp4";
                string FileToSaveCsv = timeTitle + "(Camera-2)" + ".csv";
                // create directory for each day
                string nameDir = StartRecordTime.ToString("dd.MM.yyyy");
                string imagePathFinal = ImagePath_additional_Camera + '\\' + nameDir;
                ImagePath_additional_Camera = imagePathFinal;
                //verify if directory exists
                if (!Directory.Exists(ImagePath_additional_Camera))
                {
                    Directory.CreateDirectory(ImagePath_additional_Camera);
                }

                _videofilename = System.IO.Path.Combine(ImagePath_additional_Camera, FileToSaveVideo);
                _csvfilename = System.IO.Path.Combine(ImagePath_additional_Camera, FileToSaveCsv);
            }

            _writer = new MFTestSharp.H264Writer(_videofilename, _sink.OutputFrameType, (int)_ic.DeviceFrameRate, BITRATE);
            _csv = new StringBuilder();
            _writer.Begin();
        }

        internal void startCapture()
        {
           
            //Silvia
            _capture = true;
          //  _sink.SinkModeRunning = true;//silvia
            
        }

        internal void stopCapture()
        {
            _capture = false;
            //  _sink.SinkModeRunning = false; //Silvia
           
            
            System.Threading.Thread.Sleep(100);
            _writer.End();
            System.IO.File.WriteAllText(_csvfilename, _csv.ToString());
          
        }

        public void StartDevice()
        {
            if (_ic.DeviceValid)
            {
                gbCamera.Text = _ic.DeviceCurrent.Name + " - " + _ic.DeviceCurrent.GetSerialNumber();
                _ic.LiveStart();
            }
            else
                gbCamera.Text = "No camera";
        }


        public void StopDevice()
        {
            _ic.LiveStop();
        }

        private void _ic_Load(object sender, EventArgs e)
        {

        }
    }
}
