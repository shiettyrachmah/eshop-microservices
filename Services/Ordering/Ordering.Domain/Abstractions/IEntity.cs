namespace Ordering.Domain.Abstractions
{
    //antarmuka generic berguna untuk memstikan fleksibilitas tipe data sehingga dapat digunakan berulang ulang.
    public interface IEntity<T> : IEntity
    {
        public T Id { get; set; } //parameter T (Tipe) memungkinkan  nantinya kelas yang mewarisi kelas ini bisa menentukan tipe khusus berupa int, string, Guid.
    }

    public interface IEntity
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
