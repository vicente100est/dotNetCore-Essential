using NLog;
using System;
using System.IO.Compression;

namespace Zip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string source = null;
            string target = null;

            if(args == null || args.Length != 2)
            {
                System.Console.WriteLine("Uso: <fuente> <destino.zip>");
                return;
            }

            source = args[0];
            target = args[1];

            ConfigureLog();

            try
            {
                ZipFile.CreateFromDirectory(source, target);
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
            }
        }

        public static void ConfigureLog()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "logs.txt" };

            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            LogManager.Configuration = config;
        }
    }
}
