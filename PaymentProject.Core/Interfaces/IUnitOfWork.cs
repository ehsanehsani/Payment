namespace PaymentProject.Core.Interfaces;

public interface IUnitOfWork
{
    void SaveChangesAsync();
}