using System;
using System.Collections.Generic;
using System.Text;
using CinemaScreening.Infra.Dtos.Enums;

namespace CinemaScreening.Infra.Dtos
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AcType AcType { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
