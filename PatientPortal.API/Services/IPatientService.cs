using SharedModels.Models;
using SharedModels.ViewModels;

namespace PatientPortal.API.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<DiseaseInformation>> GetDiseasesAsync();
        Task<IEnumerable<Ncd>> GetNcdsAsync();
        Task<IEnumerable<Allergy>> GetAllergiesAsync();
        Task<IEnumerable<PatientsInformation>> GetPatientsAsync();
        Task<PatientViewModel> SavePatientAsync(PatientViewModel patient);
    }
}
