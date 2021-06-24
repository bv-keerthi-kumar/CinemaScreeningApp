﻿using CinemaScreening.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Domain.RepositoryInterfaces
{
    public interface IShowTimingsRepository : IGenericRepository<ShowTimingsDto>, IRepository
    { 
    }
}
