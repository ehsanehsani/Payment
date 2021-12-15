using System;
using System.Threading.Tasks;
using NSubstitute;
using PaymentProject.Core.Dto;
using PaymentProject.Core.Interfaces;
using PaymentProject.Infrastructure.Services;
using Xunit;

namespace PaymentProjectUnitTests;

public class PaymentServiceTests
{
    [Fact]
    public async Task Add_ValidPayment_ShouldCall_PaymentRepository_Add()
    {
        //arrange
        var paymentRepositoryMock = Substitute.For<IPaymentRepository>();
        var unitOfWorkStub = Substitute.For<IUnitOfWork>();
        var paymentService = new PaymentServices(paymentRepositoryMock, unitOfWorkStub);

        //act
        await paymentService.AddAsync(new PaymentInputDto());

        //assert
        paymentRepositoryMock.ReceivedWithAnyArgs().Add(default);
    }

    [Fact]
    public async Task Add_ValidPayment_ShouldCall_UnitOfWork_SaveChangesAsync()
    {
        //arrange
        var paymentRepositoryStub = Substitute.For<IPaymentRepository>();
        var unitOfWorkMock = Substitute.For<IUnitOfWork>();
        var paymentService = new PaymentServices(paymentRepositoryStub, unitOfWorkMock);

        //act
        await paymentService.AddAsync(new PaymentInputDto());

        //assert
        await unitOfWorkMock.ReceivedWithAnyArgs().SaveChangesAsync();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task Add_PaymentLessThanOrEqualZero_ShouldThrow(decimal input)
    {
        //arrange
        var paymentRepositoryStub = Substitute.For<IPaymentRepository>();
        var unitOfWorkStub = Substitute.For<IUnitOfWork>();
        var paymentService = new PaymentServices(paymentRepositoryStub, unitOfWorkStub);
        var payment = new PaymentInputDto()
        {
            Amount = input
        };

        //assert
        await Assert.ThrowsAsync<ArgumentException>(() => paymentService.AddAsync(payment));
    }
}