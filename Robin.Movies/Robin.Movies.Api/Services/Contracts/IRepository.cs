namespace Robin.Movies.Api.Services.Contracts
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel> FindByIdAsync(string id);

        Task<IEnumerable<TModel>> FindAllAsync(Func<TModel, bool> predicate);
    }
}
