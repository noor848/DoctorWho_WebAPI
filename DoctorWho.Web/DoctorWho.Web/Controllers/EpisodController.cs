using DoctorWho.Db.Interface;
using EfDoctorWho;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DoctorWho.Dto;

namespace DoctorWho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodController : Controller
    {
        private readonly IEpisodRepository _EpisodRepositry;
        private readonly IMapper _mapper;
        public EpisodController(IEpisodRepository EpisodRepositry, IMapper mapper)
        {
            _EpisodRepositry = EpisodRepositry;
            _mapper = mapper;
        }

        [HttpPost("/Episod",Name = "CreateEpisodes")]
        public async  Task<int> CreateEpisodes(EpisodDto Episod,int AuthorId,int DoctorId)
        {
            var EpisodData = _mapper.Map<Episod>(Episod);
            var createEpisod = await _EpisodRepositry.CreateEpisodes(EpisodData, AuthorId, DoctorId);

            if (createEpisod)
            {
                return await _EpisodRepositry.GetLastIdEpisod();
            }

           return 0;
        }

        [HttpGet("/Episod", Name = "GetAllEpisods")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Episod>))]
        public IActionResult GetAllEpisods()
        {
            var Episods = _EpisodRepositry.GetAllEpisods();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Episods);
        } }


 

}
