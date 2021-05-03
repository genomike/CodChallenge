using SearchEngine.Interfaces;
using SearchEngine.Request;

namespace SearchEngine.Services
{
    public class GoogleSearchService : iEngineService
    {
        private double _totalResults;

        private string _engineName;

        private iSearch _search;

        public double TotalResults { get { return _totalResults; } }

        public string EngineName { get { return _engineName; } }

        public string SearchTerm { get { return _search.SearchQuery; } }

        public GoogleSearchService(iSearch search)
        {
            _totalResults = 0;
            _engineName = "Google";
            _search = search;
        }

        public void ProcessingService()
        {
            iEngine searchEngine = new GoogleEngine() { searchQuery = _search.SearchQuery };
            _totalResults = searchEngine.ProcessingSearch();
        }
    }
}
