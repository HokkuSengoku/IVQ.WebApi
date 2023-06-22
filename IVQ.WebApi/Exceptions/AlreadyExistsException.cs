namespace IVQ.WebApi.Exceptions;

public class AlreadyExistsException : StandartException
{
    public AlreadyExistsException(string errorType, string message) 
        : base(
            "The resource already exists.",
            errorType, 
            message
        )
    {
    }
}