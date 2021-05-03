using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Interfaces
{
    public interface iEngineService
    {
        double TotalResults { get; }

        string EngineName { get; }

        string SearchTerm { get; }

        void ProcessingService();
    }
}
