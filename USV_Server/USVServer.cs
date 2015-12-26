using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using USV_Server;

namespace USV_Server
{
    public class USVServer : AppServer<USVSession,USVRequestInfo>
    {
        public USVServer()
            : base(new TerminatorReceiveFilterFactory("SXF"))
        {

        }
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }
        protected override void OnStopped()
        {
            base.OnStopped();
        }
    }
}
