using AutoMapper;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.Payments;
using Payme.Service.DTOs.Payments;
using Payme.Service.Exceptions;
using Payme.Service.Services.PaymentCategoryServices;

namespace Payme.Service.Services.PaymentServices;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository paymentRepository;
    private readonly IPaymentCategoryService categoryService;
    private readonly IMapper mapper;

    public PaymentService(IPaymentRepository repository, IMapper mapper, IPaymentCategoryService categoryService)
    {
        this.paymentRepository = repository;
        this.mapper = mapper;
        this.categoryService = categoryService;
    }

    public async Task<PaymentViewModel> CreateAsync(PaymentCreationModel model)
    {
        var paymentCategory = await categoryService.GetByIdAsync(model.PaymentCategoryId);

        var newPayment = mapper.Map<Payment>(model);

        newPayment.CreatedAt = DateTime.UtcNow;
        newPayment.UpdatedAt = DateTime.UtcNow;

        var createdPayment = await paymentRepository.InsertAsync(newPayment);

        return mapper.Map<PaymentViewModel>(createdPayment);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existPayment = await paymentRepository.SelectAsync(id) ??
            throw new CustomException(404, "Payment is not found");

        existPayment.DeletedAt = DateTime.UtcNow;
        await paymentRepository.DeleteAsync(existPayment);
        return true;
    }

    public async Task<IEnumerable<PaymentViewModel>> GetAllAsync()
    {
        var payments = await paymentRepository.SelectAllAsEnumerableAsync();
        return mapper.Map<IEnumerable<PaymentViewModel>>(payments);
    }

    public async Task<PaymentViewModel> GetByIdAsync(long id)
    {
        var existPayment = await paymentRepository.SelectAsync(id) ??
            throw new CustomException(404, "Payment is not found");

        return mapper.Map<PaymentViewModel>(existPayment);
    }

    public async Task<PaymentViewModel> UpdateAsync(long id, PaymentUpdateModel model, bool isDeleted = false)
    {
        var existPayment = new Payment();
        if (isDeleted)
        {
            existPayment = mapper.Map<Payment>(id);
            existPayment.Id = id;
        }
        else
        {
            existPayment = await paymentRepository.SelectAsync(id) ??
                throw new CustomException(404, "Payment is not found");
        }

        existPayment.UpdatedAt = DateTime.UtcNow;
        var updatedPayment = await paymentRepository.UpdateAsync(existPayment);

        return mapper.Map<PaymentViewModel>(updatedPayment);
    }
}