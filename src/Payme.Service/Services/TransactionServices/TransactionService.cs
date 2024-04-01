using AutoMapper;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.Transactions;
using Payme.Service.DTOs.Cards;
using Payme.Service.DTOs.Transactions;
using Payme.Service.Exceptions;
using Payme.Service.Helpers;
using Payme.Service.Services.CardServices;

namespace Payme.Service.Services.TransactionServices;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository transactionRepository;
    private readonly IMapper mapper;
    private readonly ICardService cardService;

    public TransactionService(ITransactionRepository transactionRepository, IMapper mapper, ICardService cardService)
    {
        this.transactionRepository = transactionRepository;
        this.mapper = mapper;
        this.cardService = cardService;
    }

    public async Task<TransactionViewModel> CreateAsync(TransactionCreationModel transaction)
    {
        var senderCard = await cardService.GetByIdAsync(transaction.SenderCardId);
        var receiverCard = await cardService.GetByIdAsync(transaction.ReceiverCardId);

        transaction.Password = PasswordActions.Hashing(transaction.Password);
        if (senderCard.Password != transaction.Password)
            throw new CustomException(400, "Password error");

        if (senderCard.Balance < transaction.Amount)
            throw new CustomException(400, "Balance is not enough");

        senderCard.Balance -= transaction.Amount;
        receiverCard.Balance += transaction.Amount;
        await cardService.UpdateAsync(senderCard.Id, mapper.Map<CardUpdateModel>(senderCard), false);
        await cardService.UpdateAsync(receiverCard.Id, mapper.Map<CardUpdateModel>(receiverCard), false);

        var createdTransaction = await transactionRepository.InsertAsync(mapper.Map<Transaction>(transaction));

        return mapper.Map<TransactionViewModel>(createdTransaction);
    }

    public async Task<IEnumerable<TransactionViewModel>> GetAllAsync(long? id = null)
    {
        var transactions = await transactionRepository.SelectAllAsIEnumerableAsync();
        return mapper.Map<IEnumerable<TransactionViewModel>>(transactions);
    }

    public async Task<TransactionViewModel> GetByIdAsync(long id)
    {
        var existTransaction = await transactionRepository.SelectAsync(id) ??
            throw new CustomException(404, "Transaction is not found");

        return mapper.Map<TransactionViewModel>(existTransaction);
    }
}
