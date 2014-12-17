using System;
using System.IO;
using System.Threading;
using log4net;
using log4net.Config;

namespace Warrior
{
    public class Business
    {
        private static ILog _log;
        public Business()
        {
            _log = LogManager.GetLogger("BusinessLogger");
            XmlConfigurator.Configure(new FileInfo("..\\..\\App.config"));
            
        }

        public void Pause()
        {
            //for (int i = 0; i < 15; i++)
            //{
            //    Console.Beep();
            //    Thread.Sleep(100);
            //}
            _log.Info("Program pause!");

        }
        public void Continue()
        {
            for (var i = 0; i < 15; i++)
            {
                Console.Beep();
                Thread.Sleep(100);
            }
            _log.Info("Program continue!");

        }
        private bool write = true;
        public void Start()
        {
            _log.Info("Program start!");

            while (write)
            {
                Console.WriteLine("They see me runnin', they hatin'");
                Console.Beep();
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            _log.Info("Program stop!");
            write = false;
        }

        
    }
}
