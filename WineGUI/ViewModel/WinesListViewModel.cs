using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WineGUI.Event;
using WineGUI.Helpers;
using WineLib.DTO;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class WinesListViewModel : ViewModelBase
    {
        private readonly string _baseUri = "https://localhost:44361/api/wines";

        private IEventAggregator _eventAggregator;

        public ICommand OpenCommand { get; }


        public WinesListViewModel()
        {
            GetWineList();
            OpenCommand = new DelegateCommand(OnOpenExecute, OnOpenCanExectute);
            _eventAggregator = EventAggregatorSingleton.Instance;
            _eventAggregator.GetEvent<SavedWineEvent>().Subscribe(UpdateNavigation);
        }

        private void UpdateNavigation(WineSimple wineSimple)
        {
            //to do: calls API again, better might be just updating the WineList with the item..
            GetWineList();
        }

        private void GetWineList()
        {
            IEnumerable<WineSimple> wines = ApiHelper.GetApiResult<IEnumerable<WineSimple>>($"{_baseUri}/simple");
            WineList = new ObservableCollection<WineSimple>(wines);
        }

        private ObservableCollection<WineSimple> _wineList;

        public ObservableCollection<WineSimple> WineList
        {
            get { return _wineList; }
            set
            {
                _wineList = value;
                OnPropertyChanged();
            }
        }


        private WineSimple _selectedWine;

        public WineSimple SelectedWine
        {
            get { return _selectedWine; }
            set
            {
                _selectedWine = value;
                OnPropertyChanged();
                ((DelegateCommand)OpenCommand).RaiseCanExecuteChanged();
            }
        }


        private bool OnOpenCanExectute()
        {
            return SelectedWine != null;
        }

        private void OnOpenExecute()
        {
            if (_selectedWine != null)
            {
                _eventAggregator.GetEvent<OpenWineDetailViewEvent>()
                    .Publish(_selectedWine.Id);
            }
        }


    }
}
