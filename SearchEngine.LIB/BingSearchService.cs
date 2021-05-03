using SearchEngine.Interfaces;
using SearchEngine.Request;
using System;

namespace SearchEngine.Services
{
    public class BingSearchService : iEngineService
    {
        private double _totalResults;

        private string _engineName;

        private iSearch _search;

        public double TotalResults { get { return _totalResults; } }

        public string EngineName { get { return _engineName; } }

        public string SearchTerm { get { return _search.SearchQuery; } }

        public BingSearchService(iSearch search)
        {
            _totalResults = 0;
            _engineName = "Bing";
            _search = search;
        }

        public void ProcessingService()
        {
            if (string.IsNullOrEmpty(SearchTerm)) throw new ArgumentException("Empty search Term");

            iEngine searchEngine = new BingEngine() { searchQuery = _search.SearchQuery };
            _totalResults = searchEngine.ProcessingSearch();
        }
    }
}
