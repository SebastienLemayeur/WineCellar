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
using WineLib.DTO;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class WineDetailViewModel : BaseDetailViewModel<Wine>
    {

        public WineDetailViewModel()
        {
            _eventAggregator.GetEvent<OpenWineDetailViewEvent>().Subscribe(OnOpenWineDetailView);
            OnOpenWineDetailView(0);
            DetailObject = new Wine();
        }

        private void OnOpenWineDetailView(int wineId)
        {
            if (wineId != 0) DetailObject = ApiHelper.GetApiResult<Wine>($"{ _baseUri}/wines/{wineId}");

            IEnumerable<Producer> producers = ApiHelper.GetApiResult<IEnumerable<Producer>>($"{_baseUri}/producers");
            ProducersList = new ObservableCollection<Producer>(producers);

            IEnumerable<WineType> types = ApiHelper.GetApiResult<IEnumerable<WineType>>($"{_baseUri}/types");
            TypesList = new ObservableCollection<WineType>(types);
        }

        private ObservableCollection<Producer> _producersList;

        public ObservableCollection<Producer> ProducersList
        {
            get { return _producersList; }
            set
            {
                _producersList = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DetailObject));
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
                OnPropertyChanged(nameof(DetailObject));
            }
        }


    }
}
