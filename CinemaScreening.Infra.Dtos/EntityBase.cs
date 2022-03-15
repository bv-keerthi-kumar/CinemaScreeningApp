using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.Dtos
{
    public class EntityBase
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
