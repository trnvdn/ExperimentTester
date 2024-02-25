using ExperimentTester.Models.ViewModels;
using ExperimentTester.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ExperimentTester.Controllers
{
    public class StatisticsController : Controller
    {
        private ExperimentStatisticsViewModel _experimentStatisticsViewModel;
        private readonly IExperimentsDetailsService _experimentsDetailsService;
        public StatisticsController(IExperimentsDetailsService experimentsDetailsService)
        {
            _experimentsDetailsService = experimentsDetailsService;
            _experimentStatisticsViewModel = new ExperimentStatisticsViewModel();
        }
        public async Task<IActionResult> Index()
        {
            _experimentStatisticsViewModel.ButtonExperiment = await _experimentsDetailsService.GetExperimentsDetailsAsync("button_color");
            _experimentStatisticsViewModel.PriceExperiment = await _experimentsDetailsService.GetExperimentsDetailsAsync("price");
            _experimentStatisticsViewModel.DistributionStats = _experimentsDetailsService.DeviceTokenDistribution(); 

            return View(_experimentStatisticsViewModel);
        }

        [HttpPost]
        public IActionResult DeleteAllData()
        {
            _experimentsDetailsService.DeleteAllData();

            return RedirectToAction("Index");
        }
    }
}
