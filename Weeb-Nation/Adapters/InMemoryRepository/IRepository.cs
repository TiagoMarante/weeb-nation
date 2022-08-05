namespace Weeb_Nation.Adapters;

public interface IRepository<TEntity>
{
    List<TEntity> GetAll();
    TEntity Get(Guid id);
    List<TEntity> GetByIdsAsync(List<int> ids);
    TEntity Add(TEntity obj);
    void Delete(TEntity obj);
}