using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class City
    {
        public int Id { get; set; }
        public int BassinId { get; set; }
        public string Name { get; set; }
        public virtual IList<River> Rivers { get; set; }
    }
}
