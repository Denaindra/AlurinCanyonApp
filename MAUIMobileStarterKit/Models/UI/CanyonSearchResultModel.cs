using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.UI
{
    public class CanyonSearchResultModel
    {
        public string CanyonName { get; set; }
        public int Rate { get; set; }
        public double CascadeHeight { get; set; }
        public DateTime DescenteActif { get; set; }
        public double CordeDistance { get; set; }
        public string Cotation { get; set; }
        public DateTime Marche { get; set; }
    }
}
