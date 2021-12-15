using System.ComponentModel.DataAnnotations;
using PaymentProject.Core.Data;
using PaymentProject.Core.Enums;

namespace PaymentProject.Core.Dto;

public class PaymentInputDto
{ 
    [Required]
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    
    //Order
    [Required]
    [StringLength(100)]
    public string ConsumerFullName { get; set; } = "";
    public string ConsumerAddress { get; set; } = "";
}