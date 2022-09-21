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
    public class AuthortController : Controller
    {
        private readonly lAuthor _AuthorRepositry;
        private readonly  IMapper _mapper;
        public AuthortController(lAuthor AuthorRepositry, IMapper mapper)
        {
            _AuthorRepositry = AuthorRepositry;
            _mapper = mapper;
        }

        [HttpPut("/Author/authorName/")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        public IActionResult UpdateAuthorName(int AuthorId,string AuthorName)
        {
            if(_AuthorRepositry.updateAuthorName(AuthorId,AuthorName))
            {
                return Ok();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

        
    } 
}
