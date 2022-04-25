namespace Application.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message)
            : base("Not Found", message)
        {
        }
    }
}
