using PaymentProject.Core.Dto;

namespace PaymentProject.Core.Interfaces;

public interface IPaymentService
{
    Task<PaymentOutputDto> AddAsync(PaymentInputDto inputDto);
}