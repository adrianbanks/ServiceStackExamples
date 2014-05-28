using ServiceStack;

namespace HeyStack.ServiceModel.Movie
{
    [Route("/movies/{id}", "PUT")]
    public class PutMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
