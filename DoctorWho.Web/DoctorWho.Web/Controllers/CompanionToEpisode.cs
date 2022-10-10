using DoctorWho.Db.Interface;
using DoctorWho.Dto;
using DoctorWho.helper;
using EfDoctorWho;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DoctrWho.Db.Interface;

namespace DoctorWho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanionToEpisodeController : Controller
    {
        private readonly ICompanionToEpisodeRepository _CompanionToEpisodeRepositry;
        private readonly  IMapper _mapper;
        public CompanionToEpisodeController(ICompanionToEpisodeRepository CompanionToEpisodeRepositry, IMapper mapper)
        {
            _CompanionToEpisodeRepositry = CompanionToEpisodeRepositry;
            _mapper = mapper;
        }

        [HttpPost("/CompanionToEpisode")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> InsertEnemyEpisodData(int CompanionId, int EpisodId)
        {
           if(_CompanionToEpisodeRepositry.InsertCompanionEpisodData(CompanionId, EpisodId))
             {
                return Ok();
            }

            return BadRequest();
        }
        
    } 
}
