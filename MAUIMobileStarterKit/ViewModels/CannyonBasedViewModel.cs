using Maui.GoogleMaps;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.APIServices;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.Models.UI;
using System.Collections.ObjectModel;

namespace MAUIMobileStarterKit.ViewModels
{
    public class CannyonBasedViewModel:BaseViewModel
    {
        private ObservableCollection<Topography> topographiesList;
        private ObservableCollection<ReglementationsModal> reglementationsList;
        private ObservableCollection<CommentListModal> commentList;
        private ObservableCollection<ProCanyonModal> professioanlList;
        private ObservableCollection<Canyon> canyonList;

        private readonly ICanyonProvider canyonProvider;
        private readonly ICountryProvider countryProvider;

        private readonly ILocalStorage localStorage;
        private readonly ILoading loading;

        private string photoPath;
        private ObservableCollection<Country> countries;
        private ObservableCollection<AccesDescent> commentsList;

        private double meanLat;
        public double LatMax;
        private double LatMin;
        private double meanLong;
        private double LongMax;
        private double LongMin;
        private double PointDistance;

        public CannyonBasedViewModel(ILoading loading, ILocalStorage localStorage)
        {
            this.loading = loading;
            this.localStorage = localStorage;
            canyonProvider = GetICanyonProvider();
            countryProvider = GetICountryProvider();
        }

        public string PhotoPath
        {
            get { 
                return photoPath; 
            }
            set { 
                photoPath = value;
                NotifyPropertyChanged(nameof(PhotoPath));
            }
        }
        public ObservableCollection<CommentListModal> CommentList
        {
            get
            {
                return commentList;
            }
            set
            {
                commentList = value;
                NotifyPropertyChanged(nameof(CommentList));
            }
        }
        public ObservableCollection<ReglementationsModal> ReglementationsList
        {
            get
            {
                return reglementationsList;
            }
            set
            {
                reglementationsList = value;
                NotifyPropertyChanged(nameof(ReglementationsList));
            }
        }
        public ObservableCollection<Topography> TopographiesList
        {
            get
            {
                return topographiesList;
            }
            set
            {
                topographiesList = value;
                NotifyPropertyChanged(nameof(TopographiesList));
            }
        }
        public ObservableCollection<ProCanyonModal> ProfessioanlList
        {
            get
            {
                return professioanlList;
            }
            set
            {
                professioanlList = value;
                NotifyPropertyChanged(nameof(ProfessioanlList));
            }
        }
        public ObservableCollection<Canyon>  CanyonList
        {
            get { return canyonList; }
            set { canyonList = value;
                NotifyPropertyChanged(nameof(CanyonList));
            }
        }
        public ObservableCollection<Country> CountriesList
        {
            get { return countries; }
            set {
                countries = value;
                NotifyPropertyChanged(nameof(CountriesList));
            }
        }
        public ObservableCollection<AccesDescent> CommentsList
        {
            get { return commentsList; }
            set
            {
                commentsList = value;
                NotifyPropertyChanged(nameof(CommentsList));
            }
        }


        public void LoadTopographies()
        {
            try
            {
                // loading.StartIndicator();
                TopographiesList = new ObservableCollection<Topography>();
                foreach (var topoItem in Constans.SelectedCanyon.Topographies)
                {
                    //if (App.userApp.Role == "Administrator")
                    //{
                    //    topo.IsAuthorize = true;
                    //}
                    //else
                    //{
                    topoItem.IsAuthorize = false;
                    //}
                    TopographiesList.Add(topoItem);
                }
                
                // loading.EndIndiCator();
            }
            catch (Exception ex)
            {
                //  loading.EndIndiCator();
            }
        }
        public void LoadReglementation()
        {
            try
            {
                // loading.StartIndicator();
                ReglementationsList = new ObservableCollection<ReglementationsModal>();
                for (int i = 0; i < 4; i++)
                {
                    ReglementationsList.Add(new ReglementationsModal()
                    {
                        Abstract="Sample Abstract",
                        Action="Sample action",
                        LawTextName="sample law text name",
                        SetupDate="2023/08/23",
                        Status="sample status"
                    });
                }
                // loading.EndIndiCator();
            }
            catch (Exception ex)
            {
                //  loading.EndIndiCator();
            }
        }
        public void LoadCommentList()
        {
            try
            {
                // loading.StartIndicator();
                CommentList = new ObservableCollection<CommentListModal>();
                for (int i = 0; i < 4; i++)
                {
                    CommentList.Add(new CommentListModal()
                    {
                        AirFeeling = "sample aire feeling",
                        CreationDate = "2023/3/23",
                        Debit = "Sample debit",
                        DoneOrView = "Done",
                        Id = "12",
                        UserComment = "test comment",
                        UserName = "abc123",
                        WaterFeeling = "Good"
                    });
                }
                // loading.EndIndiCator();
            }
            catch (Exception ex)
            {
                //  loading.EndIndiCator();
            }
        }
        public async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using (var stream = await photo.OpenReadAsync())
                    using (var newStream = File.OpenWrite(localFilePath))
                    {
                        await stream.CopyToAsync(newStream);
                    }

                    PhotoPath = localFilePath;
                }
            }
        }
        public void LoadPerforssioanlList()
        {
            try
            {
                // loading.StartIndicator();
                ProfessioanlList = new ObservableCollection<ProCanyonModal>();
                for (int i = 0; i < 4; i++)
                {
                    ProfessioanlList.Add(new ProCanyonModal()
                    {
                        Address = "Sample Address",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, ",
                        Email = "sample Email",
                        Logo = "sample Logo",
                        Phone = "sample phone",
                        Name = "sample Name",
                        Website = "www.sampleWebsite.com"
                    });
                }
                // loading.EndIndiCator();
            }
            catch (Exception ex)
            {
                //  loading.EndIndiCator();
            }
        }
        public void StartIndicator()
        {
            loading.StartIndicator();
        }
        public void EndIndiCator()
        {
            loading.EndIndiCator();
        }
        public async Task WatteForBackGroundSteup()
        {
            await Task.Delay(5000);
            EndIndiCator();
        }
        
        #region api calls
        public async Task<bool> GetCanyonList(string region)
        {
            try
            {
                loading.StartIndicator();
                var canyonListresults = await canyonProvider.GetCanyon(Constans.CanyonNumber, await localStorage.GetAsync("apiToken"));
                if (canyonListresults != null)
                {
                    CanyonList = new ObservableCollection<Canyon>()
                    {
                        canyonListresults
                    };
                }

                GetCommentsBasedOnTheRegion(region);

            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
                return false;
            }
            loading.EndIndiCator();
            return true;

        }
        public async Task<bool> GetCountriesAsync()
        {
            try
            {
                loading.StartIndicator();
                var contriesList = await countryProvider.LoadCountriesAsync(await localStorage.GetAsync("apiToken"));
                if (contriesList.Any())
                {
                    Constans.CountriesList = contriesList;
                    CountriesList = new ObservableCollection<Country>();
                    foreach (var country in contriesList)
                    {
                        CountriesList.Add(country);
                    }
                }
            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
                return false;
            }
            loading.EndIndiCator();
            return true;
        }

        public void GetCommentsBasedOnTheRegion(string region)
        {
            var result = CanyonList[0].AccesDescents.Where(a => a.Language == region);
            CommentsList = new ObservableCollection<AccesDescent>(CanyonList[0].AccesDescents.Where(a => a.Language == region));
        }

        public double GetMeanlat()
        {
            return meanLat;
        }
        public double GetMeanLong()
        {
            return meanLong;
        }
        public double GetPointDistance()
        {
            return PointDistance;
        }
        public void SetUpCoordinateDetails()
        {
                meanLat = Constans.SelectedCanyon.Coordonnees.Average(c => c.Lat);
                LatMax = Constans.SelectedCanyon.Coordonnees.Max(c => c.Lat);
                LatMin = Constans.SelectedCanyon.Coordonnees.Min(c => c.Lat);
                meanLong = Constans.SelectedCanyon.Coordonnees.Average(c => c.Long);
                LongMax = Constans.SelectedCanyon.Coordonnees.Max(c => c.Long);
                LongMin = Constans.SelectedCanyon.Coordonnees.Min(c => c.Long);
                PointDistance = Location.CalculateDistance(LatMin, LongMin, LatMax, LongMax, 0) + 0.5;
        }
        #endregion
    }
}
