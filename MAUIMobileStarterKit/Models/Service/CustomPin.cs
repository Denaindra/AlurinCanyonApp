using Maui.GoogleMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class CustomPin:Pin
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int CanyonId { get; set; }
        public Coordonnee Coordonnee { get; set; }
        public float? DcNote { get; set; }
        public int PointType { get; set; }
        public string DcNoteText { get { return "Note: " + DcNote; } }
        public Pin MapPin { get; set; }
    }
}
