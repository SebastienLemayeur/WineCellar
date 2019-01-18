using System.ComponentModel;
using System.Runtime.CompilerServices;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class BaseViewModel<T> : INotifyPropertyChanged where T: EntityBase
    {
        protected readonly string _baseUri = "https://localhost:44361/api";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected string GetApiString()
        {
            string ApiString = _baseUri;
            switch (typeof(T).Name)
            {
                case "Wine":
                    ApiString = _baseUri + "/wines";
                    break;
                case "Producer":
                    ApiString = _baseUri + "/producers";
                    break;
                case "WineType":
                    ApiString = _baseUri + "/types";
                    break;
                default:
                    break;
            }
            return ApiString;
        }
    }
}
