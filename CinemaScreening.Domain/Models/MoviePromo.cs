using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Models
{
    public class MoviePromo 
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string TeaserUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string LanguageName { get; set; }
        public Movie Movie { get; set; }
        
    }
}
