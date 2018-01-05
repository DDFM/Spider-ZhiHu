#region copyright
// <copyright file="ResJsonResponse"  company="CIS"> 
// Copyright (c) CIS. All Right Reserved
// </copyright>
// <author>ddfm</author>
// <datecreated>2017/11/1 15:52:06</datecreated>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderZhiHu
{
    public class ResJsonResponse
    {
        public Paging paging { get; set; }
        public List<Data> data { get; set; }
    }
    public class Paging
    {
        public string previous { get; set; }
        public string next { get; set; }


    }
    public class Data
    {
        /// <summary>
        /// 问题
        /// </summary>
        public Question question { get; set; }
        /// <summary>
        /// 回答ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long created_time { get; set; }

        public string CreatedTime
        {
            get
            {
                long unixTimeStamp = created_time;
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                DateTime dt = startTime.AddSeconds(unixTimeStamp);
                return dt.ToString("yyyy年MM月dd日HH时mm分ss秒");
                //return dt.ToString("yyyy年MM月dd日HH时mm分ss秒ffff");
            }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public Author author { get; set; }

        public  Data Copy()
        {
            return new Data()
            {
                author = author.Copy(),
                id = id,
                question = question.Copy(),
                created_time = created_time
            };
        }

    }

    public class Author
    {
        public string name { get; set; }
        public  Author Copy( )
        {
            return new Author()
            {
                name = name
            };
        }
    }
    public class Question
    {

        public string id { get; set; }
        public string title { get; set; }
        public  Question Copy()
        {
            return new Question() { id = id, title = title };
        }
    }
}
