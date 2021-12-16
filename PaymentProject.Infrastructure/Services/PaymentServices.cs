using PaymentProject.Core.Data;
using PaymentProject.Core.Dto;
using PaymentProject.Core.Interfaces;
using PaymentProject.Infrastructure.Guards;

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

    public async Task<int> AddAsync(PaymentInputDto inputDto)
    {
        GuardClauses.IsMoreThan(0, inputDto.Amount, nameof(inputDto.Amount));
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
        await _unitOfWork.SaveChangesAsync();

        return payment.Id;
    }

    public async Task<PaymentOutputDto> GetById(int id)
    {
        var result = await _paymentRepository.GetById(id);
        return new PaymentOutputDto()
        {
            Id = result.Id,
            Amount = result.Amount,
            Status = result.Status,
            ConsumerAddress = result.Order.ConsumerAddress,
            ConsumerFullName = result.Order.ConsumerFullName
        };
    }

    public async Task<IEnumerable<PaymentOutputDto>> GetAll()
    {
        var result = new List<PaymentOutputDto>();
        var payments = await _paymentRepository.GetAll();
        foreach (var payment in payments)
        {
            result.Add(new PaymentOutputDto()
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Status = payment.Status,
                ConsumerAddress = payment.Order.ConsumerAddress,
                ConsumerFullName = payment.Order.ConsumerFullName
            });
        }

        return result;
    }
}