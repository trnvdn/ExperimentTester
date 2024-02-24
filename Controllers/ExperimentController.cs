    using ExperimentTester.Models;
    using ExperimentTester.Services.IServices;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    namespace ExperimentTester.Controllers
    {
        public class ExperimentController : Controller
        {
            private readonly IExperimentHandlerService _experimentHandlerService;
            private readonly ILogger<ExperimentController> _logger;
            public ExperimentController(IExperimentHandlerService experimentHandlerService, ILogger<ExperimentController> logger)
            {
                _experimentHandlerService = experimentHandlerService;
                _logger = logger;
            }

            public async Task<IActionResult> Index()
            {
                return View(new List<ExperimentResult>());
            }

            [HttpPost("experiment/multiple/{xName}/{count}")]
            public async Task<IActionResult> GetButtonColorExperiments(string xName, int count)
            {
                var result = new List<ExperimentResult>();
                try
                {
                    result = await _experimentHandlerService.RunExperiments(xName, count);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{nameof(GetButtonColorExperiments)} {ex.Message}");
                }
                return PartialView("_ExperimentPartialView", result);
            }

            [HttpPost("experiment/{xName}/{deviceToken}")]
            public async Task<IActionResult> GetButtonColorExperiments(string xName, Guid deviceToken)
            {
                var result = new List<ExperimentResult>();
                try
                {
                    result = await _experimentHandlerService.RunExperiment(xName, deviceToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{nameof(GetButtonColorExperiments)} {ex.Message}");
                }
                return PartialView("_ExperimentPartialView", result);
            }


            [Route("/error")]
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
