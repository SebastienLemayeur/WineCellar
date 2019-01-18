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
    class WinesListViewModel : BaseListViewModel
    {
        public ICommand AddWineCommand { get; }
        public ICommand DeleteWineCommand { get; }


        public WinesListViewModel()
        {
            GetItemList();
            AddWineCommand = new DelegateCommand(OnAddWineExecute);
            DeleteWineCommand = new DelegateCommand(OnDeleteExecute, OnCanDeleteExecute);
            _eventAggregator.GetEvent<SavedDetailObjectEvent>().Subscribe(GetItemList);
        }

        private bool OnCanDeleteExecute()
        {
            return SelectedWine != null;
        }

        private async void OnDeleteExecute()
        {
            await ApiHelper.DelCallAPI<Wine>($"{_baseUri}/wines/{_selectedWine.Id}");
            _eventAggregator.GetEvent<ClearDetailObjectEvent>()
                    .Publish();
            GetItemList();
        }

        private void OnAddWineExecute()
        {
            _eventAggregator.GetEvent<ClearDetailObjectEvent>()
                    .Publish();
        }

        private ListItem _selectedWine;

        public ListItem SelectedWine
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
