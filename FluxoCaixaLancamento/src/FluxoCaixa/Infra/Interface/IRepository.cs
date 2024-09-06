using FluxoCaixa.Domain;

namespace FluxoCaixa.Infra.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        void DiscardAllChanges();

        Task SaveChanges();

        Task Insert(T obj);

        Task<Boolean> InsertAndSave(T obj);

        Task<Boolean> InsertMany(IEnumerable<T> objs);

        void Update(T obj);

        Task<Boolean> UpdateAndSave(T obj);

        Task<Boolean> UpdateMany(IEnumerable<T> obj);

        Task<Boolean> Delete(int id);

        Task<Boolean> DeleteMany(IEnumerable<T> objs);

        Task<T> Select(int id);

        Task<IEnumerable<T>> Select();

        Task<IEnumerable<T>> GetBy(Func<T, bool> predicate);

    }
}
