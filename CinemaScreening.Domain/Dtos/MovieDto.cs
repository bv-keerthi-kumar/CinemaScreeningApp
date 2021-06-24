using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public GenreDto GenreDto { get; set; }
        public DirectorDto DirectorDto { get; set; }

    }
}
