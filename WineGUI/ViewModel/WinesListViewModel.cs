using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WineGUI.Helpers;
using WineLib.DTO;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class WinesListViewModel : ViewModelBase
    {
        private readonly string _baseUri = "https://localhost:44361/api/wines";


        public ICommand OpenCommand { get; }
        public ObservableCollection<WineSimple> WineList { get; }


        public WinesListViewModel()
        {
            IEnumerable<WineSimple> wines = ApiHelper.GetApiResult<IEnumerable<WineSimple>>(_baseUri);
            WineList = new ObservableCollection<WineSimple>(wines);
            OpenCommand = new DelegateCommand(OnOpenExecute, OnOpenCanExectute);
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
            MessageBox.Show($"The selected item = {_selectedWine.Id}");
        }


    }
}
