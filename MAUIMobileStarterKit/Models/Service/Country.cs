using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Country
    {
        public int Id { get; set; }
        public string IsoPays { get; set; }
        public string NameEn { get; set; }
        public string NameEs { get; set; }
        public string NameIt { get; set; }
        public string NameFr { get; set; }
        public virtual IList<Region> Regions { get; set; }
    }
}
