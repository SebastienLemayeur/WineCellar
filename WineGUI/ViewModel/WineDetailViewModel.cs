using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WineGUI.Event;
using WineGUI.Helpers;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class WineDetailViewModel : ViewModelBase
    {
        private readonly string _baseUri = "https://localhost:44361/api";
        private IEventAggregator _eventAggregator;

        public ObservableCollection<Type> TypeList { get; }

        public WineDetailViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
            _eventAggregator.GetEvent<OpenWineDetailViewEvent>().Subscribe(OnOpenWineDetailView);
        }

        private void OnOpenWineDetailView(int wineId)
        {
            Wine = ApiHelper.GetApiResult<Wine>($"{ _baseUri}/wines/{wineId}");

            IEnumerable<Producer> producers = ApiHelper.GetApiResult<IEnumerable<Producer>>($"{_baseUri}/producers");
            ProducerList = new ObservableCollection<Producer>(producers);

            IEnumerable<Type> types = ApiHelper.GetApiResult<IEnumerable<Type>>($"{_baseUri}/types");
            TypesList = new ObservableCollection<Type>(types);
        }

        private Wine _wine;

        public Wine Wine
        {
            get { return _wine; }
            set
            {
                _wine = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Producer> _producerList;

        public ObservableCollection<Producer> ProducerList
        {
            get { return _producerList; }
            set
            {
                _producerList = value;
                OnPropertyChanged();
            }

        }

        private ObservableCollection<Type> _typesList;

        public ObservableCollection<Type> TypesList
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
