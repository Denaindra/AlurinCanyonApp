﻿using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.APIServices;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.Models.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{
    public class CannyonBasedViewModel:BaseViewModel
    {
        private ObservableCollection<ResumeCanyonCommentList> canyonCommentList;
        private ObservableCollection<TopographiesModal> topographiesList;
        private ObservableCollection<ReglementationsModal> reglementationsList;
        private ObservableCollection<CommentListModal> commentList;
        private ObservableCollection<ProCanyonModal> professioanlList;
        private string photoPath;
        private ObservableCollection<Canyon> canyonList;

        private readonly ICanyonProvider canyonProvider;
        private readonly ILocalStorage localStorage;

        private readonly ILoading loading;
        public CannyonBasedViewModel(ILoading loading, ILocalStorage localStorage)
        {
            this.loading = loading;
            canyonProvider = RecentChatServiceEndPoint();
            this.localStorage = localStorage;
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
        public ObservableCollection<TopographiesModal> TopographiesList
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
        public ObservableCollection<ResumeCanyonCommentList> CanyonCommentList
        {
            get
            {
                return canyonCommentList;
            }
            set
            {
                canyonCommentList = value;
                NotifyPropertyChanged(nameof(CanyonCommentList));
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




        public void LoadCannoynDetails()
        {
            try
            {
               // loading.StartIndicator();
                CanyonCommentList = new ObservableCollection<ResumeCanyonCommentList>();
                for (int i = 0; i < 4; i++)
                {
                    CanyonCommentList.Add(new ResumeCanyonCommentList()
                    {
                        Acces = "Access",
                        Approche = "Approche",
                        Descent = "Descent",
                        Engagement = "Engagement",
                        Retour = "Retour",
                        Geologie = "Geologie",
                        Historique = "Historique",
                        Periode = "Periode",
                        Remarque = "Remarque"
                    });
                }
               // loading.EndIndiCator();
            }
            catch (Exception ex)
            {
              //  loading.EndIndiCator();
            }
        }
        public void LoadTopographies()
        {
            try
            {
                // loading.StartIndicator();
                TopographiesList = new ObservableCollection<TopographiesModal>();
                for (int i = 0; i < 4; i++)
                {
                    TopographiesList.Add(new TopographiesModal()
                    {
                        PositionPoint = "89.003434",
                        TailleObstacle = "sample TailleObstacle",
                        TopoComment= "sample topocomment",
                        TypeDanger = "sample typedanger",
                        TypeObstacle = "sample typo obstavle"
                    });
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

        public async void GetCanyonList()
        {
            try
            {
                CanyonList = new ObservableCollection<Canyon>();
                loading.StartIndicator();
                var canyonListresults = await canyonProvider.GetCanyon(Constans.CanyonNumber, await localStorage.GetAsync("apiToken"));
                if (canyonListresults != null)
                {
                    CanyonList.Add(canyonListresults);
                }     
            }
            catch (Exception ex)
            {

            }
            loading.EndIndiCator();
        }
        #endregion
    }
}
