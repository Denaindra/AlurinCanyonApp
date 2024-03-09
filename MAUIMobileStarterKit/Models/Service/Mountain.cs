using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Mountain
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public virtual IList<Bassin> Bassins { get; set; }
    }
}
