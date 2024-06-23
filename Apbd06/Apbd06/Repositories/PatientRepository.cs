using APBD_s24774.Models;
using Apbd06.Models;
using Apbd06.Repositories;
using Microsoft.EntityFrameworkCore;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Patient> GetPatientByIdAsync(int patientId)
    {
        return await _context.Patients.FirstOrDefaultAsync(p => p.IdPatient == patientId);
    }

    public async Task<Patient> AddPatientAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient;
    }
}