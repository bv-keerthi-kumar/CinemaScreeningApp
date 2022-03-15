using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.Dtos
{
    public class TheaterStream
    {
        public int Id { get; set; }
        public Theater Theater { get; set; }
        public MovieShow MovieShow { get; set; }
    }
}
