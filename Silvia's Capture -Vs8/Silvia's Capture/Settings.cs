using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Settings
{
    public class Settings
    {
        private int _Controls;
        private String _XMLFileName = "";
        private String _Prefix = "";
        private String _DeviceName = "";
        private String _ImagePath = "";
        private String _ImagePath_additional_Camera = "";
        private bool _ControlsCheck;
        public DateTime _TheDate;
        public DateTime _TheTime;
        public Settings()
        {
            InitVariables("settings.xml");
        }

        public Settings(String FileName)
        {
            InitVariables(FileName);
        }

        private void InitVariables(String FileName)
        {
            
            _Controls = 1;
            _XMLFileName = FileName;
            _ImagePath = "";
            _ImagePath_additional_Camera = "";
            _ControlsCheck = false;
            _TheDate = new DateTime(2022, 01, 01);
            _TheTime = new DateTime(2022,01,01,10,00,00);

        }

       
        public int Controls
        {
            get { return _Controls; }
            set { _Controls = value; }
        }
        public String DeviceName
        {
            get { return _DeviceName; }
            set { _DeviceName = value; }
        }
        public String ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public String ImagePath_additional_Camera
        {
            get { return _ImagePath_additional_Camera; }
            set { _ImagePath_additional_Camera = value; }
        }


        public DateTime TheDate
        {
            get { return _TheDate; }
            set { _TheDate = value; }
        }

        public DateTime TheTime
        {
            get { return _TheTime; }
            set { _TheTime = value; }
        }
        public bool ControlsCheck
        {
            get { return _ControlsCheck; }
            set { _ControlsCheck = value; }
        }
        public String Prefix
        {
            get { return _Prefix; }
            set { _Prefix = value; }
        }
   


        private String GetFileName()
        {
            String FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            FileName = Path.Combine(FileName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            if (!Directory.Exists(FileName))
            {
                Directory.CreateDirectory(FileName);
            }
            return Path.Combine(FileName, _XMLFileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SettingsFile"></param>
        /// <returns></returns>
        private XmlDocument OpenSettings(String SettingsFile)
        {
            XmlDocument Settings = new XmlDocument();
            if (File.Exists(SettingsFile))
            {
                try
                {
                    Settings.Load(SettingsFile);
                }
                catch { };
            }
            return Settings;
        }

        public void Restore()
        {
            XmlDocument XML = OpenSettings(GetFileName());
            XmlNode root = XML.FirstChild;
            if (root != null)
            {
               
                _Prefix = getSetting(root, "prefix", _Prefix);
                _DeviceName = getSetting(root, "devicename", _DeviceName);
                _ImagePath = getSetting(root, "imagepath", _ImagePath);
                ImagePath_additional_Camera = getSetting(root, "ImagePath_additional_Camera", ImagePath_additional_Camera);
                try
                {
                    _Controls = System.Convert.ToInt32(getSetting(root, "controls", _Controls.ToString()));
                }
                catch { }
            }
        }

        private string getSetting(XmlNode root, String x, String y)
        {
            XmlNode node = root.SelectSingleNode(x);
            if (node != null)
                y = node.InnerText;
            return y;
        }

        public void Save()
        {
            XmlDocument XML = new XmlDocument();
            XmlNode root = XML.CreateElement("settings");
            XML.AppendChild(root);
            XmlNode node = XML.CreateElement("controls");
            node.InnerText = _Controls.ToString();
            root.AppendChild(node);

            node = XML.CreateElement("prefix");
            node.InnerText = _Prefix;
            root.AppendChild(node);

            node = XML.CreateElement("devicename");
            node.InnerText = _DeviceName;
            root.AppendChild(node);
            node = XML.CreateElement("imagepath");
            node.InnerText = _ImagePath;
            root.AppendChild(node);

            node = XML.CreateElement("ImagePath_additional_Camera");
            node.InnerText = _ImagePath_additional_Camera;
            root.AppendChild(node);

            XML.Save(GetFileName());

        }

        public void changeFilename(String newFileName)
        {
            _XMLFileName = newFileName;
        }
    }
}
