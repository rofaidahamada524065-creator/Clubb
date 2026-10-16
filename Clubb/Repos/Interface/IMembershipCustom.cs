using Clubb.DTOs;
using Clubb.Model;

namespace Clubb.Repos.Interface
{
    public interface IMembershipCustom
    {
        Task<Membership> GetById(int id);
        Task<ICollection<Membership>> getall();

        Task<ICollection<Booking>> Getall();

        Task<statisticsDTO> statistics();
    }
}
