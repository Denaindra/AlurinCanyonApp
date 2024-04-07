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
    public class CreateCoordinateViewModel: BaseViewModel
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

        private string nikeName;


        private List<Country> countriesList;

        public CreateCoordinateViewModel(AddDescriptionModal addDescriptionModal, AddCoordinatorModal addCoordinatorModal, 
            ILocalStorage localStorage, ILoading loading)
        {
            this.addCoordinatorModal = addCoordinatorModal;
            this.addDescriptionModal = addDescriptionModal;
            this.localStorage = localStorage;
            countryProvider = GetICountryProvider();
            this.loading = loading;
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
            set { nikeName = value;
                NotifyPropertyChanged(nameof(NikeName));
            }
        }

        public AddDescriptionModal GetAddDescriptionModal()
        {
            return addDescriptionModal;
        }

        public AddCoordinatorModal GetAddCoordinatorModal()
        {
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
                    CountryList = countriesList.Select(e=>e.NameFr).ToArray();
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
        public void LoadMountains(string selectedCountry, string selectedRegion,string selectedStates)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedStates).FirstOrDefault();
            MountainList = stateList.Mountains.Select(n => n.Name).ToArray();
        }
        public void LoadBassinList(string selectedCountry, string selectedRegion, string selectedStates,string mountainNames)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedStates).FirstOrDefault();
            var mountainList = stateList.Mountains.Where(n => n.Name== mountainNames).FirstOrDefault();
            BassinList = mountainList.Bassins.Select(n => n.Name).ToArray();
        }
        public void LoadCityList(string selectedCountry, string selectedRegion, string selectedState, string mountainName,string bassingName)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedState).FirstOrDefault();
            var mountainList = stateList.Mountains.Where(n => n.Name == mountainName).FirstOrDefault();
            var bassin = mountainList.Bassins.Where(n => n.Name== bassingName).FirstOrDefault();
            CityList = bassin.Cities.Select(c => c.Name).ToArray();
        }
        public void LoadRiverList(string selectedCountry, string selectedRegion, string selectedState, string mountainName, string bassingName,string cityName)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedState).FirstOrDefault();
            var mountainList = stateList.Mountains.Where(n => n.Name == mountainName).FirstOrDefault();
            var bassin = mountainList.Bassins.Where(n => n.Name == bassingName).FirstOrDefault();
            var city = bassin.Cities.Where(c => c.Name == cityName).FirstOrDefault();
            RiverList = city.Rivers.Select(r => r.Name).ToArray();
        }

        #endregion
    }
}
