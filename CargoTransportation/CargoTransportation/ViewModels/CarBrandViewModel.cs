﻿using CargoTransportation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoTransportation.ViewModels
{
    public class CarBrandViewModel
    {
        public ICollection<CarBrand> CarBrands { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
