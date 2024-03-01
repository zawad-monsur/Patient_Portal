using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.ViewModels
{
    public class PatientViewModel
    {
        public string PatientName { get; set; }
        public int DiseaseInformationId { get; set; }
        public bool HasEpilepsy { get; set; }
        public List<int>? SelectedNcdIds { get; set; }
        public List<int>? SelectedAllergyIds { get; set; }

        public List<Ncd>? AvailableNcds { get; set; }
        public List<DiseaseInformation>? AvailableDiseases { get; set; }
        public List<Allergy>? AvailableAllergies { get; set; }
    }

}
