using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Models.UI;
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
        private ObservableCollection<CanyonSearchResultModel> livingExpenses;
        private ObservableCollection<CommentModel> comments;
        private ObservableCollection<TophoroGraphyModel> tophoroGraphyList;

        private readonly ILoading loading;
        public HomePageViewModel(ILoading loading)
        {
            this.loading = loading;
        }

        public ObservableCollection<CanyonSearchResultModel> LivingExpenses
        {
            get
            {
                return livingExpenses;
            }
            set
            {
                livingExpenses = value;
                NotifyPropertyChanged(nameof(LivingExpenses));
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
        public void LoadCannoynDetails()
        {
            try
            {
                loading.StartIndicator();
                LivingExpenses = new ObservableCollection<CanyonSearchResultModel>();
                for (int i = 0; i < 4; i++)
                {
                    LivingExpenses.Add(new CanyonSearchResultModel()
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
    }
}
