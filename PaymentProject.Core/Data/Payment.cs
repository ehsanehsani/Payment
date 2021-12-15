using PaymentProject.Core.Enums;
using PaymentProject.SharedKernel;

namespace PaymentProject.Core.Data;

public class Payment : BaseEntity
{
    public DateTime CreationDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    public Order Order { get; set; } = new Order();
}