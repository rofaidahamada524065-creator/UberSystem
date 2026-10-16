using AutoMapper;
using UberSystem.DTOs.payments;
using UberSystem.DTOs.Rating;
using UberSystem.DTOs.Ride;
using UberSystem.DTOs.User;
using UberSystem.DTOs.vehicles;
using UberSystem.Model;

namespace UberSystem.Mapping
{
    public class AllProfail:Profile
    {
        public AllProfail()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUpdateUser>().ReverseMap();

            CreateMap<Vehicle, vehiclesDTO>().ReverseMap();
            CreateMap<Vehicle, CreateUpdatevehiclesDTo>().ReverseMap();

            CreateMap<Ride, RideDTO>().ReverseMap();
            CreateMap<Ride, CreateUpadateRide>().ReverseMap();

            CreateMap<Payment, paymentsDTO>().ReverseMap();
            CreateMap<Payment, createupdateDTO>().ReverseMap();

            CreateMap<Rating, RatingDTO>().ReverseMap();
            CreateMap<Rating, CreateUpdateRating>().ReverseMap();

        }
    }
}
