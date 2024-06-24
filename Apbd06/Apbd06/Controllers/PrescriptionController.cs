using Apbd06.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Apbd06;

[ApiController]
[Route("[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionRequestDto requestDto)
    {
        try
        {
            var result = await _prescriptionService.AddPrescriptionAsync(requestDto);
            if (result == null)
                return NotFound("Could not process the prescription request. Please check the inputs.");
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }
}
