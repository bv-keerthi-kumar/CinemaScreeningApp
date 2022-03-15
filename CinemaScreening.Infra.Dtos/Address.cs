﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.Dtos
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public string Country { get; set; }

    }
}
