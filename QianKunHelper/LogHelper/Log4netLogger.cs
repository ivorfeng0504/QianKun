using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QianKunHelper.LogHelper
{
    public class Log4netLogger : ILog
    {
        public bool IsDebugEnabled => throw new NotImplementedException();

        public bool IsInfoEnabled => throw new NotImplementedException();

        public bool IsWarnEnabled => throw new NotImplementedException();

        public bool IsErrorEnabled => throw new NotImplementedException();

        public bool IsFatalEnabled => throw new NotImplementedException();
        public log4net.ILog _log = null;
        static Log4netLogger()
        {
            var domain = "log4net";
            var repository = log4net.LogManager.CreateRepository(domain);
            string log4netFile = Path.Combine(Directory.GetCurrentDirectory(), "Config\\log4net.config");
            var fileInfo = new FileInfo(log4netFile);
            log4net.Config.XmlConfigurator.Configure(repository, fileInfo);
        }
        public Log4netLogger(Type t)
        {
            _log = log4net.LogManager.GetLogger(t);
        }
        /// <summary>
        /// //输出到控制台
        /// </summary>
        private static void Diagnostics(object message, Exception exception)
        {
            string msg = (message == null ? string.Empty : message.ToString());
            if (exception != null)
            {
                msg += ", Exception: " + exception.Message;
            }
            System.Diagnostics.Debug.WriteLine(msg);
        }

        /// <summary>
        /// //输出到控制台
        /// </summary>
        private static void DiagnosticsFormat(object message, params object[] args)
        {
            string msg = (message == null ? string.Empty : message.ToString());
            System.Diagnostics.Debug.WriteLine(string.Format(msg, args));
        }
        /// <summary>
        /// 记录Debug消息
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            if (_log.IsDebugEnabled)
            {
                _log.Debug(message);
            }
            else
            {
                Diagnostics(message, null);
            }
        }

        /// <summary>
        /// 记录Debug异常消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(object message, Exception exception)
        {
            if (_log.IsDebugEnabled)
            {
                _log.Debug(message, exception);
            }
            else
            {
                Diagnostics(message, exception);
            }
        }

        /// <summary>
        /// 记录格式化的Debug消息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args)
        {
            if (_log.IsDebugEnabled)
            {
                _log.DebugFormat(string.Format("系统{0},类目{1},", "", "") + format, args);
            }
            else
            {
                DiagnosticsFormat(format, args);
            }
        }

        /// <summary>
        /// 记录错误消息
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            if (_log.IsErrorEnabled)
            {
                _log.Error(message);
            }
            else
            {
                Diagnostics(message, null);
            }
        }

        /// <summary>
        /// 记录错误异常消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(object message, Exception exception)
        {
            if (_log.IsErrorEnabled)
            {
                _log.Error(message, exception);
            }
            else
            {
                Diagnostics(message, exception);
            }
        }

        /// <summary>
        /// 记录错误格式化消息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args)
        {
            if (_log.IsErrorEnabled)
            {
                _log.ErrorFormat(string.Format("系统{0},类目{1},", "", "") + format, args);
            }
            else
            {
                DiagnosticsFormat(format, args);
            }
        }

        /// <summary>
        /// 记录程序致命消息
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            if (_log.IsFatalEnabled)
            {
                _log.Fatal(message);
            }
            else
            {
                Diagnostics(message, null);
            }
        }

        /// <summary>
        /// 记录程序致命异常消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Fatal(object message, Exception exception)
        {
            if (_log.IsFatalEnabled)
            {
                _log.Fatal(message, exception);
            }
            else
            {
                Diagnostics(message, exception);
            }
        }

        /// <summary>
        /// 记录程序致命格式化消息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void FatalFormat(string format, params object[] args)
        {
            if (_log.IsFatalEnabled)
            {
                _log.FatalFormat(string.Format("系统{0},类目{1},", "", "") + format, args);
            }
            else
            {
                DiagnosticsFormat(format, args);
            }
        }

        /// <summary>
        /// 记录运行消息
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            if (_log.IsInfoEnabled)
            {
                _log.Info(message);
            }
            else
            {
                Diagnostics(message, null);
            }
        }

        /// <summary>
        /// 记录运行异常消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(object message, Exception exception)
        {
            if (_log.IsInfoEnabled)
            {
                _log.Info(message, exception);
            }
            else
            {
                Diagnostics(message, exception);
            }
        }

        /// <summary>
        /// 记录运行格式化消息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args)
        {
            if (_log.IsInfoEnabled)
            {
                _log.InfoFormat(string.Format("系统{0},类目{1},", "", "") + format, args);
            }
            else
            {
                DiagnosticsFormat(format, args);
            }
        }

        /// <summary>
        /// 记录警告消息
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            if (_log.IsWarnEnabled)
            {
                _log.Warn(message);
            }
            else
            {
                Diagnostics(message, null);
            }
        }

        /// <summary>
        /// 记录警告异常消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Warn(object message, Exception exception)
        {
            if (_log.IsWarnEnabled)
            {
                _log.Warn(message, exception);
            }
            else
            {
                Diagnostics(message, exception);
            }
        }

        /// <summary>
        /// 记录警告格式化消息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args)
        {
            if (_log.IsWarnEnabled)
            {
                _log.WarnFormat(string.Format("系统{0},类目{1},", "", "") + format, args);
            }
            else
            {
                DiagnosticsFormat(format, args);
            }
        }

        public void DebugFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            throw new NotImplementedException();
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
