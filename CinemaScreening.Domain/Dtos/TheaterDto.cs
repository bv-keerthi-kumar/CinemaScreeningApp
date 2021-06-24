using CinemaScreening.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{
    public class TheaterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AcType AcType { get; set; }
        public AddressDto AddressDto { get; set; }
        public ContactInfoDto ContactInfoDto { get; set; }

    }
}
