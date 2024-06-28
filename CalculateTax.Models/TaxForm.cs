using System.ComponentModel.DataAnnotations;

namespace CalculateTax.Models
{
    public class TaxForm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Income { get; set; } = 0;
        [Required]
        public string? FilingStatus { get; set; }
        public decimal? Tax { get; set; } = 0;
        public decimal? TaxableIncome { get; set; } = 0;
        public decimal? StandardDeduction { get; set; } = 0;

    }
}

//write sql command to create dbo.TaxForm table in database
//CREATE TABLE[dbo].[TaxForms] (
//    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
//    [Name] NVARCHAR (MAX) NULL,
//    [Income] DECIMAL (18, 2) NOT NULL,
//    [FilingStatus] NVARCHAR (MAX) NOT NULL,
//    [Tax] DECIMAL (18, 2) NULL,
//    [TaxableIncome] DECIMAL (18, 2) NULL,
//    [StandardDecuction] DECIMAL (18, 2) NULL
//);

//write sql command to create stored procedure sp.AddTaxForm in database
//CREATE PROCEDURE [sp].[AddTaxForm]
//    @Name NVARCHAR(MAX),
//    @Income DECIMAL(18, 2),
//    @FilingStatus NVARCHAR(MAX),
//    @Tax DECIMAL(18, 2),
//    @TaxableIncome DECIMAL(18, 2),
//    @StandardDecuction DECIMAL(18, 2)
//AS
//BEGIN
//    INSERT INTO [dbo].[TaxForm] ([Name], [Income], [FilingStatus] [Tax], [TaxableIncome], [StandardDecuction])
//    VALUES (@Name, @Income, @FilingStatus, @Tax, @TaxableIncome, @StandardDecuction)
//END;
//GO

//write sql command to create stored procedure GetAllTaxForms in database
//CREATE PROCEDURE [sp].[GetAllTaxForms]
//AS
//BEGIN
//    SELECT * FROM [dbo].[TaxForm]
//END;
//GO


