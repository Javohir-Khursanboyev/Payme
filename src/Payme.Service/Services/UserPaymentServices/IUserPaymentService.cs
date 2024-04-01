using Payme.Service.DTOs.UserPayments;

namespace Payme.Service.Services.UserPaymentServices;

public interface IUserPaymentService
{
    Task<UserPaymentViewModel> CreateAsync(UserPaymentCreationModel model);
    Task<UserPaymentViewModel> GetByIdAsync(long id);
    Task<IEnumerable<UserPaymentViewModel>> GetAllAsync();
}
