using PaymentProject.Core.Data;
using PaymentProject.Core.Dto;
using PaymentProject.Core.Interfaces;

namespace PaymentProject.Infrastructure.Services;

public class PaymentServices : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentServices(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public PaymentOutputDto Add(PaymentInputDto inputDto)
    {
        Payment payment = new()
        {
            Amount = inputDto.Amount,
            Status = inputDto.Status,
            CreationDate = DateTime.Now,
            Order = new Order()
            {
                ConsumerAddress = inputDto.ConsumerAddress,
                ConsumerFullName = inputDto.ConsumerFullName
            }
        };

        _paymentRepository.Add(payment);
        _unitOfWork.SaveChangesAsync();
        
        return new PaymentOutputDto()
        {
            Id = payment.Id
        };
    }
}