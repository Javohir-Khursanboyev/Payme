using Payme.Service.DTOs.Payments;

namespace Payme.Service.Services.PaymentServices;

public interface IPaymentService
{
    /// <summary>
    /// Creates a new payment.
    /// </summary>
    /// <param name="model">The payment creation model.</param>
    /// <returns>The created payment view model.</returns>
    Task<PaymentViewModel> CreateAsync(PaymentCreationModel model);


    /// <summary>
    /// Updates an existing payment.
    /// </summary>
    /// <param name="id">The ID of the payment to update.</param>
    /// <param name="model">The payment update model.</param>
    /// <param name="isDeleted">Optional. Indicates if the payment is marked as deleted.</param>
    /// <returns>The updated payment view model.</returns>
    Task<PaymentViewModel> UpdateAsync(long id, PaymentUpdateModel model, bool isDeleted = false);


    /// <summary>
    /// Deletes a payment by ID.
    /// </summary>
    /// <param name="id">The ID of the payment to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteAsync(long id);


    /// <summary>
    /// Retrieves a payment by ID.
    /// </summary>
    /// <param name="id">The ID of the payment to retrieve.</param>
    /// <returns>The payment view model if found; otherwise, null.</returns>
    Task<PaymentViewModel> GetByIdAsync(long id);


    /// <summary>
    /// Retrieves all payments.
    /// </summary>
    /// <returns>A collection of payment view models.</returns>
    Task<IEnumerable<PaymentViewModel>> GetAllAsync();
}