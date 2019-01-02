using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class WinesListViewModel
    {
        private readonly string baseUri = "https://localhost:44361/api/wines";
        public ICommand OpenCommand { get; }

        public WinesListViewModel()
        {
            IEnumerable<WineSimple> wines = ApiHelper.GetApiResult<IEnumerable<WineSimple>>(baseUri);
            WineList = new ObservableCollection<WineSimple>(wines);
            OpenCommand = new DelegateCommand(OnOpenExecute, OnOpenCanExectute);
        }

        private bool OnOpenCanExectute()
        {
            return true;
        }

        private void OnOpenExecute()
        {
            MessageBox.Show("Hi!");
        }

        public ObservableCollection<WineSimple> WineList { get; }


    }
}
