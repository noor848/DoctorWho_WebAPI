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
        private readonly IEpisod _EpisodRepositry;
        private readonly IMapper _mapper;
        public EpisodController(IEpisod EpisodRepositry, IMapper mapper)
        {
            _EpisodRepositry = EpisodRepositry;
            _mapper = mapper;
        }

        [HttpPost("/Episod/CreateEpisodes")]
        public int CreateEpisodes(EpisodDto Episod,[FromQuery]int AuthorId,[FromQuery]int DoctorId)
        {
            var EpisodData = _mapper.Map<Episod>(Episod);

            if (_EpisodRepositry.CreateEpisodes(EpisodData,AuthorId,DoctorId))
            {

                return _EpisodRepositry.GetLastIdEpisod();
            }

           return 0;
        }

        [HttpGet("/Episod/GetAllEpisods")]
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
