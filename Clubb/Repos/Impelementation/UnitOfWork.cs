using Clubb.Model.Data;
using Clubb.Repos.Interface;

namespace Clubb.Repos.Impelementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbcontext _context;
        public UnitOfWork(AppDbcontext appDbcontext,IMembershipCustom membershipCustom)
        {
            _context = appDbcontext;
            membership = membershipCustom;
        }
        public IMembershipCustom membership { get; }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
