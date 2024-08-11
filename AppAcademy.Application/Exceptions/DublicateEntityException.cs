namespace AppAcademy.Application.Exceptions
{
    public class DublicateEntityException : Exception
    {
        public DublicateEntityException() { }
        public DublicateEntityException(string message) : base(message) { }

    }
}
