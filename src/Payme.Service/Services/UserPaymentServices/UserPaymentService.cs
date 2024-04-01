using AutoMapper;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.UserPayments;
using Payme.Service.DTOs.Cards;
using Payme.Service.DTOs.UserPayments;
using Payme.Service.Exceptions;
using Payme.Service.Services.CardServices;
using Payme.Service.Services.PaymentServices;
using Payme.Service.Services.UserServices;

namespace Payme.Service.Services.UserPaymentServices;

public class UserPaymentService : IUserPaymentService
{
    private readonly IUserPaymentRepository repository;
    private readonly IUserService userService;
    private readonly ICardService cardService;
    private readonly IPaymentService paymentService;
    private readonly IMapper mapper;

    public UserPaymentService(IUserPaymentRepository repository,
        IUserService userService, ICardService cardService,
        IPaymentService paymentService, IMapper mapper)
    {
        this.repository = repository;
        this.userService = userService;
        this.cardService = cardService;
        this.paymentService = paymentService;
        this.mapper = mapper;
    }

    public async Task<UserPaymentViewModel> CreateAsync(UserPaymentCreationModel model)
    {
        var existUser = await userService.GetByIdAsync(model.UserId);
        var existCard = await cardService.GetByIdAsync(model.CardId);
        await paymentService.GetByIdAsync(model.PaymentId);

        if (existUser.Id != existCard.CustomerId)
            throw new CustomException(400, "This card does not belong to you");

        if (existCard.Balance < model.Amount)
            throw new CustomException(400, "Balance is not enough");

        existCard.Balance -= model.Amount;
        await cardService.UpdateAsync(existCard.Id, mapper.Map<CardUpdateModel>(existCard), false);
        var createUserPayment = await repository.InsertAsync(mapper.Map<UserPayment>(model));
        return mapper.Map<UserPaymentViewModel>(createUserPayment);
    }

    public async Task<IEnumerable<UserPaymentViewModel>> GetAllAsync()
    {
        var userPayments = await repository.SelectAsIEnumerableAsync();

        return mapper.Map<IEnumerable<UserPaymentViewModel>>(userPayments);
    }

    public async Task<UserPaymentViewModel> GetByIdAsync(long id)
    {
        var userPayment = await repository.SelectAsync(id)
            ?? throw new CustomException(404, "This UserPayment is not found");

        return mapper.Map<UserPaymentViewModel>(userPayment);
    }
}
