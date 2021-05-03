using System;
using System.Net;
using SearchEngine.Interfaces;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SearchEngine.Request
{
    public class BingEngine : iEngine
    {
        public string searchQuery { get; set; }

        public double ProcessingSearch()
        {
            if (string.IsNullOrEmpty(searchQuery)) throw new ArgumentException("Empty search word");

            try
            {
                var queryUrl = $"https://www.bing.com/search?q={searchQuery}";
                var wc = new WebClient();
                var html = wc.DownloadString(queryUrl);
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var resultTag = doc.DocumentNode.SelectSingleNode("//span[@class='sb_count']");
                var result = new Regex(".*(?= (result|resultados))").Match(resultTag?.InnerHtml ?? "0").Value;

                var numericResult = double.Parse(result.Replace(".", string.Empty), CultureInfo.CurrentCulture);

                return numericResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Bing search failed for {searchQuery}: {ex.Message}");
                return 0;
            }
        }

        private async Task<string> requestingPage(string queryUrl)
        {
            var client = new WebClient();
            var response = await client.DownloadStringTaskAsync(new Uri(queryUrl));
            return response;
        }
    }
}
