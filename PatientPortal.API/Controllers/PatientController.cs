using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientPortal.API.Services;
using SharedModels.ViewModels;

namespace PatientPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("diseases")]
        public async Task<IActionResult> GetDiseases()
        {
            try
            {
                var diseases = await _patientService.GetDiseasesAsync();
                return Ok(diseases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ncds")]
        public async Task<IActionResult> GetNcds()
        {
            try
            {
                var ncds = await _patientService.GetNcdsAsync();
                return Ok(ncds);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpGet("allergies")]
        public async Task<IActionResult> GetAllergies()
        {
            try
            {
                var allergies = await _patientService.GetAllergiesAsync();
                return Ok(allergies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        //[HttpGet("patients")]
        //public async Task<IActionResult> GetPatients()
        //{
        //    try
        //    {
        //        var patients = await _patientService.GetPatientsAsync();
        //        return Ok(patients);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] PatientViewModel patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                var savedPatient = await _patientService.SavePatientAsync(patient);
                return Ok(savedPatient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
