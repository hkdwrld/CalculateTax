using CalculateTax.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalculateTax.Controllers
{
    [Authorize]
    public class TaxFormController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaxFormController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var taxForms = await _unitOfWork.TaxForms.GetAll();
            return View(taxForms);
        }
    }
}
