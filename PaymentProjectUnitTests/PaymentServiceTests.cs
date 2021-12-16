using System;
using System.Threading.Tasks;
using NSubstitute;
using PaymentProject.Core.Data;
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

    [Fact]
    public async Task GetById_ValidState_ShouldReturnValidId()
    {
        //arrange
        var paymentRepositoryStub = Substitute.For<IPaymentRepository>();
        var unitOfWorkStub = Substitute.For<IUnitOfWork>();
        var paymentService = new PaymentServices(paymentRepositoryStub, unitOfWorkStub);

        paymentRepositoryStub.GetById(Arg.Any<int>()).ReturnsForAnyArgs(x => new Payment()
        {
            Id = 1,
            Amount = 100,
            Status = 0,
            CreationDate = DateTime.Now,
            Order = new Order()
            {
                Id = 5,
                ConsumerAddress = "USA",
                ConsumerFullName = "Taylor Swift"
            }
        });
        
        //act
        var result =await paymentService.GetById(0);
        var expectedId = 1;

        //assert
        Assert.Equal(result.Id,expectedId);
    }
}