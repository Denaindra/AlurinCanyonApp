using System;
using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.Interface;

namespace MAUIMobileStarterKit.ViewModels
{
	public class MainPageViewModels: BaseViewModel
    {
        private readonly ILoading loading;
        public MainPageViewModels(ILoading loading)
		{
            this.loading = loading;
		}

        public void StartLoading()
        {
            loading.StartIndicator();
        }

        public void EndLoading()
        {
            loading.EndIndiCator();
        }
    }
}

