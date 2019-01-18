using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineGUI.Event;
using WineGUI.Helpers;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class DetailBaseViewModel <T> : BaseViewModel where T : EntityBase
    {
        public ICommand SaveCommand { get; }
        protected IEventAggregator _eventAggregator;

        public DetailBaseViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return true;
        }

        private async void OnSaveExecute()
        {
            if (DetailObject.Id != 0) await UpdateDetailObject();
            else await SaveDetailObject();
        }

        private async Task UpdateDetailObject()
        {
            await ApiHelper.PutCallAPI<T, T>($"{_baseUri}/wines/{DetailObject.Id}", DetailObject);

            _eventAggregator.GetEvent<SavedDetailObjectEvent>()
                    .Publish(DetailObject.Id);
        }

        private async Task SaveDetailObject()
        {
            await ApiHelper.PostCallAPI<T, T>($"{_baseUri}/wines", DetailObject);

            _eventAggregator.GetEvent<SavedDetailObjectEvent>()
                    .Publish(DetailObject.Id);
        }

        private T _detailObject;

        public T DetailObject
        {
            get { return _detailObject; }
            set
            {
                _detailObject = value;
                OnPropertyChanged();
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }
    }
}
