using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Warrior;
using log4net;
using log4net.Config;

namespace Service
{
    public class Program
    {
        private static ILog Log;
        static void Main(string[] args)
        {
            Log = LogManager.GetLogger("InfrastructureLogger");
            XmlConfigurator.Configure(new FileInfo("..\\..\\App.config"));
            var restartDelay = (int)TimeSpan.FromMinutes(1).TotalMinutes;

            HostFactory.Run(config =>
            {
                config.Service<Business>(svc =>
                {
                    svc.ConstructUsing(s => new Business());
                    svc.WhenStarted(s => s.Start());
                    svc.WhenStopped(s => s.Stop());
                });
                Log.Info("Program is working");
                config.SetServiceName("MyService");
                config.SetDisplayName("My service");
                config.SetDescription("My service via Topshelf");
                config.RunAsLocalService();
                config.DependsOnEventLog();
                config.StartAutomatically();
                config.EnableServiceRecovery(recovery => recovery.RestartService(restartDelay));
            });
        }
    }
}
