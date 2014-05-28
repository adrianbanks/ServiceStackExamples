using System.Net;
using ServiceStack;

namespace HeyStack.ServiceModel.Status
{
    [Api("ServiceStack Demonstration API")]
    [ApiResponse(HttpStatusCode.OK, "OK")]
    [ApiResponse(HttpStatusCode.InternalServerError, "Internal server error - something went wrong")]
    [Route("/status", "GET",
        Summary = "Return information about the state of the API server",
        Notes = @"This service will report on the status of the API server that's 
                    hosting our API, returning the host name and the server's local 
                    date and time.")]
    public class GetStatusDto
    {}
}
