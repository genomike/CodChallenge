using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using SearchEngine.Request;
using System.Net;

namespace UnitTestProject
{
    [TestClass]
    public class GoogleEngineTest
    {
        private const string searchQuery = ".NET";

        [TestMethod]
        public void ProcessingSearchReturnsResults()
        {
            GoogleEngine ge = new GoogleEngine() { searchQuery = searchQuery };

            var totalResults = ge.ProcessingSearch();

            Assert.IsTrue(totalResults > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void TestingEmptySearchTerm()
        {

            GoogleEngine ge = new GoogleEngine() { searchQuery = string.Empty };
            ge.ProcessingSearch();
        }
    }
}
