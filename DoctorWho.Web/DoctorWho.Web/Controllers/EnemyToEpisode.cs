using DoctorWho.Db.Interface;
using DoctorWho.Dto;
using DoctorWho.helper;
using EfDoctorWho;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace DoctorWho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemyToEpisodeController : Controller
    {
        private readonly IEnemyToEpisodeRepository _EnemyToEpisodeRepositry;
        private readonly  IMapper _mapper;
        public EnemyToEpisodeController(IEnemyToEpisodeRepository EnemyToEpisodeRepositry, IMapper mapper)
        {
            _EnemyToEpisodeRepositry = EnemyToEpisodeRepositry;
            _mapper = mapper;
        }

        [HttpPost("/Enemy/{EnemyId}/Episod/{EpisodId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult InsertEnemyEpisodData(int EnemyId, int EpisodId)
        {
           if(_EnemyToEpisodeRepositry.InsertEnemyEpisodData(EnemyId, EpisodId))
             {
                return Ok();
            }

            return BadRequest();

        }

        
    } 
}
