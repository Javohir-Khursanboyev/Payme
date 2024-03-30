using Payme.Service.DTOs.Cards;

namespace Payme.Service.Services.CardServices;

public interface ICardService
{
    Task<CardViewModel> CreateAsync(CardCreationModel card);
    Task<CardViewModel> UpdateAsync(long id, CardUpdateModel card, bool IsUsesDeleted = false);
    Task<CardViewModel> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<CardViewModel>> GetAllAsync();
    Task<CardViewModel> DepositAsync(long id, decimal amount);
}
