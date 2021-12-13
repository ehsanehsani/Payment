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
        _paymentRepository.Add(new Payment()
        {

        });
        _unitOfWork.Save();
        return new PaymentOutputDto()
        {

        };
    }
}