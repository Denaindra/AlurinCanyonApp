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
    }
}
