using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using NLog.Extensions.Logging;

namespace SessionSwitchTest
{
    internal class Program
    {
        static AutoResetEvent autoEvent = new AutoResetEvent(false);
        static ILogger<Program> logger;

        static void Main(string[] args)
        {
            using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddNLog());
            logger = loggerFactory.CreateLogger<Program>();

            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

            autoEvent.WaitOne();
        }

        private static void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            logger.LogDebug("{SessionSwitch}", e.Reason);
        }
    }
}
