using Microsoft.EntityFrameworkCore;
using PaymentProject.Core.Data;
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

    public async Task<Payment> GetById(int id)
    {
        var result = await _dbContext.Set<Payment>()
            .Include(x => x.Order)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (result == null)
        {
            throw new KeyNotFoundException();
        }

        return result;
    }

    public async Task<IEnumerable<Payment>> GetAll()
    {
        var result = await _dbContext.Set<Payment>()
            .Include(x => x.Order)
            .ToListAsync();

        return result;
    }
}