using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace SpiderZhiHu
{
    public static class PhantomJSDriverComm
    {
        private static List<Tuple<string, string>> _proxys = new List<Tuple<string, string>>();
        public static RemoteWebDriver Driver
        {
            get
            {
                return new PhantomJSDriver(GetPhantomJSDriverService());
            }
        }

        static PhantomJSDriverComm()
        {
            _proxys.Add(Tuple.Create("61.135.217.7", "80"));
        }
        private static PhantomJSDriverService GetPhantomJSDriverService()
        {
            PhantomJSDriverService pds = PhantomJSDriverService.CreateDefaultService();
            pds.LoadImages = true;

            //设置代理服务器地址
            //var ip = "192.168.1.103";
            //var port = "8888";
            //pds.Proxy = $"{_proxys[0].Item1}:{_proxys[0].Item2}";  
            //设置代理服务器认证信息
            //pds.ProxyAuthentication = GetProxyAuthorization();
            return pds;
        }
    }
}