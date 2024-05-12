using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataLayer
{
    public class SpellsDbContext : IDB<Spell, int>
    {
        private readonly CardsDbContext _cardsDbContext;
        public SpellsDbContext(CardsDbContext cardsDbContext)
        {
            _cardsDbContext = cardsDbContext;
        }

        public void Create(Spell entity)
        {
            try
            {
                _cardsDbContext.Spells.Add(entity);
                _cardsDbContext.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public Spell Read(int key, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                IQueryable<Spell> query = _cardsDbContext.Spells;
                return query.SingleOrDefault(s => s.Id == key);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Spell> ReadAll(bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                IQueryable<Spell> query = _cardsDbContext.Spells;
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(Spell entity, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                Spell spell = Read(entity.Id, useNavigational, false);
                if(spell is null)
                {
                    throw new Exception($"Spell with id = {entity.Id} does not exist");
                }
                _cardsDbContext.Spells.Entry(spell).CurrentValues.SetValues(entity);
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
                Spell spell = Read(key, useNavigational, false);
                if (spell is null)
                {
                    throw new Exception($"Spell with id = {key} does not exist");
                }
                _cardsDbContext.Spells.Remove(spell);
                _cardsDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
