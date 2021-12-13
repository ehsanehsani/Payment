using System.ComponentModel.DataAnnotations;

namespace PaymentProject.Core.Enums;

public enum Currency
{
    [Display(Name = "United States Dollar")]
    USD,
    [Display(Name = "European Euro")]
    EUR,
}