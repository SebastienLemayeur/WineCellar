using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineGUI.Helpers;
using WineLib.DTO;
using WineLib.Models;

namespace WineGUI.ViewModel
{
    class WinesListViewModel
    {
        private readonly string baseUri = "https://localhost:44361/api/wines";
        public WinesListViewModel()
        {
            IEnumerable<WineSimple> wines = ApiHelper.GetApiResult<IEnumerable<WineSimple>>(baseUri);
            WineList = new ObservableCollection<WineSimple>(wines);
        }

        public ObservableCollection<WineSimple> WineList { get; }


    }
}
