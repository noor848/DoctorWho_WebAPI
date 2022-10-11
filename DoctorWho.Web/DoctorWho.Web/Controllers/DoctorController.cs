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
        private readonly IDoctorRepository _DoctorRepositry;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorRepository DoctorRepositry, IMapper mapper)
        {
            _DoctorRepositry = DoctorRepositry;
            _mapper = mapper;
        }

        [HttpGet("Doctors/", Name = "GetAllDoctors")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EfDoctorWho.Doctor>))]
        public async Task<IActionResult> GetAllDoctors()
        {
            var listDoctor = await _DoctorRepositry.GetAllDoctors();
            var Doctors = _mapper.Map<List<Dto.Doctord>>(listDoctor);

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
        public async Task<IActionResult> DeleteDoctors(int id)
        {
            bool DoctorId =await _DoctorRepositry.DeleteDoctor(id);
            if (DoctorId)
            {
                return Ok();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NotFound();
        }

        [HttpPost("Doctors/", Name = "UpsertDoctors")]
        public async Task<Dto.Doctord> UpsertDoctors([FromBody] Dto.Doctord doctor)
        {
            var Doctors= await _DoctorRepositry.GetDoctorByNumber(doctor.DoctorNumber);
           
            if (Doctors != null)
            {
                var doctordata = _mapper.Map<EfDoctorWho.Doctor>(doctor);

                _DoctorRepositry.updateDoctorData(doctordata);
            }
            else
            {
                var doctordata = _mapper.Map<EfDoctorWho.Doctor>(doctor);
                 _DoctorRepositry.CreateDoctor(doctordata);
                Console.WriteLine(doctordata.LastEpisodDate.ToString("MM-dd-yyyy"));
            }

            return doctor;
        }

    }
}
