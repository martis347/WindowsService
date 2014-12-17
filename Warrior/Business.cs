using System;
using System.IO;
using System.Threading;
using log4net;
using log4net.Config;

namespace Warrior
{
    public class Business
    {
        private static ILog Log;
        public Business()
        {
            Log = LogManager.GetLogger("BusinessLogger");
            XmlConfigurator.Configure(new FileInfo("..\\..\\App.config"));
        }

        
        private bool write = true;
        public void Start()
        {
            Log.Info("Program start!");
            while (write)
            {
                Console.WriteLine("They see me runnin', they hatin'");
                Thread.Sleep(1000);         
            }
        }
        public void Stop()
        {
            Log.Info("Program stop!");
            write = false;
        }
    }
}
