using AutoMapper;
using DoctorWho.Dto;
using EfDoctorWho;

namespace DoctorWho.helper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<Author,AuthorDto>();
            CreateMap<AuthorDto,Author>();
            CreateMap<Companion,CompanionDto>();
            CreateMap<CompanionDto,Companion>();
            CreateMap<Doctor,DoctorDto>();
            CreateMap<DoctorDto,Doctor>();
            CreateMap<Enemy,EnemyDto>();
            CreateMap<EnemyDto,Enemy>();
            CreateMap<Episod,EpisodDto>();
            CreateMap<EpisodDto,Episod>();
        }
    }
}
