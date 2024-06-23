using Apbd06.Models;

namespace Apbd06.Repositories;

public interface IMedicamentRepository
{
    Task<Medicament> GetMedicamentByIdAsync(int medicamentId);
}