using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Bassin
    {
        public int Id { get; set; }
        public int MountainId { get; set; }
        public string Name { get; set; }
        public virtual IList<City> Cities { get; set; }
    }
}
