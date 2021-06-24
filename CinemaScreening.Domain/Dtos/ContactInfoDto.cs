using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{
    public class ContactInfoDto
    {
        public int Id { get; set; }
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }
    }
}
