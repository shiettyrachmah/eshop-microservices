namespace Ordering.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base($"Domain Exceptions:\"{message}\" throws from domain layer")
        {
            
        }
    }
}
