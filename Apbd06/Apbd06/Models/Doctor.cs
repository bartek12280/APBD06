namespace Apbd06.Models;

public class Doctor
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}