namespace Clubb.Repos.Interface
{
    public interface IUnitOfWork
    {
        IMembershipCustom membership { get; }

        Task<int> SaveChangeAsync();
    }
}
