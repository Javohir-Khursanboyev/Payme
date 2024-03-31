using Payme.Service.DTOs.Payments;

namespace Payme.Service.Services.PaymentServices;

public interface IPaymentService
{
    Task<PaymentViewModel> CreateAsync(PaymentCreationModel model);
    Task<PaymentViewModel> UpdateAsync(long id, PaymentUpdateModel model, bool isDelete = false);
    Task<bool> DeleteAsync(long id);
    Task<PaymentViewModel> GetByIdAsync(long id);
    Task<IEnumerable<PaymentViewModel>> GetAllAsync();
}