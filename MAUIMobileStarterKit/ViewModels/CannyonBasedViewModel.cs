
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.APIServices;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.Models.UI;
using MAUIMobileStarterKit.Screens.AddNewItem;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MAUIMobileStarterKit.ViewModels
{
    public class CannyonBasedViewModel : BaseViewModel
    {
        private ObservableCollection<Topography> topographiesList;
        private ObservableCollection<Reglementation> reglementationsList;
        private ObservableCollection<Comment> commentList;
        private ObservableCollection<Professionnal> professioanlList;
        private ObservableCollection<Canyon> canyonList;

        private readonly ICanyonProvider canyonProvider;
        private readonly ICountryProvider countryProvider;
        private readonly ITopographyProvider topoProvider;
        private readonly ICommentProvider commentProvider;
        private readonly IProfessionalProvider professionalProvider;

        private readonly ILocalStorage localStorage;
        private readonly ILoading loading;
        private readonly IPopupService popupService;

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

        public CannyonBasedViewModel(ILoading loading, ILocalStorage localStorage, IPopupService popupService)
        {
            this.loading = loading;
            this.localStorage = localStorage;
            canyonProvider = GetICanyonProvider();
            countryProvider = GetICountryProvider();
            topoProvider = GetITopographyProvider();
            commentProvider = GetICommentProvider();
            professionalProvider = GetIProfessionalProvider();
            this.popupService = popupService;
        }
        public string PhotoPath
        {
            get
            {
                return photoPath;
            }
            set
            {
                photoPath = value;
                NotifyPropertyChanged(nameof(PhotoPath));
            }
        }
        public ObservableCollection<Comment> CommentList
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
        public ObservableCollection<Reglementation> ReglementationsList
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
        public ObservableCollection<Professionnal> ProfessioanlList
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
        public ObservableCollection<Canyon> CanyonList
        {
            get { return canyonList; }
            set
            {
                canyonList = value;
                NotifyPropertyChanged(nameof(CanyonList));
            }
        }
        public ObservableCollection<Country> CountriesList
        {
            get { return countries; }
            set
            {
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
        public void OpenAddTopoCanyonPopup()
        {
            popupService.ShowPopup(new AddTopoCanyon(this));
        }
        public void OpenAddCommentCanyonPopup()
        {
            popupService.ShowPopup(new AddCommentPopup(this));
        }
        public void OpenProPopup()
        {
            popupService.ShowPopup(new ProAddPopup(this));
        }
        public void OpenReglementationAddPagePopup()
        {
            popupService.ShowPopup(new ReglementationAddPage(this));
        }
        public async Task<bool> LoadTopographies()
        {
            try
            {
                loading.StartIndicator();
                TopographiesList = new ObservableCollection<Topography>();
                var topoCanyonResuelts = await topoProvider.GetTopoCanyon(Constans.SelectedCanyon.Id);

                foreach (var topoItem in topoCanyonResuelts)
                {
                    topoItem.IsAuthorize = false;
                    topoItem.IsValidTopo = false;
                    TopographiesList.Add(topoItem);
                }
                Constans.SelectedCanyon.Topographies = topoCanyonResuelts;
                loading.EndIndiCator();

            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
                return false;
            }
            finally
            {
                loading.EndIndiCator();
            }
            return true;
        }
        public void LoadReglementation()
        {
            try
            {
                ReglementationsList = new ObservableCollection<Reglementation>();
                foreach (var regle in Constans.SelectedCanyon.Reglementations.OrderByDescending(r => r.SetUpDate))
                {
                    ReglementationsList.Add(regle);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void LoadCommentList()
        {
            try
            {
                CommentList = new ObservableCollection<Comment>();
                foreach (var regle in Constans.SelectedCanyon.Comments.OrderByDescending(r => r.CreationDate.Date))
                {
                    CommentList.Add(regle);
                }
            }
            catch (Exception ex)
            {
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
                ProfessioanlList = new ObservableCollection<Professionnal>();
                foreach (var pro in Constans.SelectedCanyon.Professionnals.OrderByDescending(p => p.Id))
                {
                    ProfessioanlList.Add(pro);
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
        public async Task<string> GetLocalStorageProeprties(string key)
        {
            if (String.Equals("NickName", key))
            {
                return await localStorage.GetAsync("NickName");
            }
            else if (string.Equals("UserName", key))
            {
                return await localStorage.GetAsync("Name");
            }
            else if (string.Equals("Email", key))
            {
                return await localStorage.GetAsync("Email");
            }

            return string.Empty;
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
        public async Task<bool> AddTopoCanyon(int seletedtedIndex, bool stackSwitchRiveIsVisible, bool isToggeled, string commentoftheuser, List<int> numswithSize, string obstacleSize, int typeDangerSelectedIndex)
        {
            loading.StartIndicator();
            try
            {
                var userTopo = new Topography();
                userTopo.CanyonId = Constans.SelectedCanyon.Id;
                userTopo.TypeDanger = DangerTypeEnum.None;
                userTopo.PositionPoint = PositionPoint.None;

                if (seletedtedIndex >= 0)
                {
                    userTopo.TypeObstacle = (ObstacleTypeEnum)seletedtedIndex;
                    if (stackSwitchRiveIsVisible)
                    {
                        if (isToggeled)
                        {
                            userTopo.PositionPoint = PositionPoint.RiveDroite;
                        }
                        else
                        {
                            userTopo.PositionPoint = PositionPoint.RiveGauche;
                        }
                    }
                    else
                    {

                    }
                    userTopo.TopoComment = commentoftheuser;
                    //if (App.userApp.Role == "Administrator")
                    //{
                    //    userTopo.IsValidTopo = true;
                    //}
                    //else
                    {
                        userTopo.IsValidTopo = false;
                    }
                }
                else
                {
                    //  DisplayAlert(AppResources.AppResources.MessageError, AppResources.AppResources.MessageEnterAllValues, "OK");
                    return false;
                }
                if (numswithSize.Contains(seletedtedIndex))
                {
                    if (!string.IsNullOrEmpty(obstacleSize))
                    {
                        userTopo.TailleObstacle = obstacleSize;
                    }
                    else
                    {
                        // DisplayAlert(AppResources.AppResources.MessageError, AppResources.AppResources.MessageEnterAllValues, "OK");
                        return false;
                    }
                }

                if (seletedtedIndex == 0)
                {
                    if (typeDangerSelectedIndex >= 0)
                    {
                        userTopo.TypeDanger = (DangerTypeEnum)typeDangerSelectedIndex;
                    }
                    else
                    {
                        //DisplayAlert(AppResources.AppResources.MessageError, AppResources.AppResources.MessageEnterAllValues, "OK");
                        return false;
                    }
                }

                if (userTopo.TypeDanger == DangerTypeEnum.Drossage)
                {
                    userTopo.ImageDanger = "watercycle.png";
                }
                if (userTopo.TypeDanger == DangerTypeEnum.RockFall)
                {
                    userTopo.ImageDanger = "ChutePierre.png";
                }
                if (userTopo.TypeDanger == DangerTypeEnum.RopeBlocking)
                {
                    userTopo.ImageDanger = "Coincement.png";
                }
                if (userTopo.TypeDanger == DangerTypeEnum.RopeFriction)
                {
                    userTopo.ImageDanger = "Coupe.png";
                }
                if (userTopo.TypeDanger == DangerTypeEnum.Slippery)
                {
                    userTopo.ImageDanger = "slippery.png";
                }
                if (userTopo.TypeDanger == DangerTypeEnum.Syphon)
                {
                    userTopo.ImageDanger = "Syphon.png";
                }

                if (userTopo.TypeObstacle == ObstacleTypeEnum.Barrage)
                {
                    userTopo.ImageObstacle = "Barrage.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Danger)
                {
                    userTopo.ImageObstacle = "Desescalade.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Escape)
                {
                    userTopo.ImageObstacle = "Echap.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Road)
                {
                    userTopo.ImageObstacle = "road.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.RocksChaos)
                {
                    userTopo.ImageObstacle = "Desescalade_1.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.RunningHand)
                {
                    userTopo.ImageObstacle = "Maincourante.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Siphon)
                {
                    userTopo.ImageObstacle = "Syphon.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Toboggan)
                {
                    userTopo.ImageObstacle = "Toboggan.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Trees)
                {
                    userTopo.ImageObstacle = "AmarrageNaturel.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Tributary)
                {
                    userTopo.ImageObstacle = "tributary.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Tunnel)
                {
                    userTopo.ImageObstacle = "cave.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Walking)
                {
                    userTopo.ImageObstacle = "Marche.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Waterfall)
                {
                    userTopo.ImageObstacle = "Cascade.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.jump)
                {
                    userTopo.ImageObstacle = "Saut.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.swimming)
                {
                    userTopo.ImageObstacle = "Nage.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.relais)
                {
                    userTopo.ImageObstacle = "Relais.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.monopoint)
                {
                    userTopo.ImageObstacle = "Monopoint.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Exit)
                {
                    userTopo.ImageObstacle = "Exit.png";
                }
                if (userTopo.TypeObstacle == ObstacleTypeEnum.Bridge)
                {
                    userTopo.ImageObstacle = "bridge.png";
                }

                userTopo.CreationDate = DateTime.Now;
                userTopo.UserName = await localStorage.GetAsync("Name");
                await topoProvider.PostTopo(userTopo);
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {

                loading.EndIndiCator();

            }
            return true;
        }
        public async Task<bool> SendComments(int flowPickerIndex, int airTempPickerIndex, int waterTempPickerIndex, string commentoftheuser, bool nickNameswith, bool seeorDone,
            DateTime dateTime)
        {

            Comment usercomment = new Comment();
            loading.StartIndicator();
            try
            {
                if (dateTime <= DateTime.Today)
                {
                    usercomment.CreationDate = dateTime;
                }
                else
                {
                    //DisplayAlert(AppResources.AppResources.MessageError, AppResources.AppResources.MessageDateProblem, "OK");
                    return false;
                }
                if (flowPickerIndex >= 0 && airTempPickerIndex >= 0 && waterTempPickerIndex >= 0 && !string.IsNullOrEmpty(commentoftheuser))
                {
                    if (nickNameswith)
                    {
                        usercomment.UserName = await GetLocalStorageProeprties("NickName");
                    }
                    else
                    {
                        usercomment.UserName = await GetLocalStorageProeprties("UserName");
                    }

                    usercomment.Useremail = await GetLocalStorageProeprties("Email");
                    usercomment.CanyonId = Constans.SelectedCanyon.Id;
                    if (seeorDone)
                    {
                        usercomment.DoneOrView = "Done";
                    }
                    else
                    {
                        usercomment.DoneOrView = "View";
                    }
                    usercomment.Debit = (DebitEnum)flowPickerIndex;
                    usercomment.AirFeeling = (AirFeeling)airTempPickerIndex;
                    usercomment.WaterFeeling = (WaterFeeling)waterTempPickerIndex;
                    usercomment.UserComment = commentoftheuser;

                    await commentProvider.PostComment(usercomment, await localStorage.GetAsync("apiToken"));
                    var isUpdateComments = await GetComments(Constans.SelectedCanyon.Id);
                    return true;
                }
                else
                {
                    // DisplayAlert(AppResources.AppResources.MessageError, AppResources.AppResources.MessageEnterAllValues, "OK");
                    return false;
                }
            }
            catch (Exception e)
            {

                loading.EndIndiCator();
                return true;
            }
            finally
            {
                loading.EndIndiCator();
            }
        }
        public async Task<bool> GetComments(int selectedCanyonId)
        {
            try
            {
              Constans.SelectedCanyon.Comments = await commentProvider.GetCommentCanyon(selectedCanyonId, await localStorage.GetAsync("apiToken"));
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public async Task<bool> SavePro(string entryLogoText, string entryNameText, string entryAdressText, string entryPhoneText, string entryEmailText, string entryUrlwebsiteproText, string entryDescriptionText, DateTime date)
        {
            try
            {
                loading.StartIndicator();
                Professionnal proAddbyAdmin = new Professionnal();

                if (entryNameText != null && entryPhoneText != null && entryDescriptionText != null)
                {
                    proAddbyAdmin.CanyonId = Constans.SelectedCanyon.Id;
                    proAddbyAdmin.Name = entryNameText;
                    proAddbyAdmin.Description = entryDescriptionText;
                    proAddbyAdmin.Phone = entryPhoneText;
                    if (entryAdressText != null || entryAdressText != "")
                    {
                        proAddbyAdmin.Adress = entryAdressText;
                    }
                    if (entryLogoText != null || entryLogoText != "")
                    {
                        proAddbyAdmin.Logo = entryLogoText;
                    }
                    if (entryEmailText != null || entryEmailText != "")
                    {
                        proAddbyAdmin.Email = entryEmailText;
                    }
                    if (entryUrlwebsiteproText != null || entryUrlwebsiteproText != "")
                    {
                        proAddbyAdmin.Website = entryUrlwebsiteproText;
                    }
                    proAddbyAdmin.CreationDate = date;

                    await professionalProvider.PostPro(await localStorage.GetAsync("apiToken"), proAddbyAdmin);
                    loading.EndIndiCator();
                    return true;
                }
                else
                {
                    loading.EndIndiCator();
                    return false;

                }

            }
            catch (Exception ex)
            {
                loading.EndIndiCator();
                return false;
            }


        }

        public async void GetPro()
        {
            try
            {
                loading.StartIndicator();
                var results = await professionalProvider.GetProsCanyon(await localStorage.GetAsync("apiToken"), Constans.SelectedCanyon.Id);
                Constans.SelectedCanyon.Professionnals = results;
                loading.EndIndiCator();
            }
            catch(Exception ex)
            {
                loading.EndIndiCator();
            }
        }
        #endregion
    }
}
