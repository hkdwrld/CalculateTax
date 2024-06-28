using CalculateTax.DataAccess.Interfaces;
using CalculateTax.Models;
using CalculateTax.Models.ViewModels;
using CalculateTax.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalculateTax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var model = new InputForm();
            var FilingStatusOptions = new List<SelectListItem>();
            FilingStatusOptions.Add(new SelectListItem { Text = "Single", Value = "Single" });
            FilingStatusOptions.Add(new SelectListItem { Text = "Married Filing Jointly", Value = "MarriedFilingJointly" });
            FilingStatusOptions.Add(new SelectListItem { Text = "Married Filing Separately", Value = "MarriedFilingSeparately" });
            FilingStatusOptions.Add(new SelectListItem { Text = "Head of Household", Value = "HeadOfHousehold" });
            ViewBag.FilingStatusOptions = FilingStatusOptions;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(InputForm model)
        {
            if (ModelState.IsValid)
            {
                var calculation = new Calculatation(model.Income, model.FilingStatus);

                var tax = calculation.CalculateTax();

                var taxForm = new TaxForm
                {
                    Name = model.Name,
                    Income = model.Income,
                    FilingStatus = model.FilingStatus,
                    Tax = tax,
                    TaxableIncome = model.Income - calculation.GetSD(),
                    StandardDeduction = calculation.GetSD()
                };

                _unitOfWork.TaxForms.Add(taxForm);

                Convert.ToInt64(tax).ToString("C");
                ViewBag.Tax = Convert.ToInt64(tax).ToString("C");
                ViewBag.Income = Convert.ToInt64(model.Income).ToString("C");
                ViewBag.TaxableIncome = Convert.ToInt64(model.Income - calculation.GetSD()).ToString("C");
                ViewBag.FilingStatus = model.FilingStatus;
                ViewBag.StandardDeduction = Convert.ToInt64(calculation.GetSD()).ToString("C");

                return View("Result");
            }
            model.FilingStatusOptions = new List<SelectListItem>();
            model.FilingStatusOptions.Add(new SelectListItem { Text = "Single", Value = "Single" });
            model.FilingStatusOptions.Add(new SelectListItem { Text = "Married Filing Jointly", Value = "MarriedFilingJointly" });
            model.FilingStatusOptions.Add(new SelectListItem { Text = "Married Filing Separately", Value = "MarriedFilingSeparately" });
            model.FilingStatusOptions.Add(new SelectListItem { Text = "Head of Household", Value = "HeadOfHousehold" });

            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.ErrorMessage);
                }
            }

            return View(model);
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}
