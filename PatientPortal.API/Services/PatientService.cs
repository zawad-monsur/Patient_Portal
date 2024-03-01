using PatientPortal.API.Repositories;
using SharedModels.Models;
using SharedModels.ViewModels;

namespace PatientPortal.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<DiseaseInformation>> GetDiseasesAsync()
        {
            return await _patientRepository.GetDiseasesAsync();
        }

        public async Task<IEnumerable<Ncd>> GetNcdsAsync()
        {
            return await _patientRepository.GetNcdsAsync();
        }

        public async Task<IEnumerable<Allergy>> GetAllergiesAsync()
        {
            return await _patientRepository.GetAllergiesAsync();
        }

        public async Task<IEnumerable<PatientsInformation>> GetPatientsAsync()
        {
            return await _patientRepository.GetPatientsAsync();
        }

        public async Task<PatientViewModel> SavePatientAsync(PatientViewModel patient)
        {
            // 1. Save patient information
            var patientEntity = new PatientsInformation
            {
                FirstName = patient.PatientName,
                HasEpilepsy = patient.HasEpilepsy,
                // ... (map other properties)
            };

            await _patientRepository.SavePatientAsync(patientEntity);

            // Retrieve the generated ID after saving
            patientEntity.PatientId = patientEntity.PatientId; // Assuming the repository returns or sets the ID

            // 2. Save selected NCDs and allergies (assuming foreign key relationships)
            var selectedNcdIds = patient.SelectedNcdIds;
            await _patientRepository.SavePatientNcdsAsync(patientEntity.PatientId, selectedNcdIds);

            var selectedAllergyIds = patient.SelectedAllergyIds;
            await _patientRepository.SavePatientAllergiesAsync(patientEntity.PatientId, selectedAllergyIds);

            return patient;
        }
    }
}
