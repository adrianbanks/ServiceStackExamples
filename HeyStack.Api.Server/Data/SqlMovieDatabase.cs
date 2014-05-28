﻿using System.Collections.Generic;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace HeyStack.Api.Server.Data
{
    public interface IMovieDatabase
    {
        IList<Movie> GetAllMovies();
    }

    public class SqlMovieDatabase : IMovieDatabase
    {
        private readonly IDbConnectionFactory connectionFactory;

        public SqlMovieDatabase(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IList<Movie> GetAllMovies()
        {
            using (var connection = connectionFactory.OpenDbConnection())
            {
                return connection.Select<Movie>();
            }
        }
    }
}