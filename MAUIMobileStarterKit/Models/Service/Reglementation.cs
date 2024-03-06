using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Reglementation
    {
        public int Id { get; set; }
        public int CanyonId { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public string LawTextName { get; set; }
        public DateTime? SetUpDate { get; set; }
        public string Abstract { get; set; }
        public string PathPDF { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
    }
}
