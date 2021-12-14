using PaymentProject.Core.Data;
using PaymentProject.Core.Enums;

namespace PaymentProject.Core.Dto;

public class PaymentInputDto
{ 
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    
    //Order
    public string ConsumerFullName { get; set; } = "";
    public string ConsumerAddress { get; set; } = "";
}