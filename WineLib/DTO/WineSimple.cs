﻿using System;
using System.Collections.Generic;
using System.Text;
using WineLib.Models;

namespace WineLib.DTO
{
    public class ListItem : EntityBase
    {
        public string Name { get; set; }
        public int Detail { get; set; } = 1900;
    }
}
