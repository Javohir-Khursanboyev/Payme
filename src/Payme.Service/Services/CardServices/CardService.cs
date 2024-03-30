using AutoMapper;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.Cards;
using Payme.Service.DTOs.Cards;
using Payme.Service.Exceptions;
using Payme.Service.Helpers;
using Payme.Service.Services.UserServices;

namespace Payme.Service.Services.CardServices;

public class CardService : ICardService
{
    private readonly ICardRepository cardRepository;
    private readonly IMapper mapper;
    private readonly IUserService userService;
    public CardService(ICardRepository cardRepository, IMapper mapper, IUserService userService)
    {
        this.cardRepository = cardRepository;
        this.mapper = mapper;
        this.userService = userService;
    }

    public async Task<CardViewModel> CreateAsync(CardCreationModel card)
    {
        var customer = userService.GetByIdAsync(card.CustomerId);

        var cards = await cardRepository.SelectAllIQueryableAsync();
        var existCard = cards.FirstOrDefault(c => c.Number == card.Number);
        if (existCard != null)
        {
            if (existCard.IsDeleted)
                return await UpdateAsync(existCard.Id, mapper.Map<CardUpdateModel>(card), true);
            
            throw new CustomException(409, "Card is already exist");
        }

        card.Password = PasswordActions.Hashing(card.Password);
        var createdCard = await cardRepository.InsertAsync(mapper.Map<Card>(card));

        return mapper.Map<CardViewModel>(createdCard);
    }

    public async Task<CardViewModel> UpdateAsync(long id, CardUpdateModel card, bool IsUsesDeleted = false)
    {
        var customer = userService.GetByIdAsync(card.CustomerId);

        var existCard = new Card();
        card.Password = PasswordActions.Hashing(card.Password);

        if (IsUsesDeleted)
        {
            existCard = mapper.Map<Card>(card);
            existCard.Id = id;
        }
        else
        {
            existCard = await cardRepository.SelectAsync(id) ??
                throw new CustomException(404, "Card is not found");
        }

        existCard.UpdatedAt = DateTime.UtcNow;
        var updatedCard = await cardRepository.UpdateAsync(existCard);

        return mapper.Map<CardViewModel>(updatedCard);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existCard = await cardRepository.SelectAsync(id) ??
            throw new CustomException(404, "Card is not found");

        existCard.DeletedAt = DateTime.UtcNow;
        await cardRepository.DeleteAsync(existCard);
        return true;
    }

    public async Task<IEnumerable<CardViewModel>> GetAllAsync()
    {
        var cards = await cardRepository.SelectAllAsIEnumerableAsync();
        return mapper.Map<IEnumerable<CardViewModel>>(cards);
    }

    public async Task<CardViewModel> GetByIdAsync(long id)
    {
        var existCard = await cardRepository.SelectAsync(id) ??
            throw new CustomException(404, "Card is not found");

        return mapper.Map<CardViewModel>(existCard);
    }

    public async Task<CardViewModel> DepositAsync(long id, decimal amount)
    {
        var cards = await cardRepository.SelectAllIQueryableAsync();
        var existCard = cards.FirstOrDefault(u => u.Id == id && !u.IsDeleted)
            ?? throw new Exception($"This card is not found With this id {id}");

        existCard.Balance += amount;
        var depositCard = await cardRepository.UpdateAsync(existCard);
        return mapper.Map<CardViewModel>(existCard);
    }
}
