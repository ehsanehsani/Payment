using System.ComponentModel.DataAnnotations;
using PaymentProject.Core.Enums;

namespace PaymentProject.Core.Dto;

public class PaymentOutputDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    
    //Order
    public string ConsumerFullName { get; set; } = "";
    public string ConsumerAddress { get; set; } = "";
}