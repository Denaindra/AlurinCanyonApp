using MAUIMobileStarterKit.CustomViews.Controls;
using MAUIMobileStarterKit.Screens;
namespace MAUIMobileStarterKit;

public partial class App : Application
{
    public App(CanyonBaseScreen dashBoardScreen)
    {
        InitializeComponent();
        MainPage = new NavigationPage(dashBoardScreen);
        InititateAllCutomUICmsponets();
    }

    private void InititateAllCutomUICmsponets()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
        {
#if __ANDROID__
            if (view is NoUnderlineEntry)
            {
                handler.PlatformView.Background = null;
            }
#endif

#if IOS
               handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
    }
}

