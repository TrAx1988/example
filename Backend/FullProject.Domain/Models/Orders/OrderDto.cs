using FullProject.Domain.Entities;

namespace FullProject.Domain.Models.Orders
{
    public partial class OrderDto
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

        public string? Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
