using DoctorWho.Db.Interface;
using DoctorWho.Dto;
using DoctorWho.helper;
using EfDoctorWho;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EFCore;
using FluentValidation.Results;
using DoctorWho.validation;
using FluentValidation;

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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctord>))]
        public async Task<IActionResult> GetAllDoctors()
        {
            var listDoctor = await _DoctorRepositry.GetAllDoctors();
            var Doctors = _mapper.Map<List<Doctord>>(listDoctor);

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
        public async Task<Doctord> UpsertDoctors([FromBody]Doctord doctor)
        {

            var Doctors= await _DoctorRepositry.GetDoctorByNumber(doctor.DoctorNumber);
            if (Doctors != null)
            {
                DoctorValidator doctorValidiate = new DoctorValidator();
                var result = doctorValidiate.Validate(Doctors);

                if (result.IsValid)
                {
                    var doctordata = _mapper.Map<Doctor>(doctor);
                await _DoctorRepositry.updateDoctorData(doctordata);
                }

            }
            else
            {
                var doctordata = _mapper.Map<Doctor>(doctor);
               DoctorValidator doctorValidiate = new DoctorValidator();
                var result = doctorValidiate.Validate(doctordata);
                if (result.IsValid)
                {
                    _DoctorRepositry.CreateDoctor(doctordata);

              }
            }

            return doctor;
        }
       /* public ValidationResult ValidateDoctor(Doctor Doctors)
        {
            DoctorValidator doctorValidiate = new DoctorValidator();
            return doctorValidiate.Validate(Doctors);
        }
        */

    }
}
