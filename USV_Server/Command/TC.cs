using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace USV_Server
{
    #region 6个红外

    public class I1 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox13.Invoke
                    (
                    InitializeServer.form.ShowText, 
                    new object[] { requestInfo.Body, InitializeServer.form.textBox13 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class I2 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox14.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox14 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class I3 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox15.Invoke
                    (
                    InitializeServer.form.ShowText, 
                    new object[] { requestInfo.Body, InitializeServer.form.textBox15 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class I4 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox12.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox12 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class I5 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox16.Invoke
                    (
                    InitializeServer.form.ShowText, 
                    new object[] { requestInfo.Body, InitializeServer.form.textBox16 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class I6 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox17.Invoke
                    (
                    InitializeServer.form.ShowText, 
                    new object[] { requestInfo.Body, InitializeServer.form.textBox17 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }

    #endregion

    #region 1个电压
    public class V1 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {

            try
            {
                InitializeServer.form.textBox24.Invoke
                    (
                    InitializeServer.form.ShowText, 
                    new object[] { requestInfo.Body, InitializeServer.form.textBox24 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    //public class V2 : CommandBase<USVSession, USVRequestInfo>
    //{
    //    public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
    //    {
    //        try
    //        {
    //            InitializeServer.form.textBox21.Invoke
    //                (
    //                InitializeServer.form.ShowText,
    //                new object[] { requestInfo.Body, InitializeServer.form.textBox21 }
    //                );
    //        }
    //        catch (Exception ex)
    //        {
    //            DateTime nowTime = DateTime.Now;
    //            InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
    //        }
    //    }
    //}

    #endregion

    #region 2个GPS
    public class G1 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox22.Invoke
                    (
                    InitializeServer.form.ShowText, 
                    new object[] { requestInfo.Body, InitializeServer.form.textBox22 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }

    public class G2 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox23.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox23 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    #endregion

    #region 6个推进器
    public class M1 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox9.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox9 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }

    public class M2 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox20.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox20 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }

    public class M3 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox18.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox18 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class M4 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox11.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox11 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }


    public class S1 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox10.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox10 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }

    public class S2 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {
            try
            {
                InitializeServer.form.textBox19.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox19 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    #endregion

    public class P1 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {

            try
            {
                InitializeServer.form.textBox31.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox31 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class B1 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {

            try
            {
                InitializeServer.form.textBox32.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox32 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class D1 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {

            try
            {
                InitializeServer.form.textBox30.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox30 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }

    public class P2 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {

            try
            {
                InitializeServer.form.textBox34.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox34 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class B2 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {

            try
            {
                InitializeServer.form.textBox38.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox38 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
    public class D2 : CommandBase<USVSession, USVRequestInfo>
    {
        public override void ExecuteCommand(USVSession session, USVRequestInfo requestInfo)
        {

            try
            {
                InitializeServer.form.textBox33.Invoke
                    (
                    InitializeServer.form.ShowText,
                    new object[] { requestInfo.Body, InitializeServer.form.textBox33 }
                    );
            }
            catch (Exception ex)
            {
                DateTime nowTime = DateTime.Now;
                InitializeServer.form.showResult.Invoke(InitializeServer.form.ShowText, new object[] { nowTime.ToString() + ":" + ex.ToString(), InitializeServer.form.showResult });
            }
        }
    }
}
