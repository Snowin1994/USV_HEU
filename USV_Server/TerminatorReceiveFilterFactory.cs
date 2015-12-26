using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace USV_Server
{
    public class TerminatorReceiveFilterFactory : IReceiveFilterFactory<USVRequestInfo>
    {
        private readonly Encoding m_Encoding;
        private readonly byte[] m_Terminator;
        private readonly IRequestInfoParser<USVRequestInfo> m_RequestInfoParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminatorReceiveFilterFactory"/> class.
        /// </summary>
        /// <param name="terminator">The terminator.</param>
        public TerminatorReceiveFilterFactory(string terminator)
            : this(terminator, Encoding.ASCII, USVBasicRequestInfoParser.DefaultInstance)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminatorReceiveFilterFactory"/> class.
        /// </summary>
        /// <param name="terminator">The terminator.</param>
        /// <param name="encoding">The encoding.</param>
        public TerminatorReceiveFilterFactory(string terminator, Encoding encoding)
            : this(terminator, encoding, USVBasicRequestInfoParser.DefaultInstance)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminatorReceiveFilterFactory"/> class.
        /// </summary>
        /// <param name="terminator">The terminator.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="requestInfoParser">The line parser.</param>
        public TerminatorReceiveFilterFactory(string terminator, Encoding encoding, IRequestInfoParser<USVRequestInfo> requestInfoParser)
        {
            m_Encoding = encoding;
            m_Terminator = encoding.GetBytes(terminator);
            m_RequestInfoParser = requestInfoParser;
        }

        /// <summary>
        /// Creates the Receive filter.
        /// </summary>
        /// <param name="appServer">The app server.</param>
        /// <param name="appSession">The app session.</param>
        /// <param name="remoteEndPoint">The remote end point.</param>
        /// <returns>
        /// the new created request filer assosiated with this socketSession
        /// </returns>
        public virtual IReceiveFilter<USVRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return new TerminatorReceiveFilter(m_Terminator, m_Encoding, m_RequestInfoParser);
        }
    }
}
