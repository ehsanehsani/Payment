using PaymentProject.Core.Interfaces;
using PaymentProject.Infrastructure.Data;

namespace PaymentProject.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly PaymentDbContext _paymentDbContext;

    public UnitOfWork(PaymentDbContext paymentDbContext)
    {
        _paymentDbContext = paymentDbContext;
    }

    public async void SaveChangesAsync()
    {
        await _paymentDbContext.SaveChangesAsync();
    }
}