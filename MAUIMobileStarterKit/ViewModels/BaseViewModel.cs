using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIMobileStarterKit.ViewModels
{
	public class BaseViewModel: INotifyPropertyChanged
    {
        public INavigation navigation;
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
		{
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

