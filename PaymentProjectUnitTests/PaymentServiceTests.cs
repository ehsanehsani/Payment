using NSubstitute;
using NSubstitute.ReceivedExtensions;
using PaymentProject.Core.Data;
using PaymentProject.Core.Dto;
using PaymentProject.Core.Interfaces;
using PaymentProject.Infrastructure.Services;
using Xunit;

namespace PaymentProjectUnitTests;

public class PaymentServiceTests
{
    [Fact]
    public void Add_ValidPayment_ShouldCall_PaymentRepository_Add()
    {
        //arrange
        var paymentRepositoryMock = Substitute.For<IPaymentRepository>();
        var unitOfWorkStub = Substitute.For<IUnitOfWork>();
        var paymentService = new PaymentServices(paymentRepositoryMock, unitOfWorkStub);
        var payment = new Payment();
        
        //act
        paymentService.Add(new PaymentInputDto());
        
        //assert
        paymentRepositoryMock.ReceivedWithAnyArgs().Add(default);
    }
    
    [Fact]
    public void Add_ValidPayment_ShouldCall_UnitOfWork_SaveChanges()
    {
        //arrange
        var paymentRepositoryStub = Substitute.For<IPaymentRepository>();
        var unitOfWorkMock = Substitute.For<IUnitOfWork>();
        var paymentService = new PaymentServices(paymentRepositoryStub, unitOfWorkMock);
        
        //act
        paymentService.Add(new PaymentInputDto());
        
        //assert
        unitOfWorkMock.ReceivedWithAnyArgs().SaveChangesAsync();
    }
}