using SharedModels.Models;

namespace PatientPortal.API.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<DiseaseInformation>> GetDiseasesAsync();
        Task<IEnumerable<Ncd>> GetNcdsAsync();
        Task<IEnumerable<Allergy>> GetAllergiesAsync();
        Task<IEnumerable<PatientsInformation>> GetPatientsAsync();
        Task SavePatientAsync(PatientsInformation patient);
        Task SavePatientNcdsAsync(int patientId, IEnumerable<int> ncdIds);
        Task SavePatientAllergiesAsync(int patientId, IEnumerable<int> allergyIds);
    }
}
