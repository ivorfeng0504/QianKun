using System;

namespace QianKunHelper.LogHelper
{
    public class Log4netLogger : ILog
    {
        public log4net.ILog _log;
        public Log4netLogger(string repository, Type t)
        {
            _log = log4net.LogManager.GetLogger(repository, t);
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
            System.Diagnostics.Debug.WriteLine(msg, args);
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
        public void Debug(string message, Exception exception)
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
                _log.DebugFormat(format, args);
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
        public void Error(string message, Exception exception)
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
                _log.ErrorFormat(format, args);
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
        public void Fatal(string message, Exception exception)
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
                _log.FatalFormat(format, args);
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
        public void Info(string message, Exception exception)
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
                _log.InfoFormat(format, args);
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
        public void Warn(string message, Exception exception)
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
                _log.WarnFormat(format, args);
            }
            else
            {
                DiagnosticsFormat(format, args);
            }
        }

        public void DebugFormat(string format, object arg0)
        {

        }

        public void DebugFormat(string format, object arg0, object arg1)
        {

        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {

        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {

        }

        public void ErrorFormat(string format, object arg0)
        {

        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {

        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {

        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {

        }

        public void FatalFormat(string format, object arg0)
        {

        }

        public void FatalFormat(string format, object arg0, object arg1)
        {

        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {

        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {

        }

        public void InfoFormat(string format, object arg0)
        {

        }

        public void InfoFormat(string format, object arg0, object arg1)
        {

        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {

        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {

        }

        public void WarnFormat(string format, object arg0)
        {

        }

        public void WarnFormat(string format, object arg0, object arg1)
        {

        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {

        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {

        }
    }
}
