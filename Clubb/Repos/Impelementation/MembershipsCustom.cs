using Clubb.DTOs;
using Clubb.Model;
using Clubb.Model.Data;
using Clubb.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Clubb.Repos.Impelementation
{
    public class MembershipsCustom : IMembershipCustom
    {
        private readonly AppDbcontext _context;
        public MembershipsCustom(AppDbcontext appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ICollection<Membership>> getall()
        {
            return await _context.Memberships.ToListAsync();
           
        }

        public async Task<ICollection<Booking>> Getall()
        {
            return await _context.Bookings.Include(a => a.Member).Include(a => a.Facility).ToListAsync();
        }

        public async Task<Membership> GetById(int id)
        {
            return await _context.Memberships.FindAsync(id);
            
        }

        public async Task<statisticsDTO> statistics()
        {
            return new statisticsDTO
            {
                CountPayment=await _context.Payments.CountAsync(),
                TotaAmount=await _context.Payments.SumAsync(a=>a.Amount),
                AvaragAmount= await _context.Payments.AverageAsync(a=>a.Amount)

            };
        }
    }
}
