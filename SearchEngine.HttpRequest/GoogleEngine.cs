using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using SearchEngine.Interfaces;
using System.Diagnostics;

namespace SearchEngine.Request
{
    public class GoogleEngine : iEngine
    {
        public string searchQuery { get; set; }

        public double ProcessingSearch()
        {
            try
            {
                var request = WebRequest.Create($"https://www.googleapis.com/customsearch/v1?key=AIzaSyBCUPhf6zjpYM4Dp1tsBpC7NQqOi7M8Z-U&cx=1f60956b1e32ad93d&q={Uri.EscapeDataString(searchQuery)}");
                var response = (HttpWebResponse)request.GetResponse();
                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                var responseString = reader.ReadToEnd();
                dynamic jsonData = JsonConvert.DeserializeObject(responseString);

                return double.Parse(jsonData.queries.request[0].totalResults.Value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Google search failed for {searchQuery}: {ex.Message}");
                return 0;
            }
        }
    }
}
