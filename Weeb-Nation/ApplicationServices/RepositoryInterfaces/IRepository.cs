using Microsoft.AspNetCore.Mvc;

namespace Weeb_Nation.RepositoryInterfaces;

public interface IRepository<TEntity>
{
    List<TEntity> GetAll();
    TEntity Get(Guid id);
    // List<TEntity> GetByIdsAsync(List<int> ids);
    ActionResult<TEntity> Add(TEntity obj);

    void Update(Guid id, TEntity obj);
    void Delete(TEntity obj);
}