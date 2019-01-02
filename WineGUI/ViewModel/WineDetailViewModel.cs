using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineGUI.ViewModel
{
    class WineDetailViewModel
    {

        private IEventAggregator _eventAggregator;

        public WineDetailViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }


    }
}
