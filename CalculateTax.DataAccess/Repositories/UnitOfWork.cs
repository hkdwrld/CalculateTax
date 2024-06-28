using CalculateTax.DataAccess.Interfaces;

namespace CalculateTax.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITaxForm TaxForms { get; set; }
        public UnitOfWork(ITaxForm TaxForm)
        {
            this.TaxForms = TaxForm;
        }
    }
}
