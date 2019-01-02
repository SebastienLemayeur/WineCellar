using System;
using System.Collections.Generic;
using System.Text;
using WineLib.Models;

namespace WineLib.DTO
{
    public class WineSimple : EntityBase
    {
        public string Name { get; set; }
        public int Year { get; set; } = 1900;
    }
}
