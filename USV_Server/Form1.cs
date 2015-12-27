using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Logging;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;
using System.Configuration;
using System.IO;
using System.Media;
using SuperHelper.StringToTxt;

namespace USV_Server
{
    public partial class Form1 : Form
    {
        #region 属性
        public delegate void showText(string s, System.Windows.Forms.TextBox TB);
        public showText ShowText;
        private SoundPlayer sp = new SoundPlayer();
        private static Boolean IsStartWarning = true;
        private static Boolean IsToChange = false;
        private static Boolean WarningState = false;
        #endregion


        public Form1()
        {
            InitializeComponent();

            #region 启动服务器
            var serverConfig = new ServerConfig
            {
                //ConfigurationManager.ConnectionStrings
                Port = Convert.ToInt32(controlPortNum.Text)
            };
            try
            {
                if (!InitializeServer.appServer.Setup(serverConfig))
                {
                    showResult.Text += "Failed to set port!" + System.Environment.NewLine;
                }
                if (!InitializeServer.appServer.Start())
                {
                    showResult.Text += "Failed to start the Server!" + System.Environment.NewLine;
                }
                else
                {
                    showResult.Text += "The server started successfully!" + System.Environment.NewLine;
                    button2.Text = "关闭服务器";
                }
            }
            catch (Exception ex)
            {
                showResult.Text += "发生异常：" + ex.ToString() + System.Environment.NewLine;
            }
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowText = new showText(setText);
            InitializeServer.form = this;

            #region 初始化控件状态 初始为手动模式
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox5.Visible = false;

            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button8.Enabled = false;
            button6.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            vScrollBar1.Enabled = false;
            vScrollBar2.Enabled = false;

            this.ActiveControl = showResult;
            #endregion

        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            
            //button7.Focus();
        }

        private void setText(string s, System.Windows.Forms.TextBox TB)
        {
            TB.Text = s;
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (button2.Text == "关闭服务器")
            {
                InitializeServer.appServer.Stop();
            }

            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string Q1 = "Q" + textBox6.Text.ToString() + InitializeServer.ConFixedTail;
                string E1 = "E" + textBox7.Text.ToString() + InitializeServer.ConFixedTail;
                string sendstr = Q1 + E1;
                DataClient.ExecuteCommand(sendstr);
                showResult.Text += System.Environment.NewLine + "Successed to set QE!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器！" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string P1 = "P1" + textBox36.Text.ToString() + InitializeServer.ConFixedTail;

                DataClient.ExecuteCommand(P1);
                showResult.Text += System.Environment.NewLine + "Successed to set PID!";
                this.ActiveControl = showResult;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("未启动服务器!" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void vScrollBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                string sendstr = "S" + vScrollBar1.Value + InitializeServer.ConFixedTail;
                DataClient.ExecuteCommand(sendstr);
                showResult.Text += System.Environment.NewLine + "Successed to set the speed!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器！" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void vScrollBar2_Scroll(object sender, EventArgs e)
        {
            try
            {
                string sendstr = "W" + vScrollBar2.Value + InitializeServer.ConFixedTail;
                DataClient.ExecuteCommand(sendstr);
                showResult.Text += System.Environment.NewLine + "Successed to set the speed!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器！" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region annotate
                //if (IsStartWarning)
                //{
                
                //    if (textBox13.Text == null || textBox13.Text == "")
                //    {
                //        pictureBox1.Visible = false;
                //        return;
                //    }
                //    double front = Double.Parse(textBox13.Text.ToString());
                //    double setFrontMin = Double.Parse(textBox1.Text.ToString());
                //    if (front <= setFrontMin)
                //    {
                //        pictureBox1.Visible = true;
                //        if ( WarningState == false )
                //        {
                //            sp.SoundLocation = @".\music\jingbao.wav";
                //            sp.PlayLooping();
                //        }
                        
                //        WarningState = true;
                //    }
                //    else
                //    {
                //        WarningState = false;
                //        pictureBox1.Visible = false;
                //        sp.Stop();
                //    }
                //}
                #endregion

                #region 将string数据写入文件
                string Temp = DateTime.Now.ToString() + "前测距：" + textBox13.Text + System.Environment.NewLine;

            string path = @".\\前测距.txt";
            FileStream f = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(Temp);
            sw.Flush();
            sw.Close();
            f.Close();
            #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsStartWarning)
                {
                    if (textBox17.Text == null)
                        return;
                    double front = Double.Parse(textBox17.Text.ToString());
                    double setFrontMin = Double.Parse(textBox2.Text.ToString());
                    if (front <= setFrontMin)
                    {
                        pictureBox2.Visible = true;
                        if ( WarningState == false )
                        {
                            sp.SoundLocation = @".\music\jingbao.wav";
                            sp.PlayLooping();
                        }
                        WarningState = true;
                    }
                    else
                    {
                        WarningState = false;
                        pictureBox2.Visible = false;
                        sp.Stop();
                    }
                }
                #region 将string数据写入文件 - annotation
                string Temp = DateTime.Now.ToString() + "后测距：" + textBox17.Text + System.Environment.NewLine;
                string path = @".\\后测距.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion


            }
            catch (Exception ex)
            {

            }

        }

        private void hScrollBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                string sendstr = null;
                for (int i = 0; i < 3;i++ )
                {
                    sendstr = "L1" + hScrollBar1.Value + InitializeServer.ConFixedTail;
                }
                
                DataClient.ExecuteCommand(sendstr);
                showResult.Text += System.Environment.NewLine + "Successed to open the light!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器！" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void hScrollBar2_Scroll(object sender, EventArgs e)
        {
            try
            {
                string sendstr = null;
                for(int i = 0; i < 3;i++ )
                {
                    sendstr = "L2" + hScrollBar2.Value + InitializeServer.ConFixedTail;
                }
                DataClient.ExecuteCommand(sendstr);
                showResult.Text += System.Environment.NewLine + "Successed to open the light!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器！" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "启动手动模式(M)")
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button8.Enabled = false;
                button6.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button12.Enabled = true;
                vScrollBar1.Enabled = false;
                vScrollBar2.Enabled = false;

                string str = "M" + InitializeServer.ConFixedTail;
                DataClient.ExecuteCommand(str);

                button7.Text = "启动自动模式(A)";
            }
            else
            {
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button8.Enabled = true;
                button6.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button12.Enabled = false;
                vScrollBar1.Enabled = true;
                vScrollBar2.Enabled = true;

                string str = "A" + InitializeServer.ConFixedTail;
                DataClient.ExecuteCommand(str);

                button7.Text = "启动手动模式(M)";
            }
            this.ActiveControl = showResult;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            vScrollBar1.Value = (vScrollBar1.Maximum + vScrollBar1.Minimum) / 2;

            this.ActiveControl = showResult;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            vScrollBar2.Value = (vScrollBar2.Maximum + vScrollBar2.Minimum) / 2;

            this.ActiveControl = showResult;
        }
        private void KeyPress_DownUp(object sender, KeyEventArgs e)
        {
            try
            {
                string temp = e.KeyCode.ToString();

                int value = 0;


                switch(e.KeyCode)
                {
                    case Keys.A:
                        #region 按 A 时发生
                        if (button7.Text == "启动自动模式(A)")
                        {
                            button1.Enabled = true;
                            button3.Enabled = true;
                            button4.Enabled = true;
                            button5.Enabled = true;
                            button8.Enabled = true;
                            button6.Enabled = true;
                            button9.Enabled = true;
                            button10.Enabled = true;
                            button12.Enabled = false;
                            vScrollBar1.Enabled = true;
                            vScrollBar2.Enabled = true;

                            string str = "A" + InitializeServer.ConFixedTail;
                            DataClient.ExecuteCommand(str);

                            button7.Text = "启动手动模式(M)";
                        }
                        break;
                        #endregion
                    case Keys.M:
                        #region 按 M 时发生
                        if (button7.Text == "启动手动模式(M)")
                        {
                            button1.Enabled = false;
                            button3.Enabled = false;
                            button4.Enabled = false;
                            button5.Enabled = false;
                            button8.Enabled = false;
                            button6.Enabled = false;
                            button6.Enabled = false;
                            button9.Enabled = false;
                            button10.Enabled = false;
                            button12.Enabled = true;
                            vScrollBar1.Enabled = false;
                            vScrollBar2.Enabled = false;

                            string str = "M" + InitializeServer.ConFixedTail;
                            DataClient.ExecuteCommand(str);

                            button7.Text = "启动自动模式(A)";
                        }
                        break;
                        #endregion
                    case Keys.Q:
                        #region 按 Q 时发生
                        vScrollBar1.Value = (vScrollBar1.Maximum + vScrollBar1.Minimum) / 2;
                        break;
                        #endregion
                    case Keys.W:
                        #region 按 W 时发生
                        vScrollBar2.Value = (vScrollBar2.Maximum + vScrollBar2.Minimum) / 2;
                        break;
                        #endregion
                    case Keys.Down:
                        #region 按 下 时发生
                        if (button7.Text == "启动手动模式(M)")
                        {
                            if (int.TryParse(textBox26.Text,out value))
                                vScrollBar1.Value += int.Parse(textBox26.Text);
                            else
                            {
                                MessageBox.Show("输入幅度非法");
                            }
                        }
                        else if (button7.Text == "启动自动模式(A)")
                        {
                            if (int.TryParse(textBox26.Text, out value))
                                vScrollBar1.Value -= int.Parse(textBox26.Text);
                            else
                            {
                                MessageBox.Show("输入幅度非法");
                            }
                        }
                        break;
                        #endregion
                    case Keys.Up:
                        #region 按 上 时发生
                        if (button7.Text == "启动手动模式(M)")
                        {
                            if (int.TryParse(textBox26.Text, out value))
                                vScrollBar1.Value -= int.Parse(textBox26.Text);
                            else
                            {
                                MessageBox.Show("输入幅度非法");
                            }
                        }
                        else if (button7.Text == "启动自动模式(A)")
                        {
                            if (int.TryParse(textBox26.Text, out value))
                                vScrollBar1.Value += int.Parse(textBox26.Text);
                            else
                            {
                                MessageBox.Show("输入幅度非法");
                            }
                        }
                        break;
                        #endregion
                    case Keys.Right:
                        #region 按 右 时发生
                        if (button7.Text == "启动手动模式(M)")
                        {
                            if (int.TryParse(textBox25.Text, out value))
                                vScrollBar2.Value += int.Parse(textBox25.Text);
                            else
                            {
                                MessageBox.Show("输入幅度非法");
                            }
                        }
                        else if (button7.Text == "启动自动模式(A)")
                        {
                            string strKey;
                            if( !IsToChange )
                            {
                                strKey = "FR" + textBox27.Text + InitializeServer.ConFixedTail;

                                #region 将string数据写入文件 - 已注释
                                //string Temp = DateTime.Now.ToString() + "A" + System.Environment.NewLine;

                                //string path = @"..\\..\\Right.txt";
                                //FileStream f = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                                //StreamWriter sw = new StreamWriter(f);
                                //sw.WriteLine(Temp);
                                //sw.Flush();
                                //sw.Close();
                                //f.Close();
                                #endregion

                            }
                            else
                            {
                                strKey = "FL" + textBox27.Text + InitializeServer.ConFixedTail;
                            }
                            DataClient.ExecuteCommand(strKey);
                        }
                        break;
                        #endregion
                    case Keys.Left:
                        #region 按 左 时发生
                        if (button7.Text == "启动手动模式(M)")
                        {
                            if (int.TryParse(textBox25.Text, out value))
                                vScrollBar2.Value -= int.Parse(textBox25.Text);
                            else
                            {
                                MessageBox.Show("输入幅度非法");
                            }
                        }
                        else if (button7.Text == "启动自动模式(A)")
                        {
                            string strKey;
                            if ( !IsToChange )
                            {
                                strKey = "FL" + textBox28.Text + InitializeServer.ConFixedTail;
                            }
                            else
                            {
                                strKey = "FR" + textBox28.Text + InitializeServer.ConFixedTail;
                            }
                            
                            DataClient.ExecuteCommand(strKey);
                        }
                        break;
                        #endregion
                    case Keys.Oemplus:
                        #region 按 + 时发生
                        hScrollBar1.Value += hScrollBar1.LargeChange;
                        break;
                        #endregion
                    case Keys.OemMinus:
                        #region 按 - 时发生
                        hScrollBar1.Value -= hScrollBar1.LargeChange;
                        break;
                        #endregion
                    case Keys.OemOpenBrackets:
                        #region 按 [ 时发生
                        hScrollBar2.Value -= hScrollBar2.LargeChange;
                        break;
                        #endregion
                    case Keys.Oem6:
                        #region 按 ] 时发生
                        hScrollBar2.Value += hScrollBar2.LargeChange;
                        break;
                        #endregion
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Key_Up(object sender, KeyEventArgs e)
        {
            try
            {
                string strKey;
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        strKey = "FL0" + InitializeServer.ConFixedTail;
                        DataClient.ExecuteCommand(strKey);
                        break;
                    case Keys.Right:
                        strKey = "FR0" + InitializeServer.ConFixedTail;
                        DataClient.ExecuteCommand(strKey);
                        break;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            int value;
            if(int.TryParse(textBox21.Text,out value))
                vScrollBar1.Minimum = value;
            else
            {
                MessageBox.Show("设置值非法");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBox8.Text, out value))
                vScrollBar2.Minimum = value;
            else
            {
                MessageBox.Show("设置值非法");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBox6.Text, out value))
                vScrollBar1.Maximum = value;
            else
            {
                MessageBox.Show("设置值非法");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBox7.Text, out value))
                vScrollBar2.Maximum = value;
            else
            {
                MessageBox.Show("设置值非法");
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region About
            MessageBox.Show
            (
                "   USV_HEU" + System.Environment.NewLine + System.Environment.NewLine +
                "苗润龙    总设计" + System.Environment.NewLine + 
                "任昕旸    软件总体设计" + System.Environment.NewLine + 
                "王厚柯    硬件搭建" + System.Environment.NewLine + 
                "孙雪峰    客户端开发" + System.Environment.NewLine + 
                "路  阳    船体设计" + System.Environment.NewLine + 
                "陈自旺    艇体制造" + System.Environment.NewLine + 
                "郑  潜    控制算法" + System.Environment.NewLine + 
                "袁  帅    下位机设计" + System.Environment.NewLine + 
                "庞顺翔    三维建模" + System.Environment.NewLine + 
                "杨依凡    实验记录" + System.Environment.NewLine + 
                "李晗生    水密舱设计" + System.Environment.NewLine + 
                "熊雪妍    电路焊接" + System.Environment.NewLine + 
                "苍玖阳    零件加工" + System.Environment.NewLine
            );
            #endregion
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "左上测距：" + textBox14.Text + System.Environment.NewLine;
                string path = @".\\左上测距.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "右上测距：" + textBox15.Text + System.Environment.NewLine;
                string path = @".\\右上测距.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "左下测距：" + textBox12.Text + System.Environment.NewLine;
                string path = @".\\左下测距.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "右下测距：" + textBox16.Text + System.Environment.NewLine;
                string path = @".\\右下测距.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "左上推进器：" + textBox9.Text + System.Environment.NewLine;

                string path = @".\\左上推进器.txt";
                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "右上推进器：" + textBox20.Text + System.Environment.NewLine;
                string path = @".\\右上推进器.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "左推进器：" + textBox10.Text + System.Environment.NewLine;
                string path = @".\\左推进器.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "右推进器：" + textBox19.Text + System.Environment.NewLine;
                string path = @".\\右推进器.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "左下推进器：" + textBox11.Text + System.Environment.NewLine;
                string path = @".\\左下推进器.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                #region 将string数据写入文件 
                string Temp = DateTime.Now.ToString() + "右下推进器：" + textBox18.Text + System.Environment.NewLine;
                string path = @".\\右下推进器.txt";

                new PutStringIntoTxt(Temp, path).IntoTxt();
                #endregion
            }
            catch(Exception ex)
            {

            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            if (IsStartWarning)
            {
                try
                {
                    if (textBox24.Text == null)
                        return;
                    double front = Double.Parse(textBox24.Text.ToString());
                    double setFrontMin = Double.Parse(textBox29.Text.ToString());
                    if (front <= setFrontMin)
                    {
                        pictureBox5.Visible = true;
                        if (WarningState == false)
                        {
                            sp.SoundLocation = @".\music\jingbao.wav";
                            sp.PlayLooping();
                        }
                        WarningState = true;
                    }
                    else
                    {
                        WarningState = false;
                        pictureBox5.Visible = false;
                        sp.Stop();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string I1 = "B1" + textBox37.Text.ToString() + InitializeServer.ConFixedTail;

                DataClient.ExecuteCommand(I1);
                showResult.Text += System.Environment.NewLine + "Successed to set PID!";

                this.ActiveControl = showResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器!" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string D1 = "D1" + textBox35.Text.ToString() + InitializeServer.ConFixedTail;

                DataClient.ExecuteCommand(D1);
                showResult.Text += System.Environment.NewLine + "Successed to set PID!";

                this.ActiveControl = showResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器!" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string P2 = "P2" + textBox4.Text.ToString() + InitializeServer.ConFixedTail;

                DataClient.ExecuteCommand(P2);
                showResult.Text += System.Environment.NewLine + "Successed to set PID!";

                this.ActiveControl = showResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器!" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string I2 = "B2" + textBox5.Text.ToString() + InitializeServer.ConFixedTail;

                DataClient.ExecuteCommand(I2);
                showResult.Text += System.Environment.NewLine + "Successed to set PID!";

                this.ActiveControl = showResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器!" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string D2 = "D2" + textBox3.Text.ToString() + InitializeServer.ConFixedTail;

                DataClient.ExecuteCommand(D2);
                showResult.Text += System.Environment.NewLine + "Successed to set PID!";

                this.ActiveControl = showResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("未启动服务器!" + System.Environment.NewLine + ex.ToString());
            }
        }

        private void 关闭警报ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(IsStartWarning)
            {
                WarningState = false;
                IsStartWarning = false;
                showResult.Text += "警报已关闭" + System.Environment.NewLine;
                关闭警报ToolStripMenuItem.Text = "启动警报";
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                sp.Stop();
            }
            else
            {
                IsStartWarning = true;
                showResult.Text += "警报已开启" + System.Environment.NewLine;
                关闭警报ToolStripMenuItem.Text = "关闭警报";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showResult.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(!IsToChange)
            {
                IsToChange = true;
            }
            this.ActiveControl = showResult;
        }

        private void 打开文件目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string FileAdd = @".\\";
                System.Diagnostics.Process.Start(FileAdd);
            }
            catch(Exception ex)
            {
                MessageBox.Show("路径不存在！");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.ActiveControl = showResult;
            showResult.Text += DateTime.Now + ":保存成功" + System.Environment.NewLine;
        }
    }
}
