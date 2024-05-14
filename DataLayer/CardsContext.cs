using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class CardsContext : IDB<Card, int>
    {
        private readonly CardsDbContext _cardsDbContext;
        public CardsContext(CardsDbContext cardsDbContext)
        {
            _cardsDbContext = cardsDbContext;
        }

        public void Create(Card entity)
        {
            try
            {
                _cardsDbContext.Cards.Add(entity);
                _cardsDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Card Read(int key, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                IQueryable<Card> query = _cardsDbContext.Cards;
                return query.SingleOrDefault(c => c.Id == key);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Card> ReadAll(bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                IQueryable<Card> query = _cardsDbContext.Cards;
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(Card entity, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                Card card = Read(entity.Id, useNavigational, false);
                if (card is null)
                {
                    throw new Exception($"Card with id = {entity.Id} does not exist");
                }
                _cardsDbContext.Cards.Entry(card).CurrentValues.SetValues(entity);
                _cardsDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(int key, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                Card card = Read(key, useNavigational, false);
                if (card is null)
                {
                    throw new Exception($"Card with id = {key} does not exist");
                }
                _cardsDbContext.Cards.Remove(card);
                _cardsDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
