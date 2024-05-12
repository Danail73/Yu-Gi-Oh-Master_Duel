using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataLayer
{
    public class MonstersDbContext : IDB<Monster, int>
    {
        private readonly CardsDbContext _cardsDbContext;
        public MonstersDbContext(CardsDbContext cardsDbContext)
        {
            _cardsDbContext = cardsDbContext;
        }

        public void Create(Monster entity)
        {
            try
            {
                _cardsDbContext.Monsters.Add(entity);
                _cardsDbContext.Cards.Add(entity);
                _cardsDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Monster Read(int key, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                IQueryable<Monster> query = _cardsDbContext.Monsters;
                return query.SingleOrDefault(m => m.Id == key);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Monster> ReadAll(bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                IQueryable<Monster> query = _cardsDbContext.Monsters;
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(Monster entity, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                Monster monster = Read(entity.Id, useNavigational, false);
                if(monster is null)
                {
                    throw new Exception($"Monster with id = {entity.Id} does not exist");
                }
                _cardsDbContext.Monsters.Entry(monster).CurrentValues.SetValues(entity);
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
                Monster monster = Read(key, useNavigational, false);
                if(monster is null)
                {
                    throw new Exception($"Monster with id = {key} does not exist");
                }
                _cardsDbContext.Monsters.Remove(monster);
                _cardsDbContext.Cards.Remove(monster);
                _cardsDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
