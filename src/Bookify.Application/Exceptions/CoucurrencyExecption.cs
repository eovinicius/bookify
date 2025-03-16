namespace Bookify.Application.Exceptions;

public class CoucurrencyExecption : Exception
{
    public CoucurrencyExecption(string message, Exception innerException) : base(message, innerException) { }
}
