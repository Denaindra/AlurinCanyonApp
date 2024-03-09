using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Region
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public virtual IList<State> States { get; set; }
    }
}
