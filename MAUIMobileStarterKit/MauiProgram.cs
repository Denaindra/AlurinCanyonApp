using Controls.UserDialogs.Maui;
using Maui.GoogleMaps.Hosting;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Screens;
using MAUIMobileStarterKit.Utilities;
using MAUIMobileStarterKit.ViewModels;
using Microsoft.Extensions.Logging;
namespace MAUIMobileStarterKit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseUserDialogs(true, () =>
            {
#if ANDROID
                var fontFamily = "OpenSans-Default.ttf";
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

        //Views
        builder.Services.AddTransient<HomeScreen>();
        builder.Services.AddTransient<DashBoardScreen>();
        builder.Services.AddTransient<ContactUsPage>();

        //ViewModels
        builder.Services.AddTransient<MainPageViewModels>();
        builder.Services.AddTransient<DashBoardViewModel>();
        builder.Services.AddTransient<HomePageViewModel>();

        //Services
        builder.Services.AddSingleton<ILoading, Loading>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

