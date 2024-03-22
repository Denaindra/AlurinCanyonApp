using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class AccesDescent
    {
        public int Id { get; set; }
        public int CanyonId { get; set; }
        public string Language { get; set; }
        public string Acces { get; set; }
        public string Approche { get; set; }
        public string Descente { get; set; }
        public string Retour { get; set; }
        public string Engagement { get; set; }
        public string Historique { get; set; }
        public string Remarque { get; set; }
        public string Geologie { get; set; }
        public string Periode { get; set; }
    }
}
