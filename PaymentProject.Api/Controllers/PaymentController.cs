using Microsoft.AspNetCore.Mvc;
using PaymentProject.Core.Dto;
using PaymentProject.Core.Interfaces;

namespace PaymentProject.Api.Controllers;

[ApiController]
[Route("Payments")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<int> Post([FromBody] PaymentInputDto inputDto)
    {
        var result = await _paymentService.AddAsync(inputDto);
        return result;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<PaymentOutputDto> Get(int id)
    {
        var result = await _paymentService.GetById(id);
        return result;
    }

    [HttpGet]
    public async Task<IEnumerable<PaymentOutputDto>> Get()
    {
        var result = await _paymentService.GetAll();
        return result;
    }
}