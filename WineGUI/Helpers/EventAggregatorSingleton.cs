using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineGUI.Helpers
{
    class EventAggregatorSingleton
    {
        private EventAggregatorSingleton()
        {
        }
        private static readonly Lazy<EventAggregator> lazy = new Lazy<EventAggregator>(() => new EventAggregator());
        public static EventAggregator Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
