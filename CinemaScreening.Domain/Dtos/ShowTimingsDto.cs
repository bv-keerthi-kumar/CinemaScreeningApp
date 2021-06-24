using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{
    public class ShowTimingsDto
    {
        public int Id { get; set; }
        public DateTime? MorningShow { get; set; }
        public DateTime? MatineeShow { get; set; }
        public DateTime? EveningShow { get; set; }
        public DateTime? FirstShow { get; set; }
        public DateTime? SecondShow { get; set; }
    }
}
