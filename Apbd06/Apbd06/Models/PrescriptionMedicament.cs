namespace Apbd06.Models;

public class PrescriptionMedicament
{
    public int IdPrescription { get; set; }
    public int IdMedicament { get; set; }
    public virtual Prescription Prescription { get; set; }
    public virtual Medicament Medicament { get; set; }
}