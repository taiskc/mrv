namespace mrv.Context
{
    public interface IApplicationContext
    {
        Task<int> SaveChanges();
    }
}