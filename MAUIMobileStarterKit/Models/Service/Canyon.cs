using Kotlin.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Canyon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public Country Country { get; set; }
        public int? CountryId { get; set; }
        public string PaysFr { get; set; }

        //public Region Region { get; set; }
        public int? RegionId { get; set; }
        public string RegionString { get; set; }
        //public State State { get; set; }
        public int? StateId { get; set; }
        public string Departement { get; set; }
        // public City City { get; set; }
        public int? CityId { get; set; }
        public string Commune { get; set; }
        //public Mountain Mountain { get; set; }
        public int? MountainId { get; set; }
        public string Massif { get; set; }
        // public Bassin Bassin { get; set; }
        public int? BassinId { get; set; }
        public string BassinString { get; set; }
        // public River River { get; set; }
        public int? RiverId { get; set; }
        public string Courseau { get; set; }
        public float? DcNote { get; set; }
        public float? AltDepart { get; set; }
        public int Deniv { get; set; }
        public int Longueur { get; set; }
        public int CasMax { get; set; }
        public string Cotation { get; set; }
        public int Corde { get; set; }
        public string Approchetemps { get; set; }
        public string Descentetemps { get; set; }
        public string Retourtemps { get; set; }
        public TimeSpan ApprocheTime { get; set; }
        public TimeSpan DescenteTime { get; set; }
        public TimeSpan BackTime { get; set; }
        public float? NavetteDistance { get; set; }
        public bool IsVisible { get; set; }
        public string Source { get; set; }
        public string UserCreatorName { get; set; }
        public virtual IList<Coordonnee> Coordonnees { get; set; }
        //public Coordonnee Parking { get { return Coordonnees.FirstOrDefault(c => c.PointType == "Parking");  } }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<AccesDescent> AccesDescents { get; set; }
        public virtual IList<Topography> Topographies { get; set; }
        public virtual IList<Bibliography> Bibliographies { get; set; }
        public virtual IList<Reglementation> Reglementations { get; set; }
        public virtual IList<Professionnal> Professionnals { get; set; }
        public DateTime CreationDate { get; set; }
        public Boolean IsValid { get; set; }
        public string Useremail { get; set; }
    }
}
