using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{
    public class MovieShowDto
    {
        public int Id { get; set; }
        public bool MorningShow { get; set; }
        public bool MatineeShow { get; set; }
        public bool EveningShow { get; set; }
        public bool FirstShow { get; set; }
        public bool SecondShow { get; set; }
        public CinemaHallDto CinemaHallDto { get; set; }
        public MovieDto MovieDto { get; set; }
        public ShowTimingsDto ShowTimingsDto { get; set; }

    }
}
