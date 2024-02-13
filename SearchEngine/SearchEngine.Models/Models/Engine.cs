using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models.Models
{
    public class Engine : Base
    {
        public string EngineName { get; set; }
        public string EngineUrl { get; set; }
        public string EngineSearchParameter { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
