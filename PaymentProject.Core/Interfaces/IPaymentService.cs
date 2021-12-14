using PaymentProject.Core.Dto;

namespace PaymentProject.Core.Interfaces;

public interface IPaymentService
{
    PaymentOutputDto Add(PaymentInputDto inputDto);
}