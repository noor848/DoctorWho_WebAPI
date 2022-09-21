using DoctorWho.Db.Interface;
using DoctorWho.Dto;
using DoctorWho.helper;
using EfDoctorWho;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EFCore;

namespace DoctorWho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctor _DoctorRepositry;
        private readonly  IMapper _mapper;
        public DoctorController(IDoctor DoctorRepositry, IMapper mapper )
        {
            _DoctorRepositry = DoctorRepositry;
            _mapper = mapper;
        }

        [HttpGet("Doctors/", Name = "GetAllDoctors")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        public IActionResult GetAllDoctors()
        {
            var Doctors = _mapper.Map<List<DoctorDto>>(_DoctorRepositry.GetAllDoctors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Doctors);
        }

        [HttpDelete("Doctors/", Name = "DeleteDoctors")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDoctors(int id)
        {
            if (_DoctorRepositry.DeleteDoctor(id))
            {
                return Ok();    
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                 return NotFound();
        }

        [HttpPost("Doctors/",Name = "UpsertDoctors")]
        public DoctorDto UpsertDoctors([FromBody] DoctorDto doctor)
        {
            var Doctors = _mapper.Map<List<DoctorDto>>(_DoctorRepositry.GetAllDoctors()).Find(s=>s.Id == doctor.Id);
          
                if (Doctors!=null)
                {
                    var doctordata = _mapper.Map<Doctor>(doctor);

                    _DoctorRepositry.updateDoctorData(doctordata);
                }
            else
            {
                var doctordata = _mapper.Map<Doctor>(doctor);
                _DoctorRepositry.CreateDoctor(doctordata);
                Console.WriteLine(doctordata.LastEpisodDate.ToString("MM-dd-yyyy"));
            }

                    return doctor;
            }

        }

    } 
