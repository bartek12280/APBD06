using Apbd06.Models;

namespace Apbd06.DTOs;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public List<MedicamentDto> PrescriptionMedicaments { get; set; } = new List<MedicamentDto>();
}
