using System.ComponentModel.DataAnnotations;
namespace CalculateTax.Models.ViewModels
{
    public enum TaxFilingStatus
    {
        Single,
        MarriedFilingJointly,
        MarriedFilingSeparately,
        HeadOfHousehold
    }

    public class InputForm
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter your Annual Income")]
        [Display(Name = "Annual Income")]
        public Decimal Income { get; set; } = 75000;

        [Required(ErrorMessage = "Please enter your Tax Filing Status")]
        public string? FilingStatus { get; set; }
        //public string? FilingStatus { get; set; }
        //do not validate
        public List<SelectListItem>? FilingStatusOptions { get; set; }
    }

    public class SelectListItem
    {
        public string? Text { get; set; }
        public string? Value { get; set; }
    }
}
