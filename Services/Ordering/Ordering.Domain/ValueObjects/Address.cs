namespace Ordering.Domain.ValueObjects
{
    /// <summary>
    /// public record di c# untuk mendefinisikan jenis kelas yang berorientasi pada immutable data atau data-only
    /// Aturan record : jika dua record memiliki nilai properti yang sama, merekan dianggap sama, meskipun dibuat sebagai objek yang terpisah di memori. inidisebut "value-based equality"
    /// </summary>
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCode { get; } = default!;

        //protected agar tidak bisa diinstansi dari luar tapi masih bisa diakses oleh class yang mewarisi Address.
        protected Address()
        {

        }

        //private digunakan agar instansiasi objek hanya bisa dilakukan melalui metode yg disediakan kelas itu sendiri
        private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipcode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipcode;
        }

        //static mengartikan metode ini milik kelas langsung bukan milik object. jadi bisa menggunakan metode static ini tanpa membuat object terlebih dahulu.
        //contoh implementasi pada kelas lain untuk pemanggilan metode Of ini : var address = Address.Of("joni", "Doe", "123 main street").
        //jika metode non-static maka harus membuat object terlebih dahulu dan melakukan instance 
        public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipcode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
            ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

            return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipcode);
        }
    }
}
