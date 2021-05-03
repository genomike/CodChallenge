using Microsoft.Extensions.Configuration;
using SearchEngine.Interfaces;
using SearchEngine.Library;
using SearchEngine.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine.GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Missing search terms");
                Console.ReadKey();
                return;
            }

            try
            {
                List<iEngineService> engineServiceList = new List<iEngineService>();

                //Preparing search process list
                engineServiceList.AddRange(
                    args.Where(searchTerm => !string.IsNullOrEmpty(searchTerm)).Select(searchTerm =>
                        new GoogleSearchService(new Search() { SearchQuery = searchTerm })));

                engineServiceList.AddRange(
                    args.Where(searchTerm => !string.IsNullOrEmpty(searchTerm)).Select(searchTerm =>
                        new BingSearchService(new Search() { SearchQuery = searchTerm })));

                engineServiceList.AddRange(
                    args.Where(searchTerm => !string.IsNullOrEmpty(searchTerm)).Select(searchTerm =>
                        new YahooSearchService(new Search() { SearchQuery = searchTerm })));

                // Proccessing search actions ...
                Console.WriteLine("processing ...");
                engineServiceList.ForEach(exec => exec.ProcessingService());

                // Showing results ...
                Console.Clear();

                // General Results
                args.ToList().ForEach(argument =>
                {
                    Console.WriteLine($"{argument}: {string.Join(",", engineServiceList.Where(e => e.SearchTerm == argument && e.TotalResults > 0).Select(engine => $"{engine.EngineName}: {engine.TotalResults}"))}");
                });
            http://api.search.yahoo.com/WebSearchService
                // Wieners by Argument
                args.ToList().ForEach(argument =>
                {
                    Console.WriteLine($"{argument}: wiener {engineServiceList.Where(engine => engine.SearchTerm == argument).OrderByDescending(engine => engine.TotalResults).First().EngineName}");
                });

                // Total wienner
                Console.WriteLine($"Total Wiener: {engineServiceList.OrderByDescending(engine => engine.TotalResults).First().SearchTerm}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
