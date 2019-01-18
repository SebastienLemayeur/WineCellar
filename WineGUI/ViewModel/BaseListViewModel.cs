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
        public ICommand DeleteItemCommand { get; }
        public BaseListViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
            AddItemCommand = new DelegateCommand(OnAddItemExecute);
            DeleteItemCommand = new DelegateCommand(OnDeleteExecute, OnCanDeleteExecute);
            _eventAggregator.GetEvent<SavedDetailObjectEvent>().Subscribe(GetItemList);
            GetItemList();
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

        private bool OnCanDeleteExecute()
        {
            return SelectedWine != null;
        }

        private async void OnDeleteExecute()
        {
            await ApiHelper.DelCallAPI<T>(GetApiString() + "/{_selectedWine.Id}");
            _eventAggregator.GetEvent<ClearDetailObjectEvent>()
                    .Publish();
            GetItemList();
        }

        private ListItem _selectedWine;

        public ListItem SelectedWine
        {
            get { return _selectedWine; }
            set
            {
                _selectedWine = value;
                OnPropertyChanged();
                ((DelegateCommand)DeleteItemCommand).RaiseCanExecuteChanged();
                int wineId = _selectedWine == null ? 0 : _selectedWine.Id;
                _eventAggregator.GetEvent<OpenItemDetailViewEvent>()
                    .Publish(wineId);
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
