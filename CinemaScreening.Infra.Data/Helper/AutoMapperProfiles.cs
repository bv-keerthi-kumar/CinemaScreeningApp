using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CinemaScreening.Domain.Dtos;
using CinemaScreening.Domain.Models;

namespace CinemaScreening.Infra.Data.Helper
{
    /// <summary>
    /// NOTE: 
    /// Performance of AutoMapper and it indicates that Automapper is 7 times slower than manual mapping. This test was done for 100,000 records.
    /// Good to know that the performance of AutoMapper, then we can make an intelligent decision of when
    /// to use Automapper versus when to write it manually!
    /// </summary>
    /// <remarks>
    /// We can safe assume that Automapper in an 'average' project won't inhibit you too much and save our time from writing lots of lines of code! 
    /// </remarks>
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
           // CreateMap<TSource, TDestination>
            CreateMap<Director, DirectorDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Language, LanguageDto>();
            CreateMap<Movie, MovieDto>()
                .ForMember(destMovieDto => destMovieDto.DirectorDto, opt => opt.MapFrom(srcMovie => srcMovie.Director))
                .ForMember(destMovieDto => destMovieDto.GenreDto, opt => opt.MapFrom(srcMovie => srcMovie.Genre))
                .ForMember(destMovieDto => destMovieDto.LanguageDto, opt => opt.MapFrom(srcMovie => srcMovie.Language));

            //Reverse Map
            /*
            CreateMap<DirectorDto, Director>();
            CreateMap<GenreDto, Genre>();
            CreateMap<LanguageDto, Language>();
            CreateMap<MovieDto, Movie>()
                .ForMember(destMovie => destMovie.Director, opt => opt.MapFrom(srcMovieDto => srcMovieDto.DirectorDto))
                .ForMember(destMovie => destMovie.Genre, opt => opt.MapFrom(srcMovieDto => srcMovieDto.GenreDto))
                .ForMember(destMovie => destMovie.Language, opt => opt.MapFrom(srcMovieDto => srcMovieDto.LanguageDto));
            */
            CreateMap<Director, DirectorDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap(); 
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Movie, MovieDto>()
                .ForMember(destMovieDto => destMovieDto.DirectorDto, opt => opt.MapFrom(srcMovie => srcMovie.Director))
                .ForMember(destMovieDto => destMovieDto.GenreDto, opt => opt.MapFrom(srcMovie => srcMovie.Genre))
                .ForMember(destMovieDto => destMovieDto.LanguageDto, opt => opt.MapFrom(srcMovie => srcMovie.Language)).ReverseMap();
        }
    }
}
