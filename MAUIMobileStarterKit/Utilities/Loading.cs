using System;
using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.Interface;

namespace MAUIMobileStarterKit.Utilities
{
    public class Loading : ILoading
    {
        private readonly IUserDialogs userDialouge;
        public Loading(IUserDialogs userDialog)
        {
            this.userDialouge = userDialog;
        }

        public void EndIndiCator()
        {
            userDialouge.HideHud();
        }

        public void StartIndicator()
        {
            userDialouge.ShowLoading("Loading", MaskType.Clear);

        }
    }
}

