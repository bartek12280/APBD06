using APBD_s24774.Models;
using Apbd06.Models;

namespace Apbd06.Repositories;

public class PrescriptionMedicamentRepository : IPrescriptionMedicamentRepository
{
    private readonly ApplicationDbContext _context;

    public PrescriptionMedicamentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddPrescriptionMedicamentAsync(PrescriptionMedicament prescriptionMedicament)
    {
        await _context.PrescriptionMedicaments.AddAsync(prescriptionMedicament);
        await _context.SaveChangesAsync();
    }
}
