using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Microsoft.CSharp.RuntimeBinder;
using System;
using SearchEngine.Request;

namespace UnitTestProject
{
    [TestClass]
    public class YahooEngineTest
    {
        private const string searchQuery = ".NET";

        [TestMethod]
        public void ProcessingSearchReturnsResults()
        {
            YahooEngine be = new YahooEngine() { searchQuery = searchQuery };

            var totalResults = be.ProcessingSearch();

            Assert.IsTrue(totalResults > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingEmptySearchTerm()
        {

            YahooEngine be = new YahooEngine() { searchQuery = string.Empty };
            be.ProcessingSearch();
        }
    }
}
