using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Interface.APIServices;
using Refit;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIMobileStarterKit.ViewModels
{
	public class BaseViewModel: INotifyPropertyChanged
    {
        public INavigation navigation;
        public event PropertyChangedEventHandler PropertyChanged;

        private static ICanyonProvider iCannyonProvider;
        private static ItokenProvider itokenProvider;
        private static ICountryProvider iCountryProvider;
        private static ICommentProvider iCommentProvider;
        private static ITopographyProvider iTopographyProvider;
        private static IProfessionalProvider iProfessionalProvider;
        public BaseViewModel()
		{
		}

        public IProfessionalProvider GetIProfessionalProvider()
        {
            if (iProfessionalProvider is null)
            {
                iProfessionalProvider = RestService.For<IProfessionalProvider>(Constans.BASEDURL);
            }
            return iProfessionalProvider;
        }
        public ITopographyProvider GetITopographyProvider()
        {
            if (iTopographyProvider is null)
            {
                iTopographyProvider = RestService.For<ITopographyProvider>(Constans.BASEDURL);
            }
            return iTopographyProvider;
        }
        public ICommentProvider GetICommentProvider()
        {
            if (iCommentProvider is null)
            {
                iCommentProvider = RestService.For<ICommentProvider>(Constans.BASEDURL);
            }
            return iCommentProvider;
        }
        public ICountryProvider GetICountryProvider()
        {
            if (iCountryProvider is null)
            {
                iCountryProvider = RestService.For<ICountryProvider>(Constans.BASEDURL);
            }
            return iCountryProvider;
        }
        public ItokenProvider GetItokenProvider()
        {
            if (itokenProvider is null)
            {
                itokenProvider = RestService.For<ItokenProvider>(Constans.TOKENBASEDURL);
            }
            return itokenProvider;
        }
        public ICanyonProvider GetICanyonProvider()
        {
            if (iCannyonProvider is null)
            {
                iCannyonProvider = RestService.For<ICanyonProvider>(Constans.BASEDURL);
            }
            return iCannyonProvider;
        }
        public async void PushModalAsync(Page page)
        {
            await navigation.PushModalAsync(page);  
        }
        public async void PushAsyncPage(Page page)
        {
            await navigation.PushAsync(page);
        }
        public async void PopAsyncy()
        {
            await navigation.PopAsync();
        }
        public async void PopModalAsyncy()
        {
            await navigation.PopModalAsync();
        }
        public async Task<bool> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return true;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return true;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return true;
        }
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

