using ServiceStack;

namespace HeyStack.ServiceModel.Movie
{
    [Route("/movies", "POST")]
    public class PostMovieDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
