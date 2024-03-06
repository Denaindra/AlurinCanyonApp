using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Professionnal
    {
        public int Id { get; set; }
        public int CanyonId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public bool Visible { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
    }
}
