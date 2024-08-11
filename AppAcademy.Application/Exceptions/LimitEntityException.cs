namespace AppAcademy.Application.Exceptions
{
    public class LimitEntityException : Exception
    {
        public LimitEntityException() { }
        public LimitEntityException(string message) : base(message) { }
    }
}
