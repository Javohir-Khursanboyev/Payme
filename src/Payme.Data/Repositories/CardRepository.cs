using Payme.Data.IRepositories;
using Payme.Domain.Entities.Cards;

namespace Payme.Data.Repositories;

public class CardRepository : ICardRepository
{
    public Task<bool> DeleteAsync(Card card)
    {
        throw new NotImplementedException();
    }

    public Task<Card> InsertAsync(Card card)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Card>> SelectAllAsIEnumerable()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Card>> SelectAllIQueryable()
    {
        throw new NotImplementedException();
    }

    public Task<Card> SelectAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Card> UpdateAsync(Card card)
    {
        throw new NotImplementedException();
    }
}
