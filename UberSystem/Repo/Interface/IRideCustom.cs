using UberSystem.DTOs.Ride;
using UberSystem.Model;

namespace UberSystem.Repo.Interface
{
    public interface IRideCustom:IgenaricRepo<Ride>
    {
        Task<ICollection<Ride>> Pagination(int pagnum, int pagsiz);
        Task<ICollection< Ride> > SearchPickup(string pickup);

        Task<ICollection<Ride>> Fillter(string? Statuse, int? MinFare, int? MaxFare, string? SortBy);

        Task<ReportDTo> Report();

    }
}
