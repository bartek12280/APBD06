using Apbd06.DTOs;
using Apbd06.Models;
using Apbd06.Repositories;

namespace Apbd06;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IMedicamentRepository _medicamentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository,
                               IMedicamentRepository medicamentRepository,
                               IPatientRepository patientRepository,
                               IDoctorRepository doctorRepository)
    {
        _prescriptionRepository = prescriptionRepository;
        _medicamentRepository = medicamentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task AddPrescriptionAsync(PrescriptionDto prescriptionDto)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(prescriptionDto.DoctorId);
        if (doctor == null) throw new ArgumentException("Doctor does not exist.");
        
        var patient = await _patientRepository.GetPatientByIdAsync(prescriptionDto.PatientId);
        if (patient == null)
        {
            patient = new Patient { IdPatient = prescriptionDto.PatientId, FirstName = "New", LastName = "Patient" }; // Ustaw odpowiednie wartości
            await _patientRepository.AddPatientAsync(patient);
        }
        
        var prescription = new Prescription
        {
            Date = DateTime.Now,
            DueDate = prescriptionDto.DueDate,
            DoctorId = doctor.IdDoctor,
            PatientId = patient.IdPatient,
            PrescriptionMedicaments = prescriptionDto.PrescriptionMedicaments.Select(m => new PrescriptionMedicament
            {
                Medicament = _medicamentRepository.GetMedicamentByIdAsync(m.IdMedicament).Result,
            }).ToList()
        };
        
        if (prescription.PrescriptionMedicaments.Count > 10)
            throw new ArgumentException("Prescription can have a maximum of 10 medicaments.");

        await _prescriptionRepository.AddPrescriptionAsync(prescription);
    }
}