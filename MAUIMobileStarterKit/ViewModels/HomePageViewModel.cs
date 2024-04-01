using IdentityModel.OidcClient;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.APIServices;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.Models.UI;
using MAUIMobileStarterKit.Screens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{
    public class HomePageViewModel:BaseViewModel
    {
        private ObservableCollection<CanyonSearchResultModel> cannyonDetails;
        private ObservableCollection<CommentModel> comments;
        private ObservableCollection<TophoroGraphyModel> tophoroGraphyList;
        private ObservableCollection<CanyonCountry> canyonCountryList;
        private ObservableCollection<Canyon> getCanyonFromRegion;

        private readonly ILoading loading;
        private readonly CanyonBaseScreen canyonBaseScreen;

        private readonly ICanyonProvider canyonProvider;
        private readonly ICountryProvider countryProvider;
        private readonly ICommentProvider commentProvider;
        private readonly ITopographyProvider topographyProvider;

        private readonly ILocalStorage localStorage;
        private string[] countryList;
        private string[] regionList;
        private string[] stateList;

        public HomePageViewModel(ILocalStorage localStorage,ILoading loading,CanyonBaseScreen canyonBaseScreen)
        {
            this.loading = loading;
            this.localStorage = localStorage;
            this.canyonBaseScreen = canyonBaseScreen;
            canyonProvider = RecentChatServiceEndPoint();
            countryProvider = GetICountryProvider();
            commentProvider = GetICommentProvider();
            topographyProvider = GetITopographyProvider();
        }

        public ObservableCollection<CanyonSearchResultModel> CannyonDetails
        {
            get
            {
                return cannyonDetails;
            }
            set
            {
                cannyonDetails = value;
                NotifyPropertyChanged(nameof(CannyonDetails));
            }
        }
        public ObservableCollection<TophoroGraphyModel> TophoroGraphyList
        {
            get
            {
                return tophoroGraphyList;
            }
            set
            {
                tophoroGraphyList = value;
                NotifyPropertyChanged(nameof(TophoroGraphyList));
            }
        }
        public ObservableCollection<CommentModel> Comments
        {
            get
            {
                return comments;
            }
            set
            {
                comments = value;
                NotifyPropertyChanged(nameof(Comments));
            }
        }
        public ObservableCollection<CanyonCountry> CanyonCountryList
        {
            get { return canyonCountryList; }
            set
            {
                canyonCountryList = value;
                NotifyPropertyChanged(nameof(CanyonCountryList));
            }
        }
        public ObservableCollection<Canyon> CanyonListDetails
        {
            get { return getCanyonFromRegion; }
            set
            {
                getCanyonFromRegion = value;
                NotifyPropertyChanged(nameof(CanyonListDetails));
            }
        }
        public string[] CountryList
        {
            get { return countryList; }
            set { countryList = value;
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
        public void LoadCannoynDetails()
        {
            try
            {
                loading.StartIndicator();
                CannyonDetails = new ObservableCollection<CanyonSearchResultModel>();
                for (int i = 0; i < 4; i++)
                {
                    CannyonDetails.Add(new CanyonSearchResultModel()
                    {
                        CanyonName = "Bkitokifaitha",
                        CascadeHeight = i*2,
                        CordeDistance = i*2,
                        Cotation = "via2i1",
                        DescenteActif = DateTime.Now,
                        Marche = DateTime.Now,
                        Rate = 3
                    });
                }
                loading.EndIndiCator();
            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
            }
        }
        public void LoadCommentDetails()
        {
            try
            {
                loading.StartIndicator();
                Comments = new ObservableCollection<CommentModel>();
                    Comments.Add(new CommentModel()
                    {
                        Date = DateTime.Now,
                        Name = "Wsasas",
                        WaterFlow = "Few water",
                        WroitternBy = "RicRdsfsdihil"
                    });
                    Comments.Add(new CommentModel()
                    {
                        Date = DateTime.Now,
                        Name = "Tailsa",
                        WaterFlow = "Few water",
                        WroitternBy = "Ricihil"
                    });
                    Comments.Add(new CommentModel()
                    {
                        Date = DateTime.Now,
                        Name = "Rewsas",
                        WaterFlow = "Few water",
                        WroitternBy = "Vdsdsd"
                    });

                loading.EndIndiCator();
            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
            }
        }
        public ILoading GetLoading()
        {
            return loading;
        }
        public void TopographyDetails()
        {
            try
            {
                loading.StartIndicator();
                TophoroGraphyList = new ObservableCollection<TophoroGraphyModel>();
                TophoroGraphyList.Add(new TophoroGraphyModel()
                {
                    Date = DateTime.Now,
                    Name = "Wsasas",
                    Type = "Few water",
                    CreatedBy = "RicRdsfsdihil"
                });
                TophoroGraphyList.Add(new TophoroGraphyModel()
                {
                    Date = DateTime.Now,
                    Name = "Tailsa",
                    Type = "Few water",
                    CreatedBy = "Ricihil"
                });
                TophoroGraphyList.Add(new TophoroGraphyModel()
                {
                    Date = DateTime.Now,
                    Name = "Rewsas",
                    Type = "Few water",
                    CreatedBy = "Vdsdsd"
                });

                loading.EndIndiCator();
            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
            }
        }
        public void NavigateToCannyonBasePage()
        {
            loading.StartIndicator();
            PushModalAsync(canyonBaseScreen);
        }


        #region service calls
        public async void LoadCanyonCountriesAsync()
        {
            loading.StartIndicator();
            try
            {
                var countryList = await countryProvider.LoadCanyonCountriesAsync(await localStorage.GetAsync("apiToken"));
                if (countryList.Any())
                {
                    CanyonCountryList = new ObservableCollection<CanyonCountry>();
                    foreach (var item in countryList)
                    {
                        CanyonCountryList.Add(item);
                    }
                    CountryList = countryList.Select(country => country.Country.NameFr).ToArray();
                }
            }
            catch (Exception ex)
            {

            }
            loading.EndIndiCator();
        }
        public async void GetCannyonNamesList(string canynnonSearchText)
        {
            loading.StartIndicator();
            try
            {
                var apitoken = await localStorage.GetAsync("apiToken");
                var results = await canyonProvider.GetCanyonName(canynnonSearchText, apitoken);
            }
            catch(Exception ex)
            {

            }
            loading.EndIndiCator();
        }
        public void LoadTheRegionBasedOnSelectedCountry(string selectedCountry)
        {
            var countryselected = CanyonCountryList.Where(c => c.Country.NameFr == selectedCountry).ToList();
            if (countryselected[0].Country.Regions.Any())
            {
                RegionList = countryselected[0].Country.Regions.Select(region => region.Name).ToArray();
            }
        }
        public void LoadTheStateBasedOnSelectedCountryAndRegion(string selectedCountry,string selectedRegion)
        {
            var countryselected = CanyonCountryList.Where(c => c.Country.NameFr == selectedCountry).ToList();
            var regionList = countryselected[0].Country.Regions.Where(region => region.Name== selectedRegion).ToArray();
            if (regionList[0].States.Any())
            {
                StateList = regionList[0]?.States.Select(state => state.Name).ToArray();
            }
        }
        public async void SearchCannyon(string countrySelectedItem, string regionSelectedItme, string stateSelectedItem)
        {
            loading.StartIndicator();
            try
            {
                var recenttoekns = new GetCanyonFromRegionParams()
                {
                  country = countrySelectedItem,
                  region = regionSelectedItme,
                  state = stateSelectedItem,
                };

                var canyonList = await canyonProvider.GetCanyonFromRegion(recenttoekns, await localStorage.GetAsync("apiToken"));
                if (canyonList.Any())
                {
                    CanyonListDetails = new ObservableCollection<Canyon>();
                    foreach (var item in canyonList)
                    {
                        CanyonListDetails.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            loading.EndIndiCator();
        }

        public async void GetCommentCanyonLastDays(int days)
        {
            try
            {
              loading.StartIndicator();
              var results = await commentProvider.GetCommentCanyonLastDays(days, await localStorage.GetAsync("apiToken"));
            }
            catch(Exception ex)
            {
                
            }
            loading.EndIndiCator();
        }

        public async void GetTopographyProviderLastDay(int days)
        {
            try
            {
                loading.StartIndicator();
                var results = await topographyProvider.GetTopoCanyonLastDays(days, await localStorage.GetAsync("apiToken"));
            }
            catch (Exception ex)
            {
                
            }
            loading.EndIndiCator();
        }

        public async void GetCannyonProviderLastDay(int days)
        {
            try
            {
                loading.StartIndicator();
                var results = await canyonProvider.GetCanyonLastDays(days, await localStorage.GetAsync("apiToken"));
            }
            catch (Exception ex)
            {

            }
            loading.EndIndiCator();
        }

        public async void ValidateCanyon()
        {
            try
            {
                loading.StartIndicator();
                var validateCanyonresults = await canyonProvider.UnvalidatedCanyon(await localStorage.GetAsync("apiToken"));
                if (validateCanyonresults.Any())
                {
                    CanyonListDetails = new ObservableCollection<Canyon>();
                    foreach (var item in validateCanyonresults)
                    {
                        CanyonListDetails.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            loading.EndIndiCator();
        }

        public async Task<List<CustomPin>> GetAllCoordinates()
        {
            List <CustomPin> customPins= new List <CustomPin>();

            try
            {
                loading.StartIndicator();
                customPins = await canyonProvider.GetAllCoordinate(await localStorage.GetAsync("apiToken"));
            }
            catch (Exception ex)
            {

            }
            loading.EndIndiCator();
            return customPins;
     
        }

        public async Task<List<Canyon>> UnvalidatedCanyon()
        {
           List<Canyon> customPins = new List<Canyon>();

            try
            {
                loading.StartIndicator();
                customPins = await canyonProvider.UnvalidatedCanyon(await localStorage.GetAsync("apiToken"));
            }
            catch (Exception ex)
            {

            }
            loading.EndIndiCator();
            return customPins;
        }

        #endregion
    }
}
