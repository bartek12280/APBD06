using Apbd06.DTOs;

namespace Apbd06;

public interface IPatientService
{
    Task<PatientDto> GetPatientDetailsAsync(int patientId);
}