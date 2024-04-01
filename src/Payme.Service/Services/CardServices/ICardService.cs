using Payme.Service.DTOs.Cards;

namespace Payme.Service.Services.CardServices;

public interface ICardService
{
    /// <summary>
    /// Creates a new card.
    /// </summary>
    /// <param name="card">The card creation model.</param>
    /// <returns>The created card view model.</returns>
    Task<CardViewModel> CreateAsync(CardCreationModel card);


    /// <summary>
    /// Updates an existing card.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="card"></param>
    /// <param name="IsUsesDeleted"></param>
    /// <returns></returns>
    Task<CardViewModel> UpdateAsync(long id, CardUpdateModel card, bool IsUsesDeleted = false);


    /// <summary>
    /// Retrieves a card by ID.
    /// </summary>
    /// <param name="id">The ID of the card to retrieve.</param>
    /// <returns>The card view model if found; otherwise, null.</returns>
    Task<CardViewModel> GetByIdAsync(long id);


    /// <summary>
    /// Deletes a card by ID.
    /// </summary>
    /// <param name="id">The ID of the card to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteAsync(long id);


    /// <summary>
    /// Retrieves all cards.
    /// </summary>
    /// <returns>A collection of card view models.</returns>
    Task<IEnumerable<CardViewModel>> GetAllAsync();


    /// <summary>
    /// Deposits an amount to a card.
    /// </summary>
    /// <param name="id">The ID of the card to deposit to.</param>
    /// <param name="amount">The amount to deposit.</param>
    /// <returns>The updated card view model after the deposit.</returns>
    Task<CardViewModel> DepositAsync(long id, decimal amount);
}