#region copyright
// <copyright file="StaticResources"  company="CIS"> 
// Copyright (c) CIS. All Right Reserved
// </copyright>
// <author>ddfm</author>
// <datecreated>2017/11/1 13:42:53</datecreated>
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderZhiHu
{
    public static class StaticResources
    {
        public static readonly string LOG_IN_URL = "https://www.zhihu.com/signin?next=/";
        public static readonly string EXE_PATH = Environment.CurrentDirectory;
        public static readonly string QUESTION_URL = "https://www.zhihu.com/question/";
        public static readonly string COOKIE_FILE_PATH = Path.Combine(EXE_PATH, "cookie");
        public static readonly string ZHIHU_QUESTION_API = "https://www.zhihu.com/api/v4/questions/{0}/answers?limit={1}&offset={2}";
        public static readonly string ZHIHU_ANSWER_API = "https://www.zhihu.com/question/{0}/answer/{1}";
    }
}
