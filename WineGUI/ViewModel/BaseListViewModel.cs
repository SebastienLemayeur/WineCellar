using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineGUI.Event;
using WineGUI.Helpers;
using WineLib.DTO;

namespace WineGUI.ViewModel
{
    class BaseListViewModel<T> : BaseViewModel
    { 
        protected IEventAggregator _eventAggregator;
        public ICommand AddItemCommand { get; }
        public BaseListViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
            AddItemCommand = new DelegateCommand(OnAddItemExecute);
        }

        protected void GetItemList()
        {
            IEnumerable<ListItem> list = ApiHelper.GetApiResult<IEnumerable<ListItem>>(GetApiString() + "/simple");
            ItemList = new ObservableCollection<ListItem>(list);
        }

        private void OnAddItemExecute()
        {
            _eventAggregator.GetEvent<ClearDetailObjectEvent>()
                    .Publish();
        }

        private ObservableCollection<ListItem> _itemList;

        public ObservableCollection<ListItem> ItemList
        {
            get { return _itemList; }
            set
            {
                _itemList = value;
                OnPropertyChanged();
            }
        }

        private string GetApiString()
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
