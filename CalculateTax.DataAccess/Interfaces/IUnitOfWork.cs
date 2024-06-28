namespace CalculateTax.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ITaxForm TaxForms { get; }
    }
}
