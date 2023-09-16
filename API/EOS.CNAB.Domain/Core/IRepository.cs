namespace EOS.CNAB.Domain.Core
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Create(TEntity obj);
        Task<IList<TEntity>> GetAll();

    }
}
