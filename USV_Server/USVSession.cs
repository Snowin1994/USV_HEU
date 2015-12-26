using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace USV_Server
{
    public class USVSession : AppSession<USVSession,USVRequestInfo>
    {
        public string USVId { get; internal set; }
        //public USVSession()
        //    : base()
        //{

        //}

        /// <summary>
        /// 连接成功时返回信息
        /// </summary>
        protected override void OnSessionStarted()
        {
            //this.Send("Welcome to SuperSocket USV Server!---By Snowin");

            //this.Send(this.LocalEndPoint.ToString());
        }
        /// <summary>
        /// 异常请求是返回信息
        /// </summary>
        /// <param name="requestInfo"></param>
        protected override void HandleUnknownRequest(USVRequestInfo requestInfo)
        {
            //this.Send("Unknow request");
        }
        /// <summary>
        /// 发生异常时返回的信息
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            //this.Send("Application error: {0}", e.Message);
        }
        /// <summary>
        /// 断开连接时返回的信息
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            //InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { reason.ToString(), InitializeServer.form.showResult });
        }
    }
}
