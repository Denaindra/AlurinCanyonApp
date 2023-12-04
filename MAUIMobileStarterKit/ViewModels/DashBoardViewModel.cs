using MAUIMobileStarterKit.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{

    public class DashBoardViewModel:BaseViewModel
    {
        private readonly HomeScreen homeScreen;
        public DashBoardViewModel(HomeScreen homeScreen)
        {
            this.homeScreen = homeScreen;
        }


        public void PageNavigationSteup(int index)
        {
            switch (index)
            {
                case 0:
                    PushAsyncPage(homeScreen);
                    break;
                case 2:
                   
                    break;
                case 3:
                    
                    break;
                default:
                    
                    break;
            }

        }
    }
}
