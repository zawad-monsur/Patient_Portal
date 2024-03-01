using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PartientPortal.MVC.Models;
using SharedModels.Models;
using SharedModels.ViewModels;
using System.Diagnostics;

namespace PartientPortal.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Patient()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7027/"); 

                    var diseasesResponse = await client.GetAsync("/api/Patients/diseases");
                    var ncdsResponse = await client.GetAsync("/api/Patients/ncds");
                    var allergiesResponse = await client.GetAsync("/api/Patients/allergies");

                    if (diseasesResponse.IsSuccessStatusCode && ncdsResponse.IsSuccessStatusCode && allergiesResponse.IsSuccessStatusCode)
                    {
                        var diseasesContent = await diseasesResponse.Content.ReadAsStringAsync();
                        var ncdsContent = await ncdsResponse.Content.ReadAsStringAsync();
                        var allergiesContent = await allergiesResponse.Content.ReadAsStringAsync();

                        var diseases = JsonConvert.DeserializeObject<List<DiseaseInformation>>(diseasesContent);
                        var ncds = JsonConvert.DeserializeObject<List<Ncd>>(ncdsContent);
                        var allergies = JsonConvert.DeserializeObject<List<Allergy>>(allergiesContent);

                        // Create view model
                        var model = new PatientViewModel
                        {
                            AvailableDiseases = diseases,
                            AvailableNcds = ncds,
                            AvailableAllergies = allergies
                        };

                        return View(model);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching data: {ex.Message}");
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SavePatient(PatientViewModel patient)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7027/"); 

                    var response = await client.PostAsJsonAsync("/api/Patients", patient);

                    if (response.IsSuccessStatusCode)
                    {
                        var savedPatient = await response.Content.ReadFromJsonAsync<PatientViewModel>();
                        return RedirectToAction("Patient");
                    }
                    else
                    {
                        _logger.LogError($"Error saving patient: {response.ReasonPhrase}");
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving patient: {ex.Message}");
                return View("Error");
            }
        }

    }
}
