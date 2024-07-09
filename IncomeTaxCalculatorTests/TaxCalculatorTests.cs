using IncomeTaxCalculator.Api;

namespace IncomeTaxCalculator.Tests
{
	public class TaxCalculatorTests
	{
		private readonly ITaxCalculator calculator;

		public TaxCalculatorTests()
		{
			calculator = new TaxCalculator(new TaxBands_UK());
		}

		[Fact]
		public void Calculate_ForSalary10000()
		{
			var result = calculator.Calculate(10000);

			Assert.Equal(10000, result.GrossAnnualSalary);
			Assert.Equal((decimal)833.33, result.GrossMonthlySalary, 2);
			Assert.Equal(9000, result.NetAnnualSalary);
			Assert.Equal(750, result.NetMonthlySalary);
			Assert.Equal(1000, result.AnnualTaxPaid);
			Assert.Equal((decimal)83.33, result.MonthlyTaxPaid, 2);
		}

		[Fact]
		public void CalculateForSalary40000()
		{
			var result = calculator.Calculate(40000);

			Assert.Equal(40000, result.GrossAnnualSalary);
			Assert.Equal((decimal)3333.33, result.GrossMonthlySalary, 2);
			Assert.Equal(29000, result.NetAnnualSalary);
			Assert.Equal((decimal)2416.67, result.NetMonthlySalary, 2);
			Assert.Equal(11000, result.AnnualTaxPaid);
			Assert.Equal((decimal)916.67, result.MonthlyTaxPaid, 2);
		}
	}
}
