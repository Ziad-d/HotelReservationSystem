using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Reservations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelReservationSystem.Repositories
{
    public class ReservationRepository<T> : IReservationRepository<T> where T : Reservation
    {
        private readonly Context _context;

        public ReservationRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> GetByID(int id)
        {
            return _context.Set<T>()
                .Where(x => !x.IsDeleted && x.ID == id);
        }

        public T GetByIDWithTracking(int id)
        {
            return _context.Set<T>()
                .Where(x => !x.IsDeleted && x.ID == id)
                .AsTracking()
                .FirstOrDefault();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        {
            return GetAll().Where(predicate).Select(selector);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }


        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void Delete(int id)
        {
            T entity = _context.Find<T>(id);
            Delete(entity);
        }

        public void HardDelete(int id)
        {
            _context.Set<T>().Where(x => x.ID == id).ExecuteDelete();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void CancelReservation(T entity)
        {
            entity.IsCanceled = true;
            Update(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        
    }
}
