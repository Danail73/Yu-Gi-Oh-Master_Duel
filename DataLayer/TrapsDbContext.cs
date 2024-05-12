using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataLayer
{
    public class TrapsDbContext : IDB<Trap, int>
    {
        private readonly CardsDbContext _cardsDbContext;
        public TrapsDbContext(CardsDbContext cardsDbContext)
        {
            _cardsDbContext = cardsDbContext;
        }

        public void Create(Trap entity)
        {
            try
            {
                _cardsDbContext.Traps.Add(entity);
                _cardsDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Trap Read(int key, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                IQueryable<Trap> query = _cardsDbContext.Traps;
                return query.SingleOrDefault(t => t.Id == key);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Trap> ReadAll(bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                IQueryable<Trap> query = _cardsDbContext.Traps;
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(Trap entity, bool useNavigational = false, bool isReadonly = false)
        {
            try
            {
                Trap trap = Read(entity.Id, useNavigational, false);
                if (trap is null)
                {
                    throw new Exception($"Trap with id = {entity.Id} does not exist");
                }
                _cardsDbContext.Traps.Entry(trap).CurrentValues.SetValues(entity);
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
                Trap trap = Read(key, useNavigational, false);
                if (trap is null)
                {
                    throw new Exception($"Trap with id = {key} does not exist");
                }
                _cardsDbContext.Traps.Remove(trap);
                _cardsDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
