using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{   
    public sealed class MovieDto
    {
        public MovieDto()
        {
            MoviePromosDto = new List<MoviePromoDto>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DirectorDto DirectorDto { get; set; }
        public GenreDto GenreDto { get; set; }
        public LanguageDto LanguageDto { get; set; }
        public IList<MoviePromoDto> MoviePromosDto { get; set; } 
    }
}
