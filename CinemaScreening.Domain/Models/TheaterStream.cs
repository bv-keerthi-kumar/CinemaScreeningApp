using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Models
{
    public class TheaterStream
    {
        public int Id { get; set; }
        public Theater Theater { get; set; }
        public MovieShow MovieShow { get; set; }
    }
}
