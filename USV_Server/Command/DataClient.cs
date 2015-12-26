using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace USV_Server
{
    public static class DataClient
    {
        public static void ExecuteCommand(string souorce)
        {
            try
            {
                var sessions = InitializeServer.appServer.GetSessions(s => s.RemoteEndPoint.ToString() == "192.168.1.7:20108");
                foreach (var s in sessions)
                {
                    s.Send(souorce);
                    return;
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
