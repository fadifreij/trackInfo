using SearchEngine.Models.Models;
using System.Collections.Generic;

namespace SearchEngine.Models
{
    public class EngineViewModel
    {
        public Engine Engine { get; set; }
        public IEnumerable<Engine> EngineList { get; set; }
    }
}
