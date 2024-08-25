using HotelReservationSystem.Models;

namespace HotelReservationSystem.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<TEntity> GetRepo<TEntity>() where TEntity : BaseModel;

        Task<int> CompleteAsync();
    }
}
