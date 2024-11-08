namespace LogisticService.Repository
{
    public interface IRepository<TModel, TRequest>
    {
        void Add(TModel t);
        void Delete(TModel t);
        void Update(TModel t);
        TModel Get(int id);
        IEnumerable<TModel> GetAll();
        TModel Find(TRequest t);
    }
}
