using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models.Models
{
    public class SearchInfo : Base
    {
        public string Url { get; set; }

        [ForeignKey("Engine")]
        public int EngineId { get; set; }

        public Engine Engine { get; set; }

        public string Keywords { get; set; }

        public DateTime SearchDate { get; set; }
        public int Occurance { get; set; }
        public string Rank { get; set; }
    }
}
