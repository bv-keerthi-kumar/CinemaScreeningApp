using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{
    public class TheaterStreamDto
    {
        public int Id { get; set; }
        public TheaterDto TheaterDto { get; set; }
        public MovieShowDto MovieShowDto { get; set; }
    }
}
