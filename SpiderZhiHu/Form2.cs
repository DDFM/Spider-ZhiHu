#region copyright
// <copyright file="Form2"  company="CIS"> 
// Copyright (c) CIS. All Right Reserved
// </copyright>
// <author>ddfm</author>
// <datecreated>2017/11/1 16:54:50</datecreated>
#endregion
using Comm;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiderZhiHu
{
    public partial class Form1
    {
        public void RequestApi()
        {
            _thread01 = new Thread(() =>
              {
                  var apiUrl = String.Format(StaticResources.ZHIHU_QUESTION_API, tb_question.Text, 20, 0);
                  HttpComm httpComm = new HttpComm();
                  httpComm.Cookies = _cookieContainers;
                  while (true)
                  {
                      try
                      {
                          httpComm.Request(apiUrl);
                          var res = new string(Encoding.UTF8.GetChars(httpComm.ResponseBts));
                          var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<ResJsonResponse>(res);
                          //data是否有数据
                          if (jsonObj.data != null && jsonObj.data.Count > 0)
                          {
                              for (int i = 0; i < jsonObj.data.Count; i++)
                              {
                                  var url = string.Format(StaticResources.ZHIHU_ANSWER_API, _question, jsonObj.data[i].id);
                                  _urls.Enqueue(Tuple.Create(url, jsonObj.data[i].Copy()));
                              }
                              Invoke(new MethodInvoker(delegate ()
                              {
                                  rtb_msg.Text = "RequestApi:" + apiUrl + "（" + jsonObj.data.Count + "）" + "\r\n" + rtb_msg.Text;
                              }));
                              apiUrl = jsonObj.paging.next;
                          }
                          else
                          {
                              break;
                          }
                      }
                      catch (Exception ex)
                      {
                          Invoke(new MethodInvoker(delegate ()
                          {
                              rtb_errorMsg.Text = "RequestApi:" + ex.Message + "\r\n" + rtb_errorMsg.Text;
                          }));
                          break;
                      }
                  }
                  Invoke(new MethodInvoker(delegate ()
                  {
                      rtb_msg.Text = "RequestApi[done]" + _urls.Count.ToString() + "\r\n" + rtb_msg.Text;
                  }));
              });
            _thread01.Start();
        }
        public void GetImgUrl()
        {
            _thread02 = new Thread(() =>
              {
                  HttpComm httpComm = new HttpComm();
                  // _driver = PhantomJSDriverComm.Driver;
                  int count = 0;
                  int imgCount = 0;
                  while (true)
                  {
                      if (_urls.TryDequeue(out var answer))
                      {
                          var url = answer.Item1;
                          try
                          {
                              count++;
                              httpComm.Request(url);
                              var res = new string(Encoding.UTF8.GetChars(httpComm.ResponseBts));
                              var imgs = res.GetAnswerDivRichContent();
                              for (int i = 0; i < imgs.Count; i++)
                              {
                                  _ImgUrls.Enqueue(Tuple.Create(imgs[i], answer.Item2.Copy()));
                              }
                              imgCount += imgs.Count;
                              //_driver.Navigate().GoToUrl(url);
                              //Thread.Sleep(100);
                              ////if (_driver.Title.Contains("安全验证"))
                              ////{
                              ////    var captchaImg = _driver.FindElement(By.XPath("//button[@class='Button Unhuman-cofirm Button--primary Button--blue']"));
                              ////}
                              //var source = _driver.PageSource;
                              //var richContentInner = _driver.FindElement(By.XPath("//div[@class='RichContent RichContent--unescapable']"));
                              //var imgs = richContentInner.FindElements(By.XPath("//div[@class='VagueImage origin_image zh-lightbox-thumb']"));
                              //for (int i = 0; i < imgs.Count; i++)
                              //{
                              //    _ImgUrls.Enqueue(Tuple.Create(imgs[i].GetAttribute("data-src"), Data.Copy(answer.Item2)));
                              //}
                              //imgCount += imgs.Count;
                              Invoke(new MethodInvoker(delegate ()
                                {
                                    var message = string.Format("GetImgUrl:{0}({1})({2})({3})",
                                        url,
                                        count.ToString(),
                                        imgs.Count,
                                        imgCount);
                                    rtb_getImgUrl.Text = message + "\r\n" + rtb_getImgUrl.Text;
                                }));
                          }
                          catch (Exception ex)
                          {
                              Invoke(new MethodInvoker(delegate ()
                              {
                                  rtb_errorMsg.Text = "GetImgUrl:" + ex.Message + "\r\n" + rtb_errorMsg.Text;
                              }));
                          }
                      }
                      else
                      {
                          Invoke(new MethodInvoker(delegate ()
                          {
                              rtb_getImgUrl.Text = "GetImgUrl:" + count.ToString() + "\r\n" + rtb_getImgUrl.Text;
                          }));
                          Thread.Sleep(1000);
                      }
                  }
              });
            _thread02.Start();
        }

        public void DownImg()
        {
            _thread03 = new Thread(() =>
              {
                  HttpComm httpComm = new HttpComm();
                  int count = 0;
                  while (true)
                  {
                      if (_ImgUrls.TryDequeue(out var img))
                      {
                          var url = img.Item1;
                          var path01 = string.Format("{0}-{1}",
                              img.Item2.question.id,
                              img.Item2.question.title.ToDirectoryPath()
                              );
                          var path02 = string.Format("{0}-{1}-{2}",
                             img.Item2.id,
                             img.Item2.author.name.ToDirectoryPath(),
                             img.Item2.CreatedTime
                             );
                          var fullPath = string.Empty;
                          var fileNname = string.Empty;
                          if (cb_isClassify.Checked)
                          {
                              fullPath = Path.Combine(path01, path02);
                              fileNname = Guid.NewGuid().ToString() + Path.GetExtension(url);
                          }
                          else
                          {
                              fullPath = path01;
                              fileNname = path02 + Guid.NewGuid().ToString() + Path.GetExtension(url);
                          }
                          if (!System.IO.Directory.Exists(fullPath))
                          {
                              Directory.CreateDirectory(fullPath);
                          }
                          var path = Path.Combine(fullPath, fileNname);

                          try
                          {
                              httpComm.Request(url);
                              var byts = httpComm.ResponseBts;

                              FileComm.WriteFile(path, byts);
                              Invoke(new MethodInvoker(delegate ()
                              {
                                  rtb_downImg.Text = "DownImg:" + url + "\r\n" + rtb_downImg.Text;
                              }));
                          }
                          catch (Exception ex)
                          {
                              Invoke(new MethodInvoker(delegate ()
                              {
                                  rtb_errorMsg.Text = "DownImg:" + ex.Message + "\r\n" + rtb_errorMsg.Text;
                              }));
                          }
                      }
                      else
                      {
                          Invoke(new MethodInvoker(delegate ()
                          {
                              rtb_downImg.Text = "DownImg:" + (++count).ToString() + "\r\n" + rtb_downImg.Text;
                          }));
                          Thread.Sleep(1000);
                      }
                  }

              });
            _thread03.Start();
        }
    }
}
