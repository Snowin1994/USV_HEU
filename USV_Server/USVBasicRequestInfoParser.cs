using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Protocol;

namespace USV_Server
{
    public class USVBasicRequestInfoParser : IRequestInfoParser<USVRequestInfo>
    {
        private readonly string m_Spliter;
        private readonly string[] m_ParameterSpliters;

        private const string m_OneSpace = " ";

        /// <summary>
        /// The default singlegton instance
        /// </summary>
        public static readonly USVBasicRequestInfoParser DefaultInstance = new USVBasicRequestInfoParser();

        /// <summary>
        /// Initializes a new instance of the <see cref="USVBasicRequestInfoParser"/> class.
        /// </summary>
        public USVBasicRequestInfoParser()
            : this(m_OneSpace, m_OneSpace)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="USVBasicRequestInfoParser"/> class.
        /// </summary>
        /// <param name="spliter">The spliter between command name and command parameters.</param>
        /// <param name="parameterSpliter">The parameter spliter.</param>
        public USVBasicRequestInfoParser(string spliter, string parameterSpliter)
        {
            m_Spliter = spliter;
            m_ParameterSpliters = new string[] { parameterSpliter };
        }

        #region IRequestInfoParser<USVRequestInfo> Members

        /// <summary>
        /// Parses the request info.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public USVRequestInfo ParseRequestInfo(string source)
        {
            #region  旧版本

            //int pos = source.IndexOf(m_Spliter);

            //string name = string.Empty;
            //string param = string.Empty;

            //if (pos > 0)
            //{
            //    name = source.Substring(0, pos);
            //    param = source.Substring(pos + 1);
            //}
            //else
            //{
            //    name = source;
            //}

            //return new USVRequestInfo(name, param,
            //    param.Split(m_ParameterSpliters, StringSplitOptions.RemoveEmptyEntries));
            #endregion
            
            int sourceLength = source.Length;
            string name = string.Empty;
            string body = string.Empty;
            string all = string.Empty;

            if (sourceLength > 2)
            {
                name = source.Substring(0, 2);
                body = source.Substring(2, sourceLength - 2);       //减2
                all = source;
            }
            else
            {
                name = source;
            }

            return new USVRequestInfo(name, body,
                body.Split(m_ParameterSpliters, StringSplitOptions.RemoveEmptyEntries));
        }

        #endregion
    }
}
