public interface IBaseRepository<T> where T : class
{
    Task<T> ObterPorId(Guid id);
    Task<IEnumerable<T>> ObterTodos();
    Task Adicionar(T entity);
    Task Atualizar(T entity);
    Task Remover(T entity);
}