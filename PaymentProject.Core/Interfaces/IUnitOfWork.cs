namespace PaymentProject.Core.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}