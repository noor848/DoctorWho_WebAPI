using AutoMapper;
using DoctorWho.Dto;
using EfDoctorWho;

namespace DoctorWho.helper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<Author,Authord>();
            CreateMap<Authord,Author>();
            CreateMap<Companiond,Companion>();
            CreateMap<Companion,Companiond>();
            CreateMap<Doctord,Doctor>();
            CreateMap<Doctor,Doctord>();
            CreateMap<Enemyd,Enemy>();
            CreateMap<Enemy,Enemyd>();
            CreateMap<Episodd,Episod>();
            CreateMap<Episod,Episodd>();
        }
    }
}
