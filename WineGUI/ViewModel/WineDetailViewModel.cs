using Prism.Events;
using System;
using System.Collections.Generic;
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
        private readonly string _baseUri = "https://localhost:44361/api/wines";
        private IEventAggregator _eventAggregator;

        public WineDetailViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
            _eventAggregator.GetEvent<OpenWineDetailViewEvent>().Subscribe(OnOpenWineDetailView);
        }

        private void OnOpenWineDetailView(int wineId)
        {
            _wine = ApiHelper.GetApiResult<Wine>($"{ _baseUri}/{wineId}");
            MessageBox.Show($"{WineFull.DrinkBefore}");
        }

        private Wine _wine;

        public Wine WineFull
        {
            get { return _wine; }
            set
            {
                _wine = value;
                OnPropertyChanged();
            }
        }

    }
}
