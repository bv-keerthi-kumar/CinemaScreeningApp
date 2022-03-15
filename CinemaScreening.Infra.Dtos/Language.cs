using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Infra.Dtos
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Updates the <see cref="Language"/> dto with valid changes.
        /// <remarks>If the changes are 'null' they will not update.</remarks>
        /// </summary>
        public void ApplyChanges(Language changes)
        {
            Name = changes.Name ?? Name;
        }
    }
}
