using AutoMapper;
using DoctorWho.Dto;
using EfDoctorWho;

namespace DoctorWho.helper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<Author,Author>();
            CreateMap<Author,Author>();
            CreateMap<Companion,Companion>();
            CreateMap<Companion,Companion>();
            CreateMap<Doctor,Doctor>();
            CreateMap<Doctor,Doctor>();
            CreateMap<Enemy,Enemy>();
            CreateMap<Enemy,Enemy>();
            CreateMap<Episod,Episod>();
            CreateMap<Episod,Episod>();
        }
    }
}
