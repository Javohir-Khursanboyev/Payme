using Payme.Service.DTOs.PaymentCategories;

namespace Payme.Service.Services.PaymentCategoryServices;

public interface IPaymentCategoryService
{
    /// <summary>
    /// Creates a new payment category
    /// </summary>
    /// <param name="model">The payment category creation model.</param>
    /// <returns>The created payment category view model.</returns>
    Task<PaymentCategoryViewModel> CreateAsync(PaymentCategoryCreationModel model);


    /// <summary>
    ///  Updates an existing payment category.
    /// </summary>
    /// <param name="id">The ID of the payment category to update.</param>
    /// <param name="model">The payment category update model.</param>
    /// <param name="isDeleted">Optional. Indicates if the payment category is marked as deleted.</param>
    /// <returns>The updated payment category view model.
    /// </returns>
    Task<PaymentCategoryViewModel> UpdateAsync(long id, PaymentCategoryUpdateModel model, bool isDeleted = false);


    /// <summary>
    /// Deletes a payment category by ID.
    /// </summary>
    /// <param name="id">The ID of the payment category to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteAsync(long id);


    /// <summary>
    /// Retrieves a payment category by ID.
    /// </summary>
    /// <param name="id">The ID of the payment category to retrieve.</param>
    /// <returns>The payment category view model if found; otherwise, null.</returns>
    Task<PaymentCategoryViewModel> GetByIdAsync(long id);


    /// <summary>
    /// Retrieves all payment categories.
    /// </summary>
    /// <returns>A collection of payment category view models.</returns>
    Task<IEnumerable<PaymentCategoryViewModel>> GetAllAsync();
}