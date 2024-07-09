using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using IncomeTaxCalculator.Api;
using IncomeTaxCalculator.Api.Model;

namespace IncomeTaxCalculator.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	[EnableCors(Names.CORS_POLICY)]
	public class TaxCalculatorController : ControllerBase
	{
		private readonly ITaxCalculator calculator;
		private readonly ILogger<TaxCalculatorController> logger;

		public TaxCalculatorController(ITaxCalculator calculator, ILogger<TaxCalculatorController> logger)
		{
			this.calculator = calculator;
			this.logger = logger;
		}

		[HttpPost]
		public ActionResult<TaxCalcResult> Calculate([FromBody] TaxCalcParam param)
		{
			if (param.GrossAnnualSalary < 0)
				return BadRequest($"{nameof(param.GrossAnnualSalary)} is negative.");

			return Ok(calculator.Calculate(param.GrossAnnualSalary));
		}
	}
}
