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
        private ObservableCollection<CanyonCommentList> canyonCommentList;
        private ObservableCollection<UserCreator> userCreatorList;
        private ObservableCollection<TopographiesModal> topographiesList;
        public CannyonBasedViewModel()
        {
            
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
        public ObservableCollection<CanyonCommentList> CanyonCommentList
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
                CanyonCommentList = new ObservableCollection<CanyonCommentList>();
                for (int i = 0; i < 4; i++)
                {
                    CanyonCommentList.Add(new CanyonCommentList()
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
    }
}
