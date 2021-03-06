﻿using Prism.Commands;
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
    class BaseDetailViewModel <T> : BaseViewModel<T> where T : EntityBase, new()
    {
        public ICommand SaveCommand { get; }
        protected IEventAggregator _eventAggregator;

        public BaseDetailViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
            _eventAggregator.GetEvent<ClearDetailObjectEvent>().Subscribe(OnClearDetailObject);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            _eventAggregator.GetEvent<OpenItemDetailViewEvent>().Subscribe(OnOpenWineDetailView);
            OnOpenWineDetailView(0);
            DetailObject = new T();
        }

        protected virtual void OnOpenWineDetailView(int wineId)
        {
            if (wineId != 0) DetailObject = ApiHelper.GetApiResult<T>(GetApiString() +$"/{wineId}");
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

        private void OnClearDetailObject()
        {
            DetailObject = new T();
        }

        private async Task UpdateDetailObject()
        {
            string apiString = GetApiString() + $"/{DetailObject.Id}";
            await ApiHelper.PutCallAPI<T, T>(apiString, DetailObject);

            _eventAggregator.GetEvent<SavedDetailObjectEvent>()
                    .Publish();
        }

        private async Task SaveDetailObject()
        {
            await ApiHelper.PostCallAPI<T, T>(GetApiString(), DetailObject);

            _eventAggregator.GetEvent<SavedDetailObjectEvent>()
                    .Publish();
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
