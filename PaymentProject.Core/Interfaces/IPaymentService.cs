using PaymentProject.Core.Dto;

namespace PaymentProject.Core.Interfaces;

public interface IPaymentService
{
    Task<int> AddAsync(PaymentInputDto inputDto);
    Task<PaymentOutputDto> GetById(int id);
    Task<IEnumerable<PaymentOutputDto>> GetAll();
}