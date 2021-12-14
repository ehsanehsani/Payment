using Microsoft.EntityFrameworkCore;
using PaymentProject.Core.Data;
using PaymentProject.Core.Dto;
using PaymentProject.Core.Interfaces;
using PaymentProject.Infrastructure.Data;

namespace PaymentProject.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentDbContext _dbContext;

    public PaymentRepository(PaymentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Payment inputDto)
    {
        _dbContext.Set<Payment>().Add(inputDto);
    }
}