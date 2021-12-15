using Microsoft.AspNetCore.Mvc;
using PaymentProject.Core.Dto;
using PaymentProject.Core.Interfaces;

namespace PaymentProject.Api.Controllers;

[ApiController]
[Route("Payment")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<PaymentOutputDto> Post([FromBody] PaymentInputDto inputDto)
    {
        var result = await _paymentService.AddAsync(inputDto);
        return result;
    }
}