using AutoMapper;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.PaymentCategories;
using Payme.Service.DTOs.PaymentCategories;
using Payme.Service.Exceptions;

namespace Payme.Service.Services.PaymentCategoryServices;

public class PaymentCategoryService : IPaymentCategoryService
{
    private readonly IPaymentCategoryRepository repository;
    private readonly IMapper mapper;

    public PaymentCategoryService(IPaymentCategoryRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<PaymentCategoryViewModel> CreateAsync(PaymentCategoryCreationModel model)
    {
        var paymentCategories = await repository.SelectAllAsQueryableAsync();

        var existPaymentCategory = paymentCategories.FirstOrDefault(p => p.Name == model.Name);
        if (existPaymentCategory != null)
        {
            if (existPaymentCategory.IsDeleted)
            {
                return await UpdateAsync(existPaymentCategory.Id, mapper.Map<PaymentCategoryUpdateModel>(model), true);
            }

            throw new CustomException(409, "User is already exist");
        }

        var createPaymentCategory = await repository.InsertAsync(mapper.Map<PaymentCategory>(model));
        return mapper.Map<PaymentCategoryViewModel>(createPaymentCategory);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existPaymentCategory = await repository.SelectAsync(id)
            ?? throw new CustomException(404, "This paymentCategory is not found");

        existPaymentCategory.DeletedAt = DateTime.UtcNow;
        await repository.DeleteAsync(existPaymentCategory);
        return true;
    }

    public async Task<IEnumerable<PaymentCategoryViewModel>> GetAllAsync()
    {
        var paymentCategories = await repository.SelectAllAsEnumerableAsync();
        return mapper.Map<IEnumerable<PaymentCategoryViewModel>>(paymentCategories);
    }

    public async Task<PaymentCategoryViewModel> GetByIdAsync(long id)
    {
        var existPaymentCategory = await repository.SelectAsync(id)
            ?? throw new CustomException(404, "This paymentCategory is not found");

        return mapper.Map<PaymentCategoryViewModel>(existPaymentCategory);
    }

    public async Task<PaymentCategoryViewModel> UpdateAsync(long id, PaymentCategoryUpdateModel model, bool isDelete = false)
    {
        var existModel = new PaymentCategory();

        if (isDelete)
        {
            existModel = mapper.Map<PaymentCategory>(model);
            existModel.Id = id;
        }
        else
        {
            existModel = await repository.SelectAsync(id)
               ?? throw new CustomException(404, "This paymentCategory is not found");
        }

        existModel.UpdatedAt = DateTime.UtcNow;
        var updateModel = await repository.UpdateAsync(existModel);

        return mapper.Map<PaymentCategoryViewModel>(updateModel);
    }
}
