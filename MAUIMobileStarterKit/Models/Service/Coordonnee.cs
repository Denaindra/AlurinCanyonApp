using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Coordonnee
    {
        public int Id { get; set; }
        public int CanyonId { get; set; }
        public CoordonneTypeEnum PointType { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
    }
    public enum CoordonneTypeEnum
    {
        // Mistake during the scrapping of the website, I start with 1 for ParkingAmont and not 0
        ExtraPoint,
        ParkingAmont,
        ParkingAval,
        Parking,
        StartCanyon,
        EndCanyon,
        ExternalPoint,
        InternalPoint
    }
}
