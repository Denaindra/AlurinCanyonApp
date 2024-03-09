using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.APIServices;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.Models.UI;
using MAUIMobileStarterKit.Screens;
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


        private readonly ILoading loading;
        private readonly CanyonBaseScreen canyonBaseScreen;
        private readonly ICanyonProvider recentChatServiceEndPoint;
        private readonly ICountryProvider countryProvider;
        private readonly ILocalStorage localStorage;


        public HomePageViewModel(ILocalStorage localStorage,ILoading loading,CanyonBaseScreen canyonBaseScreen)
        {
            this.loading = loading;
            this.localStorage = localStorage;
            this.canyonBaseScreen = canyonBaseScreen;
            recentChatServiceEndPoint = RecentChatServiceEndPoint();
            countryProvider = GetICountryProvider();
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

        private string[] countryList;

        public string[] CountryList
        {
            get { return countryList; }
            set { countryList = value;
                NotifyPropertyChanged(nameof(CountryList));
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
                var results = await recentChatServiceEndPoint.GetCanyonName(canynnonSearchText, apitoken);
            }
            catch(Exception ex)
            {

            }
            loading.EndIndiCator();
        }


        #endregion
    }
}
