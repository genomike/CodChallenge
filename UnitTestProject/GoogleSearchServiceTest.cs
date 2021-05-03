using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using SearchEngine.Library;
using SearchEngine.Services;
using System.Collections.Generic;
using System.Net;

namespace UnitTestProject
{
    [TestClass]
    public class GoogleSearchServiceTest
    {
        private const string searchQuery = "Java";

        [TestMethod]
        public void ProcessingSearchReturnsResults()
        {

            GoogleSearchService gss = new GoogleSearchService(new Search() { SearchQuery = searchQuery });

            gss.ProcessingService();

            Assert.IsTrue(gss.TotalResults > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void TestingEmptySearchTerm()
        {

            GoogleSearchService gss = new GoogleSearchService(new Search() { SearchQuery = string.Empty });
            gss.ProcessingService();
        }
    }
}
