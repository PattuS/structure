﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structure.Services
{
    public interface ILog
    {
        void Info(string message, Exception exception = null);
        void Debug(string message, Exception exception = null);
        void Warn(string message, Exception exception = null);
        void Error(string message, Exception exception = null);
        void Fatal(string message, Exception exception = null);
    }
}
