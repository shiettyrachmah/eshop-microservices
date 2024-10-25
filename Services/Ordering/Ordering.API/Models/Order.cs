using Ordering.API.Abstractions;

namespace Ordering.API.Models
{
    public class Order : Aggregate<Guid>
    {
        //_orderItems (readonly field) dapat mengubah isi dari List<OrderItem> namun tidak bisa mengganti referensi nay setelah diinisialisasi
        private readonly List<OrderItem> _orderItems = new();

        //ini menyediakan view hanya-baca dari list yang sama, shingga siapapun yang mengakses OrderItems tidak dapat memodifikasi isinya
        private IReadOnlyList<OrderItem> OrderItems = _orderItems.AsReadOnly();
        public Guid CustomerId { get; private set; } = default!;
        public string OrderName { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!; 
        public Address BillingAddress { get; private set; } = default!; 
        public Payment Payment { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending; 
    }
}
