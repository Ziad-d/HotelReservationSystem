using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Reservations;
using System.Linq.Expressions;

namespace HotelReservationSystem.Repositories
{
    public interface IReservationRepository<T> where T : Reservation
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<TResult> Get<TResult>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> selector);
        IQueryable<T> GetByID(int id);
        T GetByIDWithTracking(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void HardDelete(int id);
        void CancelReservation(T entity);
        void SaveChanges();
    }
}
