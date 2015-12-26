using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Metadata;
using SuperSocket.SocketBase.Protocol;

namespace USV_Server
{
    /// <summary>
    /// 封装后的接收数据
    /// </summary>
    public class USVRequestInfo : IRequestInfo
    {
        public USVRequestInfo(string key,string body)
        {
            Key = key;
            Body = body;
            AllInfo = key + body + InitializeServer.FixedTail;
            if (Body != null)
                requestInfoBodyKey = Body.Substring(0, 1);
            else
            {
                requestInfoBodyKey = Body;
            }
        }
        public USVRequestInfo(string key, string body, string[] parameters)
        {
            try
            {
                Key = key;
                Body = body;
                Parameters = parameters;
                AllInfo = key + body + InitializeServer.FixedTail;
                if (Body != null)
                    requestInfoBodyKey = Body.Substring(0, 1);
                else
                {
                    requestInfoBodyKey = Body;
                }
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public string[] Parameters { get; private set; }
        /// <summary>
        /// 命令名称代码
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 数据区
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 标记数据的key值
        /// </summary>
        public string requestInfoBodyKey { get; set; }
        /// <summary>
        /// 标识数据的来源
        /// </summary>
        public string InfoMark { get; set; }
        /// <summary>
        /// 接收到的全部信息
        /// </summary>
        public string AllInfo { get; set; }
        /// <summary>
        /// 固定的尾部
        /// </summary>
        public string FixedTail { get; set; }
        /// <summary>
        /// Gets the first param.
        /// </summary>
        /// <returns></returns>
        public string GetFirstParam()
        {
            if (Parameters.Length > 0)
                return Parameters[0];

            return string.Empty;
        }
        /// <summary>
        /// Gets the <see cref="System.String"/> at the specified index.
        /// </summary>
        public string this[int index]
        {
            get { return Parameters[index]; }
        }
    }
}
