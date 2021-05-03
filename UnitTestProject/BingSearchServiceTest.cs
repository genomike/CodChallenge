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
    public class BingSearchServiceTest
    {
        private const string searchQuery = ".NET";

        [TestMethod]
        public void ProcessingSearchReturnsResults()
        {
            BingSearchService bss = new BingSearchService(new Search() { SearchQuery = searchQuery });

            bss.ProcessingService();

            Assert.IsTrue(bss.TotalResults > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingEmptySearchTerm()
        {

            BingSearchService bss = new BingSearchService(new Search() { SearchQuery = string.Empty });
            bss.ProcessingService();
        }
    }
}
