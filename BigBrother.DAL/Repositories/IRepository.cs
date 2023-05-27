using BigBrother.DAL.Models;

namespace BigBrother.DAL.Repositories
{
    public interface IRepository<T> where T : IModel
    {
        public bool IdExists(int id);

        public IEnumerable<T> GetAll();

        public T? GetById(int id);

        public void Create(T entity);

        public void Edit(int id, T edit);

        public void Delete(T item);
    }
}
