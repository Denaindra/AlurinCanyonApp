using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Bibliography
    {
        public int Id { get; set; }
        public int CanyonId { get; set; }
        public string BookName { get; set; }
        public string Authors { get; set; }
        public string Page { get; set; }
        public int Year { get; set; }
    }
}
