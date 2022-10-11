using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

using log4net.Config;

using log4net;

namespace BBS.Common
{
    public class Logger
    {
        public static string CONFIGFILENAME;

        public static string LOGCONFIGTAG;

        public static string DELLOGEXECUT;

        public static ConcurrentDictionary<string, string> _PATH;

        public static string GetConfigFileName()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "\\" + CONFIGFILENAME;
        }

        static Logger()
        {
            CONFIGFILENAME = "Log.xml";
            LOGCONFIGTAG = "log4net";
            DELLOGEXECUT = "";
            _PATH = new ConcurrentDictionary<string, string>();
            XmlDocument xmlDocument = new XmlDocument();
            string configFileName = GetConfigFileName();
            if (File.Exists(configFileName))
            {
                xmlDocument.Load(configFileName);
                XmlNode xmlNode = xmlDocument.SelectSingleNode("//" + LOGCONFIGTAG);
                if (xmlNode != null)
                {
                    XmlConfigurator.Configure((XmlElement)xmlNode);
                }
                else
                {
                    XmlConfigurator.Configure();
                }

                IEnumerable<XElement> source = XElement.Parse(xmlNode.OuterXml).Elements();
                if (source.Where((XElement w) => w.FirstAttribute.Value == "infoAppender").Count() > 0)
                {
                    _PATH.AddOrUpdate("INFO", source.Where((XElement w) => w.FirstAttribute.Value == "infoAppender").FirstOrDefault().Elements()
                        .FirstOrDefault()
                        .LastAttribute.Value, (string key, string value) => value);
                }

                if (source.Where((XElement w) => w.FirstAttribute.Value == "warnAppender").Count() > 0)
                {
                    _PATH.AddOrUpdate("WARN", source.Where((XElement w) => w.FirstAttribute.Value == "warnAppender").FirstOrDefault().Elements()
                        .FirstOrDefault()
                        .LastAttribute.Value, (string key, string value) => value);
                }

                if (source.Where((XElement w) => w.FirstAttribute.Value == "debugAppender").Count() > 0)
                {
                    _PATH.AddOrUpdate("DEBUG", source.Where((XElement w) => w.FirstAttribute.Value == "debugAppender").FirstOrDefault().Elements()
                        .FirstOrDefault()
                        .LastAttribute.Value, (string key, string value) => value);
                }
            }
            else
            {
                XmlConfigurator.Configure();
            }
        }

        public static void LogFileDetele()
        {
            try
            {
                if (_PATH.Count == 0 || DELLOGEXECUT == DateTime.Now.ToString("yyyyMMdd"))
                {
                    return;
                }

                Task.Run(delegate
                {
                    _PATH.ToList().ForEach(delegate (KeyValuePair<string, string> o)
                    {
                        DelLog(o.Value);
                    });
                    DELLOGEXECUT = DateTime.Now.ToString("yyyyMMdd");
                });
            }
            catch (Exception ex)
            {
                Error("LogModule->LogFileDetele:删除日志失败:" + ex.Message);
            }
        }

        private static void DelLog(string v)
        {
            try
            {
                int num = 1;
                if (Directory.Exists(v + DateTime.Now.AddMonths(num).ToString("yyyy-MM")))
                {
                    Directory.GetFiles(v + DateTime.Now.AddMonths(num).ToString("yyyy-MM"), "*.log.*").ToList().ForEach(delegate (string o)
                    {
                        File.Delete(o);
                    });
                }

                if (num == -1)
                {
                    DelLogWithDay(v);
                }
            }
            catch (Exception ex)
            {
                Error("LogModule->LogModule:删除日志失败:" + ex.Message);
            }
        }

        private static void DelLogWithDay(string v)
        {
            int _Days =7;
            if (Directory.Exists(v + DateTime.Now.AddDays(_Days).ToString("yyyy-MM")))
            {
                (from w in Directory.GetFiles(v + DateTime.Now.ToString("yyyy-MM"), "*.log.*")
                 where Convert.ToDateTime(w.Substring((v + DateTime.Now.ToString("yyyy-MM") + "\\").Length, 10)).Date <= DateTime.Now.AddDays(_Days).Date
                 select w).ToList().ForEach(delegate (string o)
                 {
                     File.Delete(o);
                 });
            }
        }

        public static void Info(object message, string logger = "loginfo")
        {
            LogManager.GetLogger(logger).Info(message);
            LogFileDetele();
        }

        public static void Info(object message, Exception exception, string logger = "loginfo")
        {
            LogManager.GetLogger(logger).Info(message, exception);
            LogFileDetele();
        }

        public static void Error(object message, string logger = "logerror")
        {
            LogManager.GetLogger(logger).Error(message);
        }

        public static void Error(object message, Exception exception, string logger = "logerror")
        {
            LogManager.GetLogger(logger).Error(message, exception);
        }

        public static void Warn(object message, string logger = "logwarn")
        {
            LogManager.GetLogger(logger).Warn(message);
            LogFileDetele();
        }

        public static void Warn(object message, Exception exception, string logger = "logwarn")
        {
            LogManager.GetLogger(logger).Warn(message, exception);
            LogFileDetele();
        }

        public static void Debug(object message, string logger = "logdebug")
        {
            ILog logger2 = LogManager.GetLogger(logger);
            if (logger2.IsDebugEnabled)
            {
                logger2.Debug(message);
            }

            LogFileDetele();
        }

        public static void Debug(object message, Exception exception, string logger = "logdebug")
        {
            ILog logger2 = LogManager.GetLogger(logger);
            if (logger2.IsDebugEnabled)
            {
                logger2.Debug(message, exception);
            }

            LogFileDetele();
        }

        public static void Fatal(object message, string logger = "logfatal")
        {
            LogManager.GetLogger(logger).Fatal(message);
        }

        public static void Fatal(object message, Exception exception, string logger = "logfatal")
        {
            LogManager.GetLogger(logger).Fatal(message, exception);
        }

        public static void SettlementLog(object message, string logger = "settlement")
        {
            LogManager.GetLogger(logger).Info(message);
        }
    }
}
