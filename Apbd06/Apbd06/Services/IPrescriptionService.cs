using Apbd06.DTOs;

namespace Apbd06;

public interface IPrescriptionService
{
    Task AddPrescriptionAsync(PrescriptionDto prescriptionDto);
}