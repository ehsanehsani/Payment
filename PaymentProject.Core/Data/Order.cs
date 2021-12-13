using PaymentProject.SharedKernel;

namespace PaymentProject.Core.Data;

public class Order : BaseEntity
{
    public string ConsumerFullName { get; set; }
    public string ConsumerAddress { get; set; }
}