using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Uptimize.code
{
    public class Dbug
    {
        public static void Write(string message)
        {
 
            Debug.AutoFlush = true;
            Debug.WriteLine("****************************");
            Debug.Indent();
            Debug.WriteLine(message);
            Debug.Unindent();
            Debug.WriteLine("****************************");
        }
    }
}