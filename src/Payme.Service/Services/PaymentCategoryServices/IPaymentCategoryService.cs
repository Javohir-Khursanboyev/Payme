using Payme.Service.DTOs.PaymentCategories;

namespace Payme.Service.Services.PaymentCategoryServices;

public interface IPaymentCategoryService
{
    Task<PaymentCategoryViewModel> CreateAsync(PaymentCategoryCreationModel model);
    Task<PaymentCategoryViewModel> UpdateAsync(long id, PaymentCategoryUpdateModel model, bool isDelete = false);
    Task<bool> DeleteAsync(long id);
    Task<PaymentCategoryViewModel> GetByIdAsync(long id);
    Task<IEnumerable<PaymentCategoryViewModel>> GetAllAsync();
}
