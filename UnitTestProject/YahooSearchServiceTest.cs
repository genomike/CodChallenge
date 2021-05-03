using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using SearchEngine.Library;
using SearchEngine.Services;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class YahooSearchServiceTest
    {
        private const string searchQuery = ".NET";

        [TestMethod]
        public void ProcessingSearchReturnsResults()
        {
            YahooSearchService bss = new YahooSearchService(new Search() { SearchQuery = searchQuery });

            bss.ProcessingService();

            Assert.IsTrue(bss.TotalResults > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingEmptySearchTerm()
        {

            YahooSearchService bss = new YahooSearchService(new Search() { SearchQuery = string.Empty });
            bss.ProcessingService();
        }
    }
}
