namespace PokeApi.Repository;

public interface IBaseRepository<T>
{
    T Create(T data);
    IEnumerable<T> All();
    T FindById(string id);
    void Update(T entity);
    bool Delete(string id);
}