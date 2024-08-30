using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using System.Collections;

namespace HotelReservationSystem.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private Hashtable _repositories;

        public UnitOfWork(Context context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public IRepository<TEntity> GetRepo<TEntity>() where TEntity : BaseModel
        {
            // 1. Getting key which is the name
            var key = typeof(TEntity).Name;

            // 2. Checking if this key already exists in the dictionary, if not
            if (!_repositories.ContainsKey(key))
            {
                // 2.1. Creating new Repository of that entity
                var repository = new Repository<TEntity>(_context);
                // 2.2. Adding it to the dictionary with the key as its name
                _repositories.Add(key, repository);
            }

            // 3. Returning the key which is the name of the repository created
            return _repositories[key] as IRepository<TEntity>;
        }

        //public int CompleteAsync()
        //    => _context.SaveChanges();

        public async ValueTask DisposeAsync()
            => await _context.DisposeAsync();
    }
}
