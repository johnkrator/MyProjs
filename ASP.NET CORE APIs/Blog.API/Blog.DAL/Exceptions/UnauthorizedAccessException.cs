namespace Blog.DAL.Exceptions;

public class UnauthorizedAccessException : Exception
{
    public UnauthorizedAccessException(string msg) : base(msg)
    {
    }
}
