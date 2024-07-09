using IncomeTaxCalculator.Api.Model;

namespace IncomeTaxCalculator.Api
{
	public interface ITaxCalculator
	{
		TaxCalcResult Calculate(decimal salary);
	}

	public class TaxCalculator : ITaxCalculator
	{
		private readonly ITaxBands bands;

		public TaxCalculator(ITaxBands bands)
		{
			this.bands = bands;
		}

		public TaxCalcResult Calculate(decimal salary)
		{
			const int MONTHS = 12;
			var tax = CalculateTax(salary);
			return new TaxCalcResult
			{
				GrossAnnualSalary = salary,
				GrossMonthlySalary = salary / MONTHS,
				NetAnnualSalary = salary - tax,
				NetMonthlySalary = (salary - tax) / MONTHS,
				AnnualTaxPaid = tax,
				MonthlyTaxPaid = tax / MONTHS
			};
		}

		private decimal CalculateTax(decimal salary)
		{
			decimal ret = 0;
			var remainder = salary;
			foreach (var band in bands.Items)
			{
				if (remainder <= 0)
					break;
				var taxable = Math.Min(remainder, band.UpperSalary - band.LowerSalary);
				ret += taxable * band.TaxRate / 100;
				remainder -= taxable;
			}
			return ret;
		}
	}
}