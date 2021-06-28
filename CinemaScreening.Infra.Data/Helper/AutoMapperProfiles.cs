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
                .ForMember(d => d.DirectorDto, opt => opt.MapFrom(s => s.Director))
                .ForMember(d => d.GenreDto, opt => opt.MapFrom(s => s.Genre))
                .ForMember(d => d.LanguageDto, opt => opt.MapFrom(s => s.Language))
                .ForMember(d => d.MoviePromosDto, opt => opt.MapFrom(s => s.MoviePromos));
            CreateMap<MoviePromo, MoviePromoDto>()
                .ForMember(d => d.MovieDto, opt => opt.MapFrom(s => s.Movie));

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
                .ForMember(d => d.DirectorDto, opt => opt.MapFrom(s => s.Director))
                .ForMember(d => d.GenreDto, opt => opt.MapFrom(s => s.Genre))
                .ForMember(d => d.LanguageDto, opt => opt.MapFrom(s => s.Language))
                .ForMember(d => d.MoviePromosDto, opt => opt.MapFrom(s => s.MoviePromos)).ReverseMap();
            CreateMap<MoviePromo, MoviePromoDto>()
                .ForMember(d => d.MovieDto, opt => opt.MapFrom(s => s.Movie)).ReverseMap();
        }
    }
}
