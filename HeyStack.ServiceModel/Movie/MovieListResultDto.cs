using System.Collections.Generic;

namespace HeyStack.ServiceModel.Movie
{
    public class MovieListResultDto
    {
        public IList<MovieResultDto> Entries { get; set; }
    }
}
