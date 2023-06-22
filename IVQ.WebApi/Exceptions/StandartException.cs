namespace IVQ.WebApi.Exceptions;

public class StandartException : Exception
{
    public StandartException(string title, string errorType, string message) : base(message)
    {
        Title = title;
        ErrorType = errorType;
    }
    public string Title { get; }
    public string ErrorType { get; }
}