using Apbd06.Models;

namespace Apbd06.Repositories;

public interface IDoctorRepository
{
    Task<Doctor> GetDoctorByIdAsync(int doctorId);

}