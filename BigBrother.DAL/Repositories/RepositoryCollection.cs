using BigBrother.DAL.Models;
using BigBrother.DAL.Repositories;

namespace PAAD.DAL.Repositories
{
    public class RepositoryCollection : IRepositoryCollection
    {
        private Dictionary<Type, object> repositories;

        public RepositoryCollection()
        {
            // TODO Add all repositories
            repositories = new Dictionary<Type, object>()
            {
                
            };
        }

        public IRepository<T> GetRepository<T>() where T : IModel
        {
            object? repository;

            if (!repositories.TryGetValue(typeof(T), out repository))
                throw new KeyNotFoundException();

            return (IRepository<T>)repository;
        }
    }
}
