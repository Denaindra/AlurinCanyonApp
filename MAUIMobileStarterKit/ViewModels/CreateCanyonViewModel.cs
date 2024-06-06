using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.APIServices;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MAUIMobileStarterKit.ViewModels
{
    public class CreateCanyonViewModel : BaseViewModel
    {
        private readonly AddDescriptionModal addDescriptionPopup;
        private readonly AddCoordinatorModal addCoordinatorPopUp;

        private readonly ICountryProvider countryProvider;
        private readonly ILocalStorage localStorage;
        private readonly ILoading loading;
        private readonly ICanyonProvider canyonProvider;

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
        private List<Models.Service.Region> regionsList;
        private List<State> statesList;
        private List<Mountain> mountainsList;

        private List<Bassin> bassinsList;
        private List<City> citiesList;
        private List<River> riversList;


        public ObservableCollection<Coordonnee> coorddinates;
        private ObservableCollection<AccesDescent> accessDescription;

        private string country;
        private string region;
        private string state;
        private string mountain;
        private string basin;
        private string city;
        private string river;
        private string name;
        private string navetteDistance;
        private string source;
        private string entryCasMax;
        private string entryDcNote;
        private string entryAltDepart;
        private string entryLongueur;
        private string entryDeniv;
        private string entryCotation;
        private string entryCorde;
        private string userMail;
        private TimeSpan approchetemps;
        private TimeSpan descentetemps;
        private TimeSpan retourtemps;

        private bool isValidated;
        private Coordonnee selectedCoordenee;
        private AccesDescent selectedAccesDescent;
        public CreateCanyonViewModel(AddDescriptionModal addDescriptionModal, AddCoordinatorModal addCoordinatorModal,
            ILocalStorage localStorage, ILoading loading)
        {
            this.addCoordinatorPopUp = addCoordinatorModal;
            this.addDescriptionPopup = addDescriptionModal;
            this.localStorage = localStorage;
            countryProvider = GetICountryProvider();
            canyonProvider = GetICanyonProvider();
            this.loading = loading;
        }

        #region properties
        public bool IsValidated
        {
            get { return isValidated; }
            set
            {
                isValidated = value;
                NotifyPropertyChanged(nameof(IsValidated));
            }
        }
        public string UserMail
        {
            get { return userMail; }
            set
            {
                userMail = value;
                NotifyPropertyChanged(nameof(UserMail));
            }
        }
        public string NavetteDistance
        {
            get { return navetteDistance; }
            set { navetteDistance = value;
                NotifyPropertyChanged(nameof(NavetteDistance));
            }
        }
        public string Source
        {
            get { return source; }
            set { source = value;
                NotifyPropertyChanged(nameof(Source));
            }
        }
        public string River
        {
            get { return river; }
            set
            {
                river = value;
                NotifyPropertyChanged(nameof(River));
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                NotifyPropertyChanged(nameof(City));
            }
        }
        public string Basin
        {
            get { return basin; }
            set
            {
                basin = value;
                NotifyPropertyChanged(nameof(Basin));
            }
        }
        public string Mountain
        {
            get { return mountain; }
            set
            {
                mountain = value;
                NotifyPropertyChanged(nameof(Mountain));
            }
        }
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged(nameof(State));
            }
        }
        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                NotifyPropertyChanged(nameof(Region));
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                NotifyPropertyChanged(nameof(Country));
            }
        }
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                NotifyPropertyChanged(nameof(Latitude));
            }
        }
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
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
            set
            {
                period = value;
                NotifyPropertyChanged(nameof(Period));
            }
        }
        public string Geology
        {
            get { return geology; }
            set
            {
                geology = value;
                NotifyPropertyChanged(nameof(Geology));
            }
        }
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                NotifyPropertyChanged(nameof(Comment));
            }
        }
        public string History
        {
            get { return history; }
            set
            {
                history = value;
                NotifyPropertyChanged(nameof(History));
            }
        }
        public string Engagement
        {
            get { return engagement; }
            set
            {
                engagement = value;
                NotifyPropertyChanged(nameof(Engagement));

            }
        }
        public string ReturnTrip
        {
            get { return returntrip; }
            set
            {
                returntrip = value;
                NotifyPropertyChanged(nameof(ReturnTrip));

            }
        }
        public string Decent
        {
            get { return decent; }
            set
            {
                decent = value;
                NotifyPropertyChanged(nameof(Decent));

            }
        }
        public string Approach
        {
            get { return approach; }
            set
            {
                approach = value;
                NotifyPropertyChanged(nameof(Approach));

            }
        }
        public string Access
        {
            get { return access; }
            set
            {
                access = value;
                NotifyPropertyChanged(nameof(Access));
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        public string Lanuage
        {
            get { return lanuage; }
            set
            {
                lanuage = value;
                NotifyPropertyChanged(nameof(Lanuage));
            }
        }
        public TimeSpan Retourtemps
        {
            get { return retourtemps; }
            set { retourtemps = value;
                NotifyPropertyChanged(nameof(Retourtemps));
            }
        }
        public TimeSpan Descentetemps
        {
            get { return descentetemps; }
            set { descentetemps = value;
                NotifyPropertyChanged(nameof(Descentetemps));
            }
        }
        public TimeSpan Approchetemps
        {
            get { return approchetemps; }
            set { approchetemps = value;
                NotifyPropertyChanged(nameof(Approchetemps));
            }
        }
        public string EntryCorde
        {
            get { return entryCorde; }
            set { entryCorde = value;
                NotifyPropertyChanged(nameof(EntryCorde));
            }
        }
        public string EntryDeniv
        {
            get { return entryDeniv; }
            set { entryDeniv = value;
                NotifyPropertyChanged(nameof(EntryDeniv));
            }
        }
        public string EntryAltDepart
        {
            get { return entryAltDepart; }
            set { entryAltDepart = value;
                NotifyPropertyChanged(nameof(EntryAltDepart));
            }
        }
        public string EntryDcNote
        {
            get { return entryDcNote; }
            set { entryDcNote = value;
                NotifyPropertyChanged(nameof(EntryDcNote));
            }
        }
        public string EntryCasMax
        {
            get { return entryCasMax; }
            set { entryCasMax = value;
                NotifyPropertyChanged(nameof(EntryCasMax));
            }
        }
        public string EntryLongueur
        {
            get { return entryLongueur; }
            set { entryLongueur = value;
                NotifyPropertyChanged(nameof(EntryLongueur));
            }
        }
        public string EntryCotation
        {
            get { return entryCotation; }
            set { entryCotation = value;
                NotifyPropertyChanged(nameof(EntryCotation));
            }
        }
        public ObservableCollection<AccesDescent> AccessDescription
        {
            get
            {
                return accessDescription;
            }
            set
            {
                accessDescription = value;
                NotifyPropertyChanged(nameof(AccessDescription));
            }
        }

        #endregion
        public AddDescriptionModal GetAddDescriptionModal(bool ismodify)
        {
            if (ismodify)
            {
                addDescriptionPopup.isModifyAddDescriptionModal = ismodify;
            }
            else
            {
                addDescriptionPopup.isModifyAddDescriptionModal = ismodify;
            }

            addDescriptionPopup.vm = this;
            return addDescriptionPopup;
        }
        public AddCoordinatorModal GetAddCoordinatorModal(bool ismodify)
        {
            if (ismodify)
            {
                addCoordinatorPopUp.isModifyAddCoordinatiorModal = ismodify;
            }
            else
            {
                addCoordinatorPopUp.isModifyAddCoordinatiorModal = ismodify;
            }
            addCoordinatorPopUp.vm = this;
            return addCoordinatorPopUp;
        }
        public Coordonnee GetTheSelecteCoordonnedModal()
        {
            return selectedCoordenee;
        }

        public AccesDescent GetTheSelectedAccessDescriptionModal()
        {
            return selectedAccesDescent;
        }

        public void SetTheSelecteCoordonnedModal(object item)
        {
            selectedCoordenee = item as Coordonnee;
        }

        public void SetTheSelecteAccessDescriptioModal(object item)
        {
            selectedAccesDescent = item as AccesDescent;
        }
        #region
        public int GetIndexValue(string value, string[] dateValue)
        {
            var index = Array.FindIndex(dateValue, x => x == value);
            return index;
        }
        public async Task<bool> GetCountriesAsync()
        {
            try
            {
                loading.StartIndicator();
                NikeName = await localStorage.GetAsync("NickName");
                var contriesList = await countryProvider.LoadCountriesAsync(await localStorage.GetAsync("apiToken"));
                if (contriesList.Any())
                {
                    Constans.CountriesList = contriesList;
                    countriesList = contriesList.OrderBy(obj => obj.NameFr).ToList();
                    CountryList = countriesList.Select(e => e.NameFr).ToArray();
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
        public void LoadRegionList(string selectedCountry)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            regionsList = countryselected.Regions.OrderBy(c => c.Name).ToList();
            RegionList = regionsList.Select(n => n.Name).ToArray();
           
        }
        public void LoadStateList(string selectedCountry, string selectedRegion)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            statesList = regionList.States.ToList();
            StateList = regionList.States.Select(n => n.Name).ToArray();
        }
        public void LoadMountains(string selectedCountry, string selectedRegion, string selectedStates)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedStates).FirstOrDefault();
            mountainsList = stateList.Mountains.ToList();
            MountainList = stateList.Mountains.Select(n => n.Name).ToArray();
        }
        public void LoadBassinList(string selectedCountry, string selectedRegion, string selectedStates, string mountainNames)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedStates).FirstOrDefault();
            var mountainList = stateList.Mountains.Where(n => n.Name == mountainNames).FirstOrDefault();
            BassinList = mountainList.Bassins.Select(n => n.Name).ToArray();
            bassinsList = mountainList.Bassins.ToList();
        }
        public void LoadCityList(string selectedCountry, string selectedRegion, string selectedState, string mountainName, string bassingName)
        {
            var countryselected = countriesList.Where(c => c.NameFr == selectedCountry).FirstOrDefault();
            var regionList = countryselected.Regions.Where(c => c.Name == selectedRegion).FirstOrDefault();
            var stateList = regionList.States.Where(n => n.Name == selectedState).FirstOrDefault();
            var mountainList = stateList.Mountains.Where(n => n.Name == mountainName).FirstOrDefault();
            var bassin = mountainList.Bassins.Where(n => n.Name == bassingName).FirstOrDefault();
            CityList = bassin.Cities.Select(c => c.Name).ToArray();
            citiesList = bassin.Cities.ToList();
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
            riversList = city.Rivers.ToList(); 
        }
        public async Task<double[]> GetCachedLocation()
        {
            try
            {
                Location location = await Geolocation.Default.GetLocationAsync();
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
            if (Coorddinates == null)
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

        public CoordonneTypeEnum GetSelectedPointTypeIndex(int pointTypeIndex)
        {
             return (CoordonneTypeEnum)pointTypeIndex;
        }

        public void ModifyCordinateForCreateCanyon(Coordonnee coordonnee)
        {
            var oldCoordonne = Coorddinates.FirstOrDefault(id => id.Id == coordonnee.Id);
            var oldItemIndex = Coorddinates.IndexOf(oldCoordonne);
            Coorddinates[oldItemIndex] = coordonnee;
        }

        public void DeleteCordinateForCreateCanyon(Coordonnee coordonnee)
        {
            var oldCoordonne = Coorddinates.FirstOrDefault(id => id.Id == coordonnee.Id);
            var oldItemIndex = Coorddinates.Remove(oldCoordonne);
        }

        public bool SaveDescription()
        {
            if (Access != "" && Approach != "" && Decent != "" && ReturnTrip != "" && Engagement != "")
            {
                if (AccessDescription == null)
                {
                    AccessDescription = new ObservableCollection<AccesDescent>();
                }
                AccessDescription.Add(new AccesDescent()
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

        public void ModifyDescription(AccesDescent accesDescent)
        {
            var oldCoordonne = AccessDescription.FirstOrDefault(id => id.Id == accesDescent.Id);
            var oldItemIndex = AccessDescription.IndexOf(oldCoordonne);
            AccessDescription[oldItemIndex] = accesDescent;
        }

        public void DeleteDescription(AccesDescent accesDescent)
        {
            var oldCoordonne = AccessDescription.FirstOrDefault(id => id.Id == accesDescent.Id);
            var oldItemIndex = AccessDescription.Remove(oldCoordonne);
        }
        public async Task<bool> SaveCanyon(bool iscanyonModify)
        {
            loading.StartIndicator();
            var canyon = iscanyonModify ? Constans.SelectedCanyon : new Canyon();
            AccessDescription = AccessDescription == null ? new ObservableCollection<AccesDescent>() : AccessDescription; 
            Coorddinates = Coorddinates == null ? new ObservableCollection<Coordonnee>() : Coorddinates;

            canyon.AccesDescents = AccessDescription;
            canyon.Coordonnees = Coorddinates;

            try
            {
                if (AccessDescription.Any() && Coorddinates.Any() && !string.IsNullOrEmpty(Country) && !string.IsNullOrEmpty(Name) &&
                    !string.IsNullOrEmpty(Region) && !string.IsNullOrEmpty(EntryCasMax) && !string.IsNullOrEmpty(EntryDcNote) && float.Parse(EntryDcNote) >= 0
                    && float.Parse(EntryDcNote) <= 4 && !string.IsNullOrEmpty(EntryAltDepart) && float.Parse(EntryAltDepart) <= 6000 && float.Parse(EntryAltDepart) >= 0 &&
                    !string.IsNullOrEmpty(EntryDeniv) && float.Parse(EntryDeniv) <= 3000 && float.Parse(EntryDeniv) <= float.Parse(EntryAltDepart) && float.Parse(EntryDeniv) >= 0 &&
                    !string.IsNullOrEmpty(EntryLongueur) && float.Parse(EntryLongueur) <= 10000 && float.Parse(EntryLongueur) >= 0 && float.Parse(EntryCasMax) <= 600
                    && float.Parse(EntryCasMax) >= 0 && float.Parse(EntryCasMax) < float.Parse(EntryDeniv) && !string.IsNullOrEmpty(EntryCotation) && !string.IsNullOrEmpty(EntryCorde) &&
                    float.Parse(EntryCorde) <= 200 && float.Parse(EntryCorde) >= 0 && !string.IsNullOrEmpty(Approchetemps.ToString()) && !string.IsNullOrEmpty(Descentetemps.ToString()) &&
                   !string.IsNullOrEmpty(Retourtemps.ToString()) && !string.IsNullOrEmpty(NikeName))
                {

                    if (canyon.Id == 0)
                    {
                        canyon.Comments = new List<Comment>();
                        canyon.Reglementations = new List<Reglementation>();
                        canyon.Topographies = new List<Topography>();
                        canyon.Bibliographies = new List<Bibliography>();
                        canyon.Professionnals = new List<Professionnal>();
                    }
                    canyon.Name = Name;
                    canyon.PaysFr = Country;
                    canyon.RegionString = Region;
                    if (!string.IsNullOrEmpty(State))
                    {
                        canyon.Departement = State;
                    }
                    else
                    {
                        canyon.Departement = "undefined";
                    }
                    if (!string.IsNullOrEmpty(Mountain))
                    {
                        canyon.Massif = Mountain;
                    }
                    else
                    {
                        canyon.Massif = "undefined";
                    }
                    if (!string.IsNullOrEmpty(Basin))
                    {
                        canyon.BassinString = Basin;
                    }
                    else
                    {
                        canyon.BassinString = "undefined";
                    }
                    if (!string.IsNullOrEmpty(City))
                    {
                        canyon.Commune = City;
                    }
                    else
                    {
                        canyon.Commune = "undefined";
                    }
                    if (!string.IsNullOrEmpty(River))
                    {
                        canyon.Courseau = River;
                    }
                    else
                    {
                        canyon.Courseau = "undefined";
                    }

                    canyon.CountryId = countriesList.Where(c => c.NameFr == Country).Select(n => n.Id).FirstOrDefault();
                    canyon.RegionId = regionsList.Where(c => c.Name == Region).Select(n => n.Id).FirstOrDefault();
                    canyon.StateId = statesList.Where(c => c.Name == State).Select(n => n.Id).FirstOrDefault();
                    canyon.MountainId = string.IsNullOrEmpty(Mountain) ? 0 : mountainsList.Where(c => c.Name == Mountain).Select(n => n.Id).FirstOrDefault();
                    canyon.BassinId = string.IsNullOrEmpty(Basin) ? 0 : bassinsList.Where(c => c.Name == Basin).Select(n => n.Id).FirstOrDefault();
                    canyon.CityId = string.IsNullOrEmpty(City) ? 0 : citiesList.Where(c => c.Name == City).Select(n => n.Id).FirstOrDefault();
                    canyon.RiverId = string.IsNullOrEmpty(River) ? 0 : riversList.Where(c => c.Name == River).Select(n => n.Id).FirstOrDefault();
                    canyon.DcNote = float.Parse(EntryDcNote);
                    canyon.AltDepart = float.Parse(EntryAltDepart);
                    canyon.Deniv = int.Parse(EntryDeniv);
                    canyon.Longueur = int.Parse(EntryLongueur);
                    canyon.CasMax = int.Parse(EntryCasMax);
                    canyon.Cotation = EntryCotation;
                    canyon.Corde = int.Parse(EntryCorde);
                    canyon.ApprocheTime = Approchetemps;
                    canyon.DescenteTime = Descentetemps;
                    canyon.BackTime = Retourtemps;
                    canyon.Approchetemps = Approchetemps.ToString();
                    canyon.Descentetemps = Descentetemps.ToString();
                    canyon.Retourtemps = Retourtemps.ToString();
                    canyon.IsValid = IsValidated;

                    if (!string.IsNullOrEmpty(NavetteDistance))
                    {
                       canyon.NavetteDistance = float.Parse(NavetteDistance);
                    }
                    else
                    {
                        canyon.NavetteDistance = null;
                    }

                    if (!string.IsNullOrEmpty(Source))
                    {
                        canyon.Source = Source;
                    }
                    else
                    {
                        canyon.Source = "";
                    }

                    if (!string.IsNullOrEmpty(NikeName))
                    {
                        canyon.UserCreatorName = NikeName;
                    }
                    else
                    {
                        NikeName = "";
                    }

                    if (!string.IsNullOrEmpty(UserMail))
                    {
                        canyon.Useremail = "";
                    }
                    else
                    {
                        canyon.Useremail = UserMail;
                    }

                    if (canyon.Id != 0)
                    {
                        canyon.CreationDate = DateTime.Now;
                        var result = await canyonProvider.UpdateCanyon(canyon, await localStorage.GetAsync("apiToken"));
                        loading.EndIndiCator();
                        return true;
                    }
                    else
                    {
                        canyon.CreationDate = DateTime.Now;
                        var apitoken = await localStorage.GetAsync("apiToken");
                        string output = JsonConvert.SerializeObject(canyon);
                        await  canyonProvider.PostCanyon(canyon, await localStorage.GetAsync("apiToken"));
                        loading.EndIndiCator();
                        return true;
                    }
                }
                else
                {
                    loading.EndIndiCator();
                    return false;
                }
            }
            catch(Exception ex)
            {
                loading.EndIndiCator();
                return true;
            }
        }
        public async Task<bool> DeleteCanyon(long canyonId)
        {
            try
            {
                loading.StartIndicator();
                await canyonProvider.DeleteCanyon(canyonId.ToString(), await localStorage.GetAsync("apiToken"));
                return true;
            }
            catch(Exception ex)
            {
                loading.StartIndicator();
                return false;
            }
        }
        #endregion
    }
}
