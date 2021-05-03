using SearchEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace SearchEngine.Library
{
    public class Search : iSearch
    {
        public string SearchQuery { get; set; }

        public Dictionary<string, string> ApiKeys { get; set; }
    }
}
