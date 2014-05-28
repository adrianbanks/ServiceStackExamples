using System.Collections.Generic;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace HeyStack.Api.Server.Data
{
    public interface IMovieDatabase
    {
        IList<Movie> GetAllMovies();
        Movie Save(Movie movie);
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

        public Movie Save(Movie movie)
        {
            using (var connection = connectionFactory.OpenDbConnection())
            {
                connection.Save(movie);
                return movie;
            }
        }
    }
}
