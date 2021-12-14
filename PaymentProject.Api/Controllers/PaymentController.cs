using Microsoft.AspNetCore.Mvc;
using PaymentProject.Core.Dto;
using PaymentProject.Core.Interfaces;

namespace PaymentProject.Api.Controllers;

[ApiController]
[Route("Payment")]
public class PaymentController  : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public PaymentOutputDto Post([FromBody] PaymentInputDto inputDto)
    {
        var result= _paymentService.Add(inputDto);
        return result;
    }
}