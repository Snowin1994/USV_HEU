using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace USV_Server
{
    public class TP : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            session.Send(requestInfo.Body);
            //  
            //var sessions = InitializeServer.appServer.GetSessions(s => s.LocalEndPoint.ToString() == "127.0.0.1:2012");
            //foreach (var s in sessions)
            //{
            //    s.Send(requestInfo.AllInfo);
            //    //s.Send(requestInfo.Body);
            //    return;
            //}
            //session.Send("0XFFFF");
        }
    }
}