using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineGUI.Helpers;
using WineLib.DTO;

namespace WineGUI.ViewModel
{
    class BaseListViewModel : BaseViewModel
    { 
        protected IEventAggregator _eventAggregator;

        public BaseListViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
        }

        protected void GetItemList()
        {
            IEnumerable<ListItem> list = ApiHelper.GetApiResult<IEnumerable<ListItem>>($"{_baseUri}/wines/simple");
            ItemList = new ObservableCollection<ListItem>(list);
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
    }
}
