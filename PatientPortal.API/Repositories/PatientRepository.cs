using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace PatientPortal.API.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientsContext _context; 

        public PatientRepository(PatientsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiseaseInformation>> GetDiseasesAsync()
        {
            return await _context.DiseaseInformations.ToListAsync(); 
        }

        public async Task<IEnumerable<Ncd>> GetNcdsAsync()
        {
            return await _context.Ncds.ToListAsync(); 
        }

        public async Task<IEnumerable<Allergy>> GetAllergiesAsync()
        {
            return await _context.Allergies.ToListAsync(); 
        }

        public async Task<IEnumerable<PatientsInformation>> GetPatientsAsync()
        {
            return await _context.PatientsInformations.ToListAsync(); 
        }

        public async Task SavePatientAsync(PatientsInformation patient)
        {
            _context.PatientsInformations.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task SavePatientNcdsAsync(int patientId, IEnumerable<int> ncdIds)
        {
            var patientNcds = ncdIds.Select(ncdId => new NcdDetail { Ncdid = ncdId });
            await _context.NcdDetails.AddRangeAsync(patientNcds); 
            await _context.SaveChangesAsync();
        }


        public async Task SavePatientAllergiesAsync(int patientId, IEnumerable<int> allergyIds)
        {
            var patientAllergies = allergyIds.Select(allergyId => new AllergiesDetail { AllergiesId = allergyId });
            await _context.AllergiesDetails.AddRangeAsync(patientAllergies);
            await _context.SaveChangesAsync();
        }
    }
}
