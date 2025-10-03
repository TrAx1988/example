namespace FullProject.Domain.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Method { get; set; }

    public virtual Order Order { get; set; } = null!;
}
