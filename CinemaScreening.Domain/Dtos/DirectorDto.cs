﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.Dtos
{
    public class DirectorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Updates the <see cref="DirectorDto"/> dto with valid changes.
        /// <remarks>If the changes are 'null' they will not update.</remarks>
        /// </summary>
        public void ApplyChanges(DirectorDto changes)
        {
            FirstName = changes.FirstName ?? FirstName;
            LastName = changes.LastName ?? LastName;
        }
    }
}
