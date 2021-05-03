using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Interfaces
{
    public interface iEngine
    {
        string searchQuery { get; set; }

        double ProcessingSearch();
    }
}
