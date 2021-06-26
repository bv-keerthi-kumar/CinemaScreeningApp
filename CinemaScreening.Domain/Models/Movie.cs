using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Models
{
    public class Movie : EntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Director Director { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }

        /// <summary>
        /// Updates the <see cref="Movie"/> dto with valid changes.
        /// <remarks>If the changes are 'null' they will not update.</remarks>
        /// </summary>
        public void ApplyChanges(Movie changes)
        {
            Title = changes.Title ?? Title;
            Rating = changes.Rating ?? Rating;
            ReleaseDate = changes.ReleaseDate ?? ReleaseDate;
            Director = changes.Director ?? Director;
            Genre = changes.Genre ?? Genre;
            Language = changes.Language ?? Language;
        }
    }
}
