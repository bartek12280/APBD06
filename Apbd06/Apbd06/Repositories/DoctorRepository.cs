using APBD_s24774.Models;
using Apbd06.Models;
using Microsoft.EntityFrameworkCore;

namespace Apbd06.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
    {
        return await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == doctorId);
    }
}
