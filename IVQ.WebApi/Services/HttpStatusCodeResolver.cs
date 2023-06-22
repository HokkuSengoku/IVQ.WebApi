using System.Net;
using IVQ.WebApi.Exceptions;

namespace IVQ.WebApi.Services;

public class HttpStatusCodeResolver
{
    public static HttpStatusCode Resolve(StandartException exception)
    {
        return exception switch
        {
            AlreadyExistsException => HttpStatusCode.Conflict,
            NotFoundException => HttpStatusCode.NotFound,
            _ => HttpStatusCode.NotImplemented,
        };
    }
}