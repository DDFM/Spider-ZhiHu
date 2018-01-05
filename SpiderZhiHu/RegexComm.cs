#region copyright
// <copyright file="PathComm"  company="CIS"> 
// Copyright (c) CIS. All Right Reserved
// </copyright>
// <author>ddfm</author>
// <datecreated>2017/11/2 14:40:54</datecreated>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Visitors;

namespace SpiderZhiHu
{
    public static class RegexComm
    {
        /// <summary>
        /// È¥³ýÂ·¾¶ÌØÊâ×Ö·û
        /// </summary>
        private static string _regPath;
        private static string _divImg;
        private static string _img;
        private static string _absoluteReg;

        static RegexComm()
        {

            _regPath = @"[\\/:*?"" <>|]";
            _divImg = @"<div class=""RichContent RichContent--unescapable""[\s\S]*ContentItem-actions RichContent-actions";
            _img = @"data-actualsrc[\s\S]*?"">";
            _absoluteReg = @"http[s]{0,1}://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        }
        public static string ToDirectoryPath(this string s)
        {
            var res = Regex.Replace(s, _regPath, "");
            return res;
        }
        public static List<string> GetAnswerDivRichContent(this string s)
        {
            List<string> res = new List<string>();

            Parser parser = Parser.CreateParser(s, "utf-8");
            HtmlPage htmlPage = new HtmlPage(parser);
            parser.VisitAllNodesWith(htmlPage);


            HasAttributeFilter richContent = new HasAttributeFilter();
            richContent.AttributeName = "class";
            richContent.AttributeValue = "RichContent RichContent--unescapable";

            HasAttributeFilter span = new HasAttributeFilter();
            span.AttributeName = "class";
            span.AttributeValue = "RichText CopyrightRichText-richText";

            var divNodes = htmlPage.Body.ExtractAllNodesThatMatch(richContent, true);
            var spanNodes = divNodes.ExtractAllNodesThatMatch(span, true);


            //var spanChildrens = spanNodes[0].Children;

            //var noscriptNodes = spanChildrens.ExtractAllNodesThatMatch(new TagNameFilter("noscript"));
            //var noscriptImgNodes = noscriptNodes.ExtractAllNodesThatMatch(new TagNameFilter("img"), true);
            //for (int i = 0; i < noscriptNodes.Count; i++)
            //{
            //    var isRemove = spanChildrens.Remove(noscriptNodes[i]);
            //}

            var imgNodes = spanNodes.ExtractAllNodesThatMatch(new TagNameFilter("img"),true);
           // imgNodes = imgNodes.ExtractAllNodesThatMatch(,true);
            for (int i = 0; i < imgNodes.Count; i++)
            {
                var imageTag = (Winista.Text.HtmlParser.Tags.ImageTag)imgNodes[i];
                var imgUrl= imageTag.GetAttribute("data-actualsrc");
                if (!string.IsNullOrEmpty(imgUrl))
                {
                    res.Add(imgUrl);
                }
            }
            res = res.Distinct().ToList();
            //Winista.Text.HtmlParser.Tags.ImageTag
            //List<string> res = new List<string>();
            //var divimg = Regex.Match(s, _divImg).ToString();
            //var imgs = Regex.Matches(divimg, _img).ToString();
            //var imgCount = imgs.Count();
            //for (int i = 0; i < imgCount; i++)
            //{
            //    var dataImg = imgs[i].ToString();
            //    var tempStr = Regex.Match(dataImg, _absoluteReg).ToString();
            //    res.Add(tempStr);
            //}

            return res;
        }
    }
}
