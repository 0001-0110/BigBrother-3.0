using BigBrother.DAL.Models;
using BigBrother.DAL.Repositories;

namespace PAAD.DAL.Repositories
{
    public interface IRepositoryCollection
    {
        public IRepository<T> GetRepository<T>() where T : IModel;
    }
}
