using Payme.Domain.Entities.Cards;

namespace Payme.Data.IRepositories;

public interface ICardRepository
{
    Task<Card> InsertAsync(Card card);
    Task<Card> UpdateAsync(Card card);
    Task<Card> SelectAsync(long id);
    Task<bool> DeleteAsync(Card card);
    Task<IEnumerable<Card>> SelectAllAsIEnumerableAsync();
    Task<IQueryable<Card>> SelectAllIQueryableAsync();
}
