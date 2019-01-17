using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineGUI.Helpers;

namespace WineGUI.ViewModel
{
    class BaseListViewModel : BaseViewModel
    { 
        protected IEventAggregator _eventAggregator;

        public BaseListViewModel()
        {
            _eventAggregator = EventAggregatorSingleton.Instance;
        }
    }
}
