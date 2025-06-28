using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TIS;
using TIS.Imaging;
using System.Timers;

namespace DevLost
{
    class Program
    {
        ICImagingControl ic = new ICImagingControl();
        bool deviceListChanged = false;
        Timer recoveryTimer = new Timer(1000);
        int timeElapsed = 0;
        static void Main(string[] args)
        {
            var mc = new Program();
            mc.setup();
        }

        public void setup()
        {
            ic.DeviceLost += DeviceLostHandler;
            Console.WriteLine("Opening Device");
            ic.Device = ic.Devices[0];
            ic.DeviceListChanged += ImagingControl_DeviceListChanged;
            Console.WriteLine($"{ic.Device.ToString()} Opened");
            Console.WriteLine("Disconnect Device now");
            recoveryTimer.Elapsed += OnTimedEvent;
            Console.ReadKey();
        }

        private void ImagingControl_DeviceListChanged(object sender, EventArgs e)
        {
            deviceListChanged = true;
        }

        void DeviceLostHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Device Lost");
            // Do your Device Lost Action here:
            recoveryTimer.Start();

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timeElapsed++;
            if (deviceListChanged == true && ic.Devices.Length != 0)
            {
                ic.Device = ic.Devices[0];
                Console.WriteLine($"{ic.Device.ToString()} Opened");
                deviceListChanged = false;
                recoveryTimer.Stop();
                timeElapsed = 0;
            } else
            {
                if (timeElapsed > 15)
                {
                    Console.WriteLine("No device found after 15 Sec. Check Camera again");
                }
            }
            
        }
    }
}

