using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using UberSystem.Data;
using UberSystem.DTOs.Ride;
using UberSystem.Model;
using UberSystem.Repo.Interface;

namespace UberSystem.Repo.Impelementation
{
    public class RideCustom : Genaricepo<Ride>, IRideCustom
    {
        private readonly AppDbcontext _context;
        public RideCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task<ICollection<Ride>> Fillter(string ?Statuse, int? MinFare, int ?MaxFare,string ?SortBy)
        {
            var query = _context.rides.AsQueryable();
            if (!string.IsNullOrEmpty(Statuse))
            {
                query = query.Where(a => a.status == Statuse);
            }
            if (MinFare.HasValue)
            {
                query = query.Where(a => a.Fare>= MinFare).OrderBy(a=>a.Fare);
            }
            if (MaxFare.HasValue)
            {
                query = query.Where(a => a.Fare<=  MaxFare).OrderBy(a=>a.Fare);
            }
            if (SortBy=="Fare")
          
                query = query.OrderBy(a => a.Fare);
            else if(SortBy== "fare_desc")
            {
                query = query.OrderByDescending(a => a.Fare);
            }
            return await query.ToListAsync();
        }

        public async Task<ICollection<Ride>> Pagination(int pagnum, int pagsiz)
        {
            return await _context.rides.Skip((pagnum - 1) * pagsiz).Take(pagsiz).ToListAsync();
        }

        public async Task<ReportDTo> Report()
        {
            return new ReportDTo
            {
                TotalRides = await _context.rides.CountAsync(),

                CompletedRides = await _context.rides
                    .CountAsync(a => a.status == "Completed"),

                CancelledRides = await _context.rides
                    .CountAsync(a => a.status == "Cancelled"),
               
                AverageFare=await _context.rides.AverageAsync(a=>a.Fare),

                ActiveRides = await _context.rides
                .CountAsync(a => a.status == "Pending" || a.status == "Accepted"),

                TotalRevenue = await _context.rides
                    .Where(a => a.status == "Completed")
                    .SumAsync(a => a.Fare)
            };
        }

        public async Task<ICollection< Ride>> SearchPickup(string pickup)
        {
            return await _context.rides.Where(a => a.PickupLocation.Contains(pickup)).ToListAsync();
        }

       
        
    }
}
