using Apbd06.Models;

namespace Apbd06.Repositories;

public interface IPatientRepository
{
    Task<Patient> GetPatientByIdAsync(int patientId);
    Task<Patient> AddPatientAsync(Patient patient);
}