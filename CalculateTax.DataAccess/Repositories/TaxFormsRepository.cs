using CalculateTax.DataAccess.Data;
using CalculateTax.DataAccess.Interfaces;
using CalculateTax.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CalculateTax.DataAccess.Repositories
{
    public class TaxFormsRepository : ITaxForm
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        public TaxFormsRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<TaxForm> Add(TaxForm entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", entity.Name);
            parameters.Add("@Income", entity.Income);
            parameters.Add("@FilingStatus", entity.FilingStatus);
            parameters.Add("@Tax", entity.Tax);
            parameters.Add("@TaxableIncome", entity.TaxableIncome);
            parameters.Add("@StandardDeduction", entity.StandardDeduction);

            //var result = await _connection.QueryAsync<TaxForm>("AddTaxForm", parameters, commandType: CommandType.StoredProcedure);
            await _connection.ExecuteAsync("AddTaxFormCalculated", parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public async Task<TaxForm> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaxForm>> GetAll()
        {
            return await _connection.QueryAsync<TaxForm>("GetAllTaxForms", commandType: CommandType.StoredProcedure);
        }

        public async Task<TaxForm> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TaxForm> Update(TaxForm entity)
        {
            throw new NotImplementedException();
        }
    }
}
