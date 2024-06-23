using Apbd06.Models;

namespace Apbd06.Repositories;

public interface IPrescriptionMedicamentRepository
{
    Task AddPrescriptionMedicamentAsync(PrescriptionMedicament prescriptionMedicament);
}