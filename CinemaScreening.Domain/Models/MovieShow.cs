using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Models
{
    public class MovieShow
    {
        public int Id { get; set; }
        public bool MorningShow { get; set; }
        public bool MatineeShow { get; set; }
        public bool EveningShow { get; set; }
        public bool FirstShow { get; set; }
        public bool SecondShow { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public Movie Movie { get; set; }
        public ShowTimings ShowTimings { get; set; }
    }
}
