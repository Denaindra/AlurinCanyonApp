using Auth0.OidcClient;
using Controls.UserDialogs.Maui;
using Maui.GoogleMaps.Hosting;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Screens;
using MAUIMobileStarterKit.Screens.HomePageScreens;
using MAUIMobileStarterKit.Screens.SettingsScreen;
using MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;
using MAUIMobileStarterKit.Utilities;
using MAUIMobileStarterKit.ViewModels;
using Microsoft.Extensions.Logging;
using MAUIMobileStarterKit.Constant;
using CommunityToolkit.Maui;
using MAUIMobileStarterKit.Screens.AddNewItem;
namespace MAUIMobileStarterKit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUserDialogs(true, () =>
            {
#if ANDROID
                var fontFamily = "OpenSans-Regular.ttf";
#else
                var fontFamily = "OpenSans-Regular";
#endif
                AlertConfig.DefaultMessageFontFamily = fontFamily;
                AlertConfig.DefaultUserInterfaceStyle = UserInterfaceStyle.Dark;
                AlertConfig.DefaultPositiveButtonTextColor = Colors.Purple;
                ConfirmConfig.DefaultMessageFontFamily = fontFamily;
                ActionSheetConfig.DefaultMessageFontFamily = fontFamily;
                ToastConfig.DefaultMessageFontFamily = fontFamily;
                SnackbarConfig.DefaultMessageFontFamily = fontFamily;
                HudDialogConfig.DefaultMessageFontFamily = fontFamily;
            })
#if ANDROID
            .UseGoogleMaps()
#elif IOS
			.UseGoogleMaps("AIzaSyDV6Nn8IW-GcSxApE_K5e1aUqY_E9GakqY")
#endif
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Cabin-Bold.ttf", "CabinBold");
                fonts.AddFont("Cabin-Regular.ttf", "CabinRegular");
                fonts.AddFont("VinaSans-Regular.ttf", "VinaSansRegular");
            });

        builder.Services.AddSingleton(new Auth0Client(new Auth0ClientOptions
        {
            Domain = Constans.Domain,
            ClientId = Constans.ClientId,
            RedirectUri = Constans.RedirectUri,
            PostLogoutRedirectUri = Constans.PostLogoutRedirectUri,
            Scope = Constans.Scope
        }));

        //Views
        builder.Services.AddTransient<LogOutPage>();
        builder.Services.AddTransient<ContactUsPage>();
        builder.Services.AddTransient<InfoPage>();
        builder.Services.AddTransient<SecurityScreen>();
        builder.Services.AddTransient<MainSettingScreen>();
        builder.Services.AddTransient<CreateCannyonScreen>();
        builder.Services.AddSingleton<FlyoutPanelScreen>();
        builder.Services.AddTransient<HomeScreen>();
        builder.Services.AddTransient<AddCoordinatorModal>();
        builder.Services.AddTransient<AddDescriptionModal>();
        builder.Services.AddTransient<CanyonBaseScreen>();

        //ViewModels
        builder.Services.AddTransient<MainPageViewModels>();
        builder.Services.AddTransient<DashBoardViewModel>();
        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<CreateCanyonViewModel>();
        builder.Services.AddTransient<CannyonBasedViewModel>();
        builder.Services.AddTransient<ContactUsViewModel>();
        //Services
        builder.Services.AddSingleton<ILoading, Loading>();
        builder.Services.AddSingleton<ILocalStorage, LocalStorage>();
        builder.Services.AddSingleton<IPopupService, PopupService>();



#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

