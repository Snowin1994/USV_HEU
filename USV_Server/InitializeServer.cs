using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Logging;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;

namespace USV_Server
{
    public static class InitializeServer
    {
        public static USVServer appServer = new USVServer();
        public static Form1 form;
        public static string FixedTail = "USVSXF";
        public static string NotFindSession = "Not Find Session!";
        public static string ConFixedTail = "\\OV";
    }
}
