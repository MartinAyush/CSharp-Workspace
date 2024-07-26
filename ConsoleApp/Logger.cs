using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace TestApplication
{
    public class Logger
    {
        private static string _logFile = string.Empty;

        public Logger()
        {
            CreateLogFile();
        }

        private void CreateLogFile()
        {
            string date = DateTime.Now.ToString("MM-dd-yyyy");
            string completeLogPath = string.Format(Directory.GetCurrentDirectory() + "\\DatabaseRecoveryToolLog-{0}.log", date);
            _logFile = completeLogPath;

            if(!File.Exists(_logFile))
                File.Create(completeLogPath).Close();
        }

        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(_logFile, true))
            {
                writer.WriteLine(message);
            }
        }

        //static void ConfigureTrace()
        //{
        //    Trace.Listeners.Clear();

        //    DateTime now = DateTime.Now;
        //    string filename = Path.GetTempPath() + string.Format("RemoveVeriato_{0:d4}{1:d2}{2:d2}{3:d2}{4:d2}{5:d2}.log", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);

        //    TextWriterTraceListener twtl = new TextWriterTraceListener(filename);
        //    twtl.Name = "TextLogger";
        //    twtl.TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime;

        //    ConsoleTraceListener ctl = new ConsoleTraceListener(false);
        //    ctl.TraceOutputOptions = TraceOptions.DateTime;

        //    Trace.Listeners.Add(twtl);
        //    Trace.Listeners.Add(ctl);
        //    Trace.AutoFlush = true;
        //}

        static void ConfigureTrace()
        {
            Trace.Listeners.Clear();

            string filename = Directory.GetCurrentDirectory() + string.Format("\\CustomLogFile{0}", DateTime.Now.ToString("dd/MM/yyyy"));

            TextWriterTraceListener twtl = new TextWriterTraceListener(filename);
            twtl.Name = "TextLogger";
            twtl.TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime;

            ConsoleTraceListener ctl = new ConsoleTraceListener(false);
            ctl.TraceOutputOptions = TraceOptions.DateTime;

            Trace.Listeners.Add(twtl);
            Trace.Listeners.Add(ctl);
            Trace.AutoFlush = true;
        }

    }
}
