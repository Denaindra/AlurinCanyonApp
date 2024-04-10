using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.APIServices;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{
    public class CreateCanyonViewModel : BaseViewModel
    {
        private readonly AddDescriptionModal addDescriptionModal;
        private readonly AddCoordinatorModal addCoordinatorModal;

        private readonly ICountryProvider countryProvider;
        private readonly ILocalStorage localStorage;
        private readonly ILoading loading;

        private string[] countryList;
        private string[] regionList;
        private string[] stateList;
        private string[] mountainList;
        private string[] bassinList;
        private string[] cityList;
        private string[] riverList;
        private string lanuage;
        private string access;
        private string approach;
        private string decent;
        private string returntrip;
        private string engagement;
        private string history;
        private string comment;
        private string geology;
        private string period;
        private string nikeName;
        private double latitude;
        private double longitude;

        private List<Country> countriesList;
        public ObservableCollection<Coordonnee> coorddinates;
        private ObservableCollection<AccesDescent> description;

        public CreateCanyonViewModel(AddDescriptionModal addDescriptionModal, AddCoordinatorModal addCoordinatorModal,
            ILocalStorage localStorage, ILoading loading)
        {
            this.addCoordinatorModal = addCoordinatorModal;
            this.addDescriptionModal = addDescriptionModal;
            this.localStorage = localStorage;
            countryProvider = GetICountryProvider();
            this.loading = loading;
        }
        public double Latitude
        {
            get {
                return latitude; 
            }
            set { latitude = value;
                NotifyPropertyChanged(nameof(Latitude));
            }
        }

        public double Longitude
        {
            get { 
                return longitude; 
            }
            set { longitude = value;
                NotifyPropertyChanged(nameof(Longitude));
            }
        }

        public ObservableCollection<Coordonnee> Coorddinates
        {
            get { return coorddinates; }
            set
            {
                coorddinates = value;
                NotifyPropertyChanged(nameof(Coorddinates));
            }
        }

        public string[] CountryList
        {
            get { return countryList; }
            set
            {
                countryList = value;
                NotifyPropertyChanged(nameof(CountryList));
            }
        }
        public string[] RegionList
        {
            get { return regionList; }
            set
            {
                regionList = value;
                NotifyPropertyChanged(nameof(RegionList));
            }
        }
        public string[] StateList
        {
            get { return stateList; }
            set
            {
                stateList = value;
                NotifyPropertyChanged(nameof(StateList));
            }
        }

        public string[] MountainList
        {
            get { return mountainList; }
            set
            {
                mountainList = value;
                NotifyPropertyChanged(nameof(MountainList));
            }
        }

        public string[] BassinList
        {
            get { return bassinList; }
            set
            {
                bassinList = value;
                NotifyPropertyChanged(nameof(BassinList));
            }
        }
        public string[] CityList
        {
            get { return cityList; }
            set
            {
                cityList = value;
                NotifyPropertyChanged(nameof(CityList));
            }
        }

        public string[] RiverList
        {
            get { return riverList; }
            set
            {
                riverList = value;
                NotifyPropertyChanged(nameof(RiverList));
            }
        }

        public string NikeName
        {
            get { return nikeName; }
            set
            {
                nikeName = value;
                NotifyPropertyChanged(nameof(NikeName));
            }
        }

        public string Period
        {
            get { return period; }
            set { period = value;
                NotifyPropertyChanged(nameof(Period));
            }
        }

        public string Geology
        {
            get { return geology; }
            set { geology = value;
                NotifyPropertyChanged(nameof(Geology));
            }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value;
                NotifyPropertyChanged(nameof(Comment));
            }
        }

        public string History
        {
            get { return history; }
            set { history = value;
                NotifyPropertyChanged(nameof(History));
            }
        }

        public string Engagement
        {
            get { return engagement; }
            set { engagement = value;
                NotifyPropertyChanged(nameof(Engagement));

            }
        }

        public string ReturnTrip
        {
            get { return returntrip; }
            set { returntrip = value;
                NotifyPropertyChanged(nameof(ReturnTrip));

            }
        }

        public string Decent
        {
            get { return decent; }
            set { decent = value;
                NotifyPropertyChanged(nameof(Decent));

            }
        }

        public string Approach
        {
            get { return approach; }
            set { approach = value;
                NotifyPropertyChanged(nameof(Approach));

            }
        }

        public string Access
        {
            get { return access; }
            set { access = value;
                NotifyPropertyChanged(nameof(Access));
            }
        }

        public string Lanuage
        {
            get { return lanuage; }
            set { lanuage = value;
                NotifyPropertyChanged(nameof(Lanuage));
            }
        }

        public ObservableCollection<AccesDescent> Description
        {
            get { return 
                    description;
            }
            set { description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }

        public AddDescriptionModal GetAddDescriptionModal()
        {
            addDescriptionModal.vm = this;
            return addDescriptionModal;
        }

        public AddCoordinatorModal GetAddCoordinatorModal()
        {
            addCoordinatorModal.vm = this;
            return addCoordinatorModal;
        }

        #region
        public async void GetCountriesAsync()
        {
            try
            {
                loading.StartIndicator();
                NikeName = await localStorage.GetAsync("NickName");
                var contriesList = await countryProvider.LoadCountriesAsync(await localStorage.GetAsync("apiToken"));
                if (contriesList.Any())
                {
                    countriesList = contriesList.OrderBy(obj => obj.NameFr).ToList();
                    CountryList = countriesList.Select(e => e.NameFr).ToArray();
                }
            }
            catch (Exception ex)
            {

            }
            loading.EndIndiCator();
        }

        public void LoadRegionList(string selectedCountry)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            RegionList = countryselected.Regions.OrderBy(c => c.Name).Select(n => n.Name).ToArray();
        }
        public void LoadStateList(string selectedCountry, string selectedRegion)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            StateList = regionList.States.Select(n => n.Name).ToArray();
        }
        public void LoadMountains(string selectedCountry, string selectedRegion, string selectedStates)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedStates).FirstOrDefault();
            MountainList = stateList.Mountains.Select(n => n.Name).ToArray();
        }
        public void LoadBassinList(string selectedCountry, string selectedRegion, string selectedStates, string mountainNames)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedStates).FirstOrDefault();
            var mountainList = stateList.Mountains.Where(n => n.Name == mountainNames).FirstOrDefault();
            BassinList = mountainList.Bassins.Select(n => n.Name).ToArray();
        }
        public void LoadCityList(string selectedCountry, string selectedRegion, string selectedState, string mountainName, string bassingName)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedState).FirstOrDefault();
            var mountainList = stateList.Mountains.Where(n => n.Name == mountainName).FirstOrDefault();
            var bassin = mountainList.Bassins.Where(n => n.Name == bassingName).FirstOrDefault();
            CityList = bassin.Cities.Select(c => c.Name).ToArray();
        }
        public void LoadRiverList(string selectedCountry, string selectedRegion, string selectedState, string mountainName, string bassingName, string cityName)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedState).FirstOrDefault();
            var mountainList = stateList.Mountains.Where(n => n.Name == mountainName).FirstOrDefault();
            var bassin = mountainList.Bassins.Where(n => n.Name == bassingName).FirstOrDefault();
            var city = bassin.Cities.Where(c => c.Name == cityName).FirstOrDefault();
            RiverList = city.Rivers.Select(r => r.Name).ToArray();
        }

        public async Task<double[]> GetCachedLocation()
        {
            try
            {
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();
                Latitude = location.Latitude;
                Longitude = location.Longitude;
                if (location != null)
                    return new double[] { location.Latitude, location.Longitude };
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            return new double[0];
        }

        public void AddCordinateForCreateCanyon(int pointTypeIndex) 
        {
            if(Coorddinates == null)
            {
                Coorddinates = new ObservableCollection<Coordonnee>();
            }
            var cordinates = new Coordonnee()
            {
                Lat = Latitude,
                Long = Longitude,
                PointType = (CoordonneTypeEnum)pointTypeIndex
            };
            Coorddinates.Add(cordinates);
        }


        public bool SaveDescription()
        {
            if (Access != "" && Approach != "" && Decent != "" && ReturnTrip != "" && Engagement != "")
            {
                if (Description == null)
                {
                    Description = new ObservableCollection<AccesDescent>();
                }
                Description.Add(new AccesDescent()
                {
                    Acces = Access,
                    Language = Lanuage,
                    Approche = Approach,
                    Descente = Decent,
                    Retour = ReturnTrip,
                    Engagement = Engagement,
                    Historique = History,
                    Remarque = Comment,
                    Geologie = Geology,
                    Periode = Period
                });
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
