namespace task_management_tekhnelogos.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
