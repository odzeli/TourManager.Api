using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Domain.Models.AboutColumn
{
    public class SplittedColumns
    {
        public List<string> StringColumns { get; set; } 
        public List<string> DateColumns { get; set; }
        public List<string> NumberColumns { get; set; }
        public List<string> GuidColumns { get; set; }
        public List<string> BoolColumns { get; set; }
    }
}
