using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Interfaces
{
    public interface iSearch
    {
        string SearchQuery { get; set; }

        Dictionary<string, string> ApiKeys { get; set; }
    }
}
