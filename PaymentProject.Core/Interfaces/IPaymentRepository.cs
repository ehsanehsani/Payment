using PaymentProject.Core.Data;
using PaymentProject.Core.Dto;

namespace PaymentProject.Core.Interfaces;

public interface IPaymentRepository
{
    void Add(Payment inputDto);
    Task<Payment> GetById(int id);
    Task<IEnumerable<Payment>> GetAll();
}