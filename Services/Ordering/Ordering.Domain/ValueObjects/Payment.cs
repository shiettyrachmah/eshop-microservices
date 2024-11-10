namespace Ordering.Domain.ValueObjects
{
    public class Payment
    {
        public string CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CCV { get; } = default!;
        public int PaymentMethod { get; } = default!;

        protected Payment() { }

       private Payment(string cardName, string cardNumber, string expiration, string cCV, int paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CCV = cCV;
            PaymentMethod = paymentMethod;
        }

        static Payment Of(string cardName, string cardNumber, string expiration, string cCV, int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrEmpty(cardName);
            ArgumentException.ThrowIfNullOrEmpty(cardNumber);
            ArgumentException.ThrowIfNullOrEmpty(cCV);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cCV.Length, 3);

            return new Payment(cardName, cardNumber, expiration, cCV, paymentMethod);
        }
    }
}
