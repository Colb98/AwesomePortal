using System;
using System.Diagnostics;
using System.IO;

namespace AwesomePortal
{
    public abstract class LogBase
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message);
    }

    public class FileLogger : LogBase
    {
        public string filePath = "./log" + System.DateTime.Today.ToString("yyyyMMdd") + ".txt";
        public override void Log(string message)
        {
            lock (lockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }
    
    public class EventLogger : LogBase
    {
        public override void Log(string message)
        {
            lock (lockObj)
            {
                EventLog m_EventLog = new EventLog("");
                m_EventLog.Source = "IDGEventLog";
                m_EventLog.WriteEntry(message);
            }
        }
    }
    public static class LogHelper
    {
        private static LogBase logger = null;

        // Log event by EventLogger by default
        public static void Log(string message) => Log(LogTarget.File, message);
        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;
                case LogTarget.EventLog:
                    logger = new EventLogger();
                    logger.Log(message);
                    break;
                default:
                    return;
            }
        }
    }
    public enum LogTarget
    {
        File, EventLog
    }
}