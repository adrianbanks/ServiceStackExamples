﻿using System.Linq;
using HeyStack.Api.Server.Data;
using HeyStack.ServiceModel.Movie;
using ServiceStack;

namespace HeyStack.Api.Server.Services
{
    public class MovieService : Service
    {
        private readonly IMovieDatabase movieDatabase;

        public MovieService(IMovieDatabase movieDatabase)
        {
            this.movieDatabase = movieDatabase;
        }

        public MovieListResultDto Get(GetMoviesDto request)
        {
            var allMovies = movieDatabase.GetAllMovies();
            return new MovieListResultDto { Entries = allMovies.Select(m => m.ConvertTo<MovieResultDto>()).ToList() };
        }
    }
}
