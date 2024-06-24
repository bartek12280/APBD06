using Microsoft.AspNetCore.Mvc;

namespace Apbd06;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetPatientDetails(int patientId)
    {
        var patientDetails = await _patientService.GetPatientDetailsAsync(patientId);
        if (patientDetails == null)
            return NotFound($"Patient with ID {patientId} not found.");

        return Ok(patientDetails);
    }
}
