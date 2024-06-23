using APBD_s24774.Models;
using Apbd06.Models;
using Microsoft.EntityFrameworkCore;

namespace Apbd06.Repositories;

public class MedicamentRepository : IMedicamentRepository
{
    private readonly ApplicationDbContext _context;

    public MedicamentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Medicament> GetMedicamentByIdAsync(int medicamentId)
    {
        return await _context.Medicaments.FirstOrDefaultAsync(m => m.IdMedicament == medicamentId);
    }
}
