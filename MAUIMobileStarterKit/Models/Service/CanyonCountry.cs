using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class CanyonCountry
    {
        public Country Country { get; set; }
        public Region Region { get; set; }
        public State State { get; set; }
        public Mountain Mountain { get; set; }
        public Bassin Bassin { get; set; }
        public City City { get; set; }
        public River River { get; set; }
    }
}
