namespace IVQ.WebApi.Exceptions;

public class NotFoundException : StandartException
{
    public NotFoundException(string errorType, string message) 
        : base(
            "Specified resource was not found.",
            errorType, 
            message
        )
    {
    }
}