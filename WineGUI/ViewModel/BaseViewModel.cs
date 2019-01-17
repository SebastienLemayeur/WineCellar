using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WineGUI.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly string _baseUri = "https://localhost:44361/api";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
