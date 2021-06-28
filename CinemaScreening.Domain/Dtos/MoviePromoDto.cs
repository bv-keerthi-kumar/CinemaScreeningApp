using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{
    public class MoviePromoDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string TeaserUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string LanguageName { get; set; }
        public MovieDto MovieDto { get; set; }
        
    }
}
