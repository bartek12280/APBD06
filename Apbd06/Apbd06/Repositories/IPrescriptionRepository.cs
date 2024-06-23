using Apbd06.Models;

namespace Apbd06.Repositories;

public interface IPrescriptionRepository
{
    Task<Prescription> AddPrescriptionAsync(Prescription prescription);
}