namespace Apbd06.DTOs;

public class PrescriptionMedicamentDto
{
    public int IdPrescription { get; set; }
    public int IdMedicament { get; set; }
    public MedicamentDto Medicament { get; set; }
}