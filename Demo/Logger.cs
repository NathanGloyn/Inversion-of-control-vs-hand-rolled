using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using Demo.Interfaces;

namespace Demo
{
    public class Logger:ILogger
    {
        public void Log(string message)
        {
            Trace.WriteLine(message);
        }
    }
}