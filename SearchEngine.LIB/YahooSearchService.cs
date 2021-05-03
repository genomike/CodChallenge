using SearchEngine.Interfaces;
using SearchEngine.Library;
using SearchEngine.Request;
using System;

namespace SearchEngine.Services
{
    public class YahooSearchService : iEngineService
    {
        private double _totalResults;

        private string _engineName;

        private iSearch _search;

        public double TotalResults { get { return _totalResults; } }

        public string EngineName { get { return _engineName; } }

        public string SearchTerm { get { return _search.SearchQuery; } }

        public YahooSearchService(iSearch search)
        {
            _totalResults = 0;
            _engineName = "Yahoo";
            _search = search;
        }

        public void ProcessingService()
        {
            if (string.IsNullOrEmpty(SearchTerm)) throw new ArgumentException("Empty search Term");

            iEngine searchEngine = new YahooEngine() { searchQuery = _search.SearchQuery };
            _totalResults = searchEngine.ProcessingSearch();
        }
    }
}
