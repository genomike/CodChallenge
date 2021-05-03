using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Microsoft.CSharp.RuntimeBinder;
using System;
using SearchEngine.Request;

namespace UnitTestProject
{
    [TestClass]
    public class BingEngineTest
    {
        private const string searchQuery = ".NET";

        [TestMethod]
        public void ProcessingSearchReturnsResults()
        {
            BingEngine be = new BingEngine() { searchQuery = searchQuery };

            var totalResults = be.ProcessingSearch();

            Assert.IsTrue(totalResults > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingEmptySearchTerm()
        {

            BingEngine be = new BingEngine() { searchQuery = string.Empty };
            be.ProcessingSearch();
        }
    }
}
