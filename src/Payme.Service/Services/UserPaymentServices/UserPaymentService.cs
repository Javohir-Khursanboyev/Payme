using AutoMapper;
using Payme.Data.IRepositories;
using Payme.Service.DTOs.UserPayments;
using Payme.Service.Services.CardServices;
using Payme.Service.Services.UserServices;

namespace Payme.Service.Services.UserPaymentServices;

public class UserPaymentService : IUserPaymentService
{
    private readonly IUserPaymentRepository repository;
    private readonly IUserService userService;
    private readonly ICardService cardService;
    private readonly 
    private readonly 
    private readonly IMapper mapper;

    public UserPaymentService(IUserPaymentRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<UserPaymentViewModel> CreateAsync(UserPaymentCreationModel model)
    {
        var userPayments = await repository.SelectAsIQueryableAsync();

    }

    public Task<IEnumerable<UserPaymentViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserPaymentViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
