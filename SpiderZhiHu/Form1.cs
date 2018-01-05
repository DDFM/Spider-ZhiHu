using Comm;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderZhiHu
{
    public partial class Form1 : Form
    {
        private HttpComm _httpComm = new HttpComm();
        private RemoteWebDriver _driver;
        private string _url = string.Empty;
        private List<Tuple<int, int>> postions = new List<Tuple<int, int>>();
        private CookieContainer _cookieContainers = new CookieContainer();
        private ConcurrentQueue<Tuple<string, Data>> _urls = new ConcurrentQueue<Tuple<string, Data>>();
        private ConcurrentQueue<Tuple<string, Data>> _ImgUrls = new ConcurrentQueue<Tuple<string, Data>>();
        private string _question = "";

        private Thread _thread01;
        private Thread _thread02;
        private Thread _thread03;

        public Form1()
        {
            InitializeComponent();
            Init();
            ControlBtDown();
        }
        private void ControlBtDown(bool isEnable = false)
        {
            bt_down.Enabled = isEnable;
        }
        private void Init()
        {
            cb_isClassify.Checked = true;
            lb_msg.Text = string.Empty;
            tb_userName.Text = "用户名";
            tb_password.Text = "密码";
            tb_question.Text = "37787176";//当一个颜值很高的程序员是怎样一番体验？
            tb_question.Text = "40778754";//现实中真的有书中所说的那种「绝世美人」吗？
            tb_question.Text = "45930833";//女生身上有纹身是一种怎样的体验？
            //tb_question.Text = "67381385";//自行车
            tb_postion.Text = "位置";
            postions.Add(Tuple.Create(22, 24));
            postions.Add(Tuple.Create(49, 24));
            postions.Add(Tuple.Create(68, 24));
            postions.Add(Tuple.Create(92, 24));
            postions.Add(Tuple.Create(105, 24));
            postions.Add(Tuple.Create(142, 27));
            postions.Add(Tuple.Create(165, 28));
        }
        private async void bt_spider_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tb_question.Text))
            {
                lb_msg.Text = "请输入问题ID";
                return;
            }
            bt_spider.Enabled = false;

            _question = tb_question.Text.Trim();
            _url = Path.Combine(StaticResources.QUESTION_URL, tb_question.Text);
            if (File.Exists(StaticResources.COOKIE_FILE_PATH))
            {
                var file01 = File.ReadAllBytes(StaticResources.COOKIE_FILE_PATH);
                _cookieContainers = FormatterComm.Deserialize<CookieContainer>(Encoding.UTF8.GetString(file01));
                _httpComm.Cookies = _cookieContainers;
                lb_msg.Text = "已存在Coolie";

                ControlBtDown(true);
                bt_spider.Enabled = true;
                return;
            }
            else
            {
                await Task.Run(() =>
                     {
                         try
                         {
                             if (_driver != null)
                             {
                                 _driver.Quit();
                                 _driver.Dispose();
                                 _driver = null;
                             }
                             _driver = PhantomJSDriverComm.Driver;
                             _driver.Navigate().GoToUrl(StaticResources.LOG_IN_URL);

                             Thread.Sleep(2000);
                             var signinSwitchPassword = _driver.FindElement(By.XPath("//span[@class='signin-switch-password']"));
                             signinSwitchPassword.Click();

                             Screenshot screen;

                             var account = _driver.FindElement(By.XPath("//input[@name='account']"));
                             //var accountHtml = account.GetAttribute("outerHTML");
                             account.SendKeys(tb_userName.Text.Trim());

                             var password = _driver.FindElement(By.XPath("//input[@name='password']"));
                             //var passwordHtml = password.GetAttribute("outerHTML");
                             password.SendKeys(tb_password.Text.Trim());

                             Thread.Sleep(2000);
                             screen = _driver.GetScreenshot();
                             // screen.SaveAsFile(StaticResources.TEMP_IMG_PATH);
                             var imgBts = screen.AsByteArray;
                             Invoke(new MethodInvoker(delegate ()
                             {
                                 using (var ms = new MemoryStream())
                                 {
                                     ms.Write(imgBts, 0, imgBts.Length);
                                     var bitMap = new Bitmap(ms);
                                     pb_img.Width = bitMap.Width;
                                     pb_img.Height = bitMap.Height;
                                     pb_img.Image = bitMap;
                                 }
                                // ContrlEnable(true);
                                 ControlBtDown(true);
                                 bt_spider.Enabled = true;
                             }));

                         }
                         catch (Exception ex)
                         {
                             Invoke(new MethodInvoker(delegate ()
                             {
                                 bt_spider.Enabled = true;
                                 rtb_errorMsg.Text = ex.Message + "\r\n" + rtb_errorMsg.Text;

                             }));
                         }
                     });
            }
        }



        private void bt_refreshImg_Click(object sender, EventArgs e)
        {
            if (_driver == null)
            {
                lb_msg.Text = "无法刷新";
                return;
            }
            try
            {


                var bt = _driver.FindElement(By.XPath("//button[@class='sign-button submit']"));
                bt.Click();
                Thread.Sleep(2000);
                var screen = _driver.GetScreenshot();

                var imgBts = screen.AsByteArray;
                using (var ms = new MemoryStream())
                {
                    ms.Write(imgBts, 0, imgBts.Length);
                    var bitMap = new Bitmap(ms);
                    pb_img.Width = bitMap.Width;
                    pb_img.Height = bitMap.Height;
                    pb_img.Image = bitMap;
                }
            }
            catch (Exception ex)
            {
                rtb_errorMsg.Text = ex.Message + "\r\n" + rtb_errorMsg.Text;
            }
        }
        private void bt_postion_Click(object sender, EventArgs e)
        {
            if (_driver == null)
            {
                lb_msg.Text = "找不到位置";
                return;
            }
            try
            {


                var captchaImage = _driver.FindElement(By.XPath("//img[@class='Captcha-image']"));
                Actions actions = new Actions(_driver);
                var postion = tb_postion.Text.Trim();
                if (postion.Length < 1)
                {
                    lb_msg.Text = "请输入1-7数字";
                    return;
                }
                for (int i = 0; i < postion.Length; i++)
                {
                    if (int.TryParse(postion[i].ToString(), out var t))
                    {
                        if (t > 7)
                        {
                            lb_msg.Text = "请输入1-7数字";
                            return;
                        }
                        actions.MoveToElement(captchaImage, postions[t - 1].Item1, postions[t - 1].Item2);
                        actions.Click();
                    }
                    else
                    {
                        lb_msg.Text = "请输入数字";
                        return;
                    }
                }
                actions.Perform();
                actions.Release();
                Thread.Sleep(2000);
                var screen = _driver.GetScreenshot();
                var imgBts = screen.AsByteArray;
                using (var ms = new MemoryStream())
                {
                    ms.Write(imgBts, 0, imgBts.Length);
                    var bitMap = new Bitmap(ms);
                    pb_img.Width = bitMap.Width;
                    pb_img.Height = bitMap.Height;
                    pb_img.Image = bitMap;
                }
            }
            catch (Exception ex)
            {

                rtb_errorMsg.Text = ex.Message + "\r\n" + rtb_errorMsg.Text;
            }


        }
        private void bt_final_Click(object sender, EventArgs e)
        {
            if (_driver == null)
            {
                lb_msg.Text = "无法完成";
                return;
            }
            try
            {


                var bt = _driver.FindElement(By.XPath("//button[@class='sign-button submit']"));
                bt.Click();

                Thread.Sleep(2000);
                var screen = _driver.GetScreenshot();
                var imgBts = screen.AsByteArray;
                using (var ms = new MemoryStream())
                {
                    ms.Write(imgBts, 0, imgBts.Length);
                    var bitMap = new Bitmap(ms);
                    pb_img.Width = bitMap.Width;
                    pb_img.Height = bitMap.Height;
                    pb_img.Image = bitMap;
                }

            }
            catch (Exception ex)
            {

                rtb_errorMsg.Text = ex.Message + "\r\n" + rtb_errorMsg.Text;
            }

        }

        private void bt_saveCookie_Click(object sender, EventArgs e)
        {
            if (_driver == null)
            {
                lb_msg.Text = "不存在cookie";
                return;
            }
            try
            {


                CookieContainer cookieContainer = new CookieContainer();
                //获取cookies
                var cookies = _driver.Manage().Cookies.AllCookies;
                for (int i = 0; i < cookies.Count; i++)
                {
                    var tempCookie = new System.Net.Cookie()
                    {
                        Domain = cookies[i].Domain,
                        Expires = cookies[i].Expiry ?? DateTime.MaxValue,
                        HttpOnly = cookies[i].IsHttpOnly,
                        Name = cookies[i].Name,
                        Path = cookies[i].Path,
                        Secure = cookies[i].Secure,
                        Value = cookies[i].Value
                    };
                    _cookieContainers.Add(tempCookie);
                    cookieContainer.Add(tempCookie);
                }
                FileComm.WriteFile(StaticResources.COOKIE_FILE_PATH, Encoding.UTF8.GetBytes(FormatterComm.Serialize(cookieContainer)));
                lb_msg.Text = "保存成功";
            }
            catch (Exception ex)
            {

                rtb_errorMsg.Text = ex.Message + "\r\n" + rtb_errorMsg.Text;
            }
        }

        private void bt_verification_Click(object sender, EventArgs e)
        {
            lb_msg.Text = "验证成功";
            //_driver.Navigate().GoToUrl(String.Format(StaticResources.ZHIHU_QUESTION_API, tb_question.Text));
            //Thread.Sleep(2000);
            //rtb_msg.Text = _driver.PageSource + "\r\nHTTP:-------------------\r\n";
            ////var screen = _driver.GetScreenshot();
            ////var imgBts = screen.AsByteArray;
            ////using (var ms = new MemoryStream())
            ////{
            ////    ms.Write(imgBts, 0, imgBts.Length);
            ////    var bitMap = new Bitmap(ms);
            ////    pb_img.Width = bitMap.Width;
            ////    pb_img.Height = bitMap.Height;
            ////    pb_img.Image = bitMap;
            ////}
            //_httpComm.Request(String.Format(StaticResources.ZHIHU_QUESTION_API, tb_question.Text));
            //var res = new string(Encoding.UTF8.GetChars(_httpComm.ResponseBts));
            //rtb_msg.Text += res;
            //lb_msg.Text = res;
        }

        private void bt_down_Click(object sender, EventArgs e)
        {
            ThreadDispose();
            RequestApi();
            GetImgUrl();
            DownImg();
        }


        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = false;
            await Task.Run(() =>
            {
                ThreadDispose();
                if (_driver != null)
                {
                    _driver.Quit();
                    _driver.Dispose();
                }
            });
        }

        private async void bt_quitService_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (_driver != null)
                {
                    _driver.Quit();
                    _driver.Dispose();
                }
            });
        }

        private void bt_threadDispose_Click(object sender, EventArgs e)
        {
            ThreadDispose();
        }
        private void ThreadDispose()
        {
            if (_thread01 != null)
            {
                _thread01.Abort();
            }
            if (_thread02 != null)
            {
                _thread02.Abort();
            }
            if (_thread03 != null)
            {
                _thread03.Abort();
            }
            _urls = new ConcurrentQueue<Tuple<string, Data>>();
            _ImgUrls = new ConcurrentQueue<Tuple<string, Data>>();
        }
    }
}
