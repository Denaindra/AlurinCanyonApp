using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class State
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public virtual IList<Mountain> Mountains { get; set; }
    }
}
