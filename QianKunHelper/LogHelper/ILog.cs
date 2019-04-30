﻿using System;

namespace QianKunHelper.LogHelper
{
    public interface ILog
    {
        void Debug(object message);

        void Debug(string message, Exception exception);

        void DebugFormat(string format, params object[] args);

        void DebugFormat(string format, object arg0);

        void DebugFormat(string format, object arg0, object arg1);

        void DebugFormat(string format, object arg0, object arg1, object arg2);

        void DebugFormat(IFormatProvider provider, string format, params object[] args);

        void Error(object message);

        void Error(string message, Exception exception);

        void ErrorFormat(string format, params object[] args);

        void ErrorFormat(string format, object arg0);

        void ErrorFormat(string format, object arg0, object arg1);

        void ErrorFormat(string format, object arg0, object arg1, object arg2);

        void ErrorFormat(IFormatProvider provider, string format, params object[] args);

        void Fatal(object message);
        void Fatal(string message, Exception exception);

        void FatalFormat(string format, params object[] args);

        void FatalFormat(string format, object arg0);

        void FatalFormat(string format, object arg0, object arg1);

        void FatalFormat(string format, object arg0, object arg1, object arg2);

        void FatalFormat(IFormatProvider provider, string format, params object[] args);

        void Info(object message);

        void Info(string message, Exception exception);

        void InfoFormat(string format, params object[] args);
        void InfoFormat(string format, object arg0);

        void InfoFormat(string format, object arg0, object arg1);

        void InfoFormat(string format, object arg0, object arg1, object arg2);
        void InfoFormat(IFormatProvider provider, string format, params object[] args);

        void Warn(object message);

        void Warn(string message, Exception exception);

        void WarnFormat(string format, params object[] args);

        void WarnFormat(string format, object arg0);

        void WarnFormat(string format, object arg0, object arg1);

        void WarnFormat(string format, object arg0, object arg1, object arg2);

        void WarnFormat(IFormatProvider provider, string format, params object[] args);
    }
}
