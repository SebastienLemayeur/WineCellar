using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WineGUI.Event;
using WineGUI.Helpers;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class WineDetailViewModel : ViewModelBase
    {
        private readonly string _baseUri = "https://localhost:44361/api";
        private IEventAggregator _eventAggregator;

        public ICommand SaveCommand { get; }

        public WineDetailViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
            _eventAggregator.GetEvent<OpenWineDetailViewEvent>().Subscribe(OnOpenWineDetailView);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            //TO DO also add validation and has changes
            return Wine != null;
        }

        private async void OnSaveExecute()
        {
            //This is only for saving. Need to add Post for adding new wine.
            await ApiHelper.PutCallAPI<Wine, Wine>($"{_baseUri}/wines/{Wine.Id}", Wine);
        }

        private void OnOpenWineDetailView(int wineId)
        {
            Wine = ApiHelper.GetApiResult<Wine>($"{ _baseUri}/wines/{wineId}");

            IEnumerable<Producer> producers = ApiHelper.GetApiResult<IEnumerable<Producer>>($"{_baseUri}/producers");
            ProducersList = new ObservableCollection<Producer>(producers);

            IEnumerable<WineType> types = ApiHelper.GetApiResult<IEnumerable<WineType>>($"{_baseUri}/types");
            TypesList = new ObservableCollection<WineType>(types);
        }

        private Wine _wine;

        public Wine Wine
        {
            get { return _wine; }
            set
            {
                _wine = value;
                OnPropertyChanged();
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<Producer> _producersList;

        public ObservableCollection<Producer> ProducersList
        {
            get { return _producersList; }
            set
            {
                _producersList = value;
                OnPropertyChanged();
            }

        }

        private ObservableCollection<WineType> _typesList;

        public ObservableCollection<WineType> TypesList
        {
            get { return _typesList; }
            set
            {
                _typesList = value;
                OnPropertyChanged();
            }
        }



    }
}
