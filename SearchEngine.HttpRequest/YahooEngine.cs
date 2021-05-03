using System;
using System.Net;
using SearchEngine.Interfaces;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;

namespace SearchEngine.Request
{
    public class YahooEngine : iEngine
    {
        public string searchQuery { get; set; }

        public double ProcessingSearch()
        {
            if (string.IsNullOrEmpty(searchQuery)) throw new ArgumentException("Empty search word");

            try
            {
                var queryUrl = $"https://espanol.search.yahoo.com/search?p={searchQuery}";
                var wc = new WebClient();
                var html = wc.DownloadString(queryUrl);
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var paginationNodes = doc.DocumentNode.SelectSingleNode("//div[@class='compPagination']");
                var resultTag = paginationNodes.SelectSingleNode("span");
                var result = new Regex(".*(?= (result|resultados))").Match(resultTag?.InnerHtml ?? "0").Value;

                var numericResult = double.Parse(result, CultureInfo.CurrentCulture);

                return numericResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Yahoo search failed for {searchQuery}: {ex.Message}");
                return 0;
            }

        }
    }
}
