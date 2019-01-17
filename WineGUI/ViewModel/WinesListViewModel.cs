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
using WineGUI.View;
using WineLib.DTO;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class WinesListViewModel : BaseViewModel
    {
        private readonly string _baseUri = "https://localhost:44361/api/wines";

        private IEventAggregator _eventAggregator;

        public ICommand AddWineCommand { get; }
        public ICommand DeleteWineCommand { get; }
        private AddWineWindow _addWineWindow { get; set; }


        public WinesListViewModel()
        {
            GetWineList();
            AddWineCommand = new DelegateCommand(OnAddWineExecute);
            DeleteWineCommand = new DelegateCommand(OnDeleteExecute, OnCanDeleteExecute);
            _eventAggregator = EventAggregatorSingleton.Instance;
            _eventAggregator.GetEvent<SavedWineEvent>().Subscribe(UpdateNavigation);
        }

        private bool OnCanDeleteExecute()
        {
            return SelectedWine != null;
        }

        private async void OnDeleteExecute()
        {
            await ApiHelper.DelCallAPI<Wine>($"{_baseUri}/{_selectedWine.Id}");
            _eventAggregator.GetEvent<DeletedWineEvent>()
                    .Publish();
            UpdateNavigation(_selectedWine);
        }

        private void OnAddWineExecute()
        {
            _addWineWindow = new AddWineWindow();
            _addWineWindow.Show();
        }

        private void UpdateNavigation(WineSimple wineSimple)
        {
            //to do: calls API again, better might be just updating the WineList with the item..
            GetWineList();
            if (_addWineWindow != null && wineSimple.Id == 0) _addWineWindow.Close();
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
                ((DelegateCommand)DeleteWineCommand).RaiseCanExecuteChanged();
                int wineId = _selectedWine == null ? 0 : _selectedWine.Id;
                _eventAggregator.GetEvent<OpenWineDetailViewEvent>()
                    .Publish(wineId);
            }
        }


    }
}
