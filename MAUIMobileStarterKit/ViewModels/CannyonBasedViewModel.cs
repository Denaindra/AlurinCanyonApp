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
        private ObservableCollection<UserCreator> userCreatorList;
        private ObservableCollection<TopographiesModal> topographiesList;
        private ObservableCollection<ReglementationsModal> reglementationsList;
        private ObservableCollection<CommentListModal> commentList;
        public CannyonBasedViewModel()
        {
            
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
        public ObservableCollection<UserCreator> UserCreatorList
        {
            get
            {
                return userCreatorList;
            }
            set
            {
                userCreatorList = value;
                NotifyPropertyChanged(nameof(UserCreatorList));
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

        public void LoadUserCreators()
        {
            try
            {
                // loading.StartIndicator();
                UserCreatorList = new ObservableCollection<UserCreator>();
                for (int i = 0; i < 4; i++)
                {
                    UserCreatorList.Add(new UserCreator()
                    {
                       UserCreatorName = "Abdre",
                       Source = "Text We image"
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
    }
}
