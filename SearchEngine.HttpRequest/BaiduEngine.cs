using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using SearchEngine.Interfaces;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SearchEngine.Request
{
    public class BaiduEngine : iEngine
    {
        public string searchQuery { get; set; }

        public double ProcessingSearch()
        {
            var queryUrl = $"https://www.baidu.com/s?wd={searchQuery}";
            var wc = new WebClient();
            var html = wc.DownloadString(queryUrl);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var paginationNodes = doc.DocumentNode.SelectSingleNode("//div[@class='compPagination']");
            var resultTag = paginationNodes.SelectSingleNode("span");
            var result = new Regex(".*(?= (result|resultados))").Match(resultTag?.InnerHtml ?? string.Empty)?.Value ?? "0";

            var numericResult = double.Parse(result, CultureInfo.CurrentCulture);

            return numericResult;

        }
    }
}
