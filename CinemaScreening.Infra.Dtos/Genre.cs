using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.Dtos
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Updates the <see cref="GenreDto"/> dto with valid changes.
        /// <remarks>If the changes are 'null' they will not update.</remarks>
        /// </summary>
        public void ApplyChanges(Genre changes)
        {
            Name = changes.Name ?? Name;
        }
    }
}
