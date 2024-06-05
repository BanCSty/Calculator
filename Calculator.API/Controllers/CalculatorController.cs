using Calculator.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculationApplicationService _calculationApplicationService;

        public CalculatorController(ICalculationApplicationService calculationApplicationService)
        {
            _calculationApplicationService = calculationApplicationService;
        }

        [HttpGet("calculate")]
        public IActionResult Calculate(double operand1, double operand2, string operation)
        {
            try
            {
                var result = _calculationApplicationService.Calculate(operand1, operand2, operation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
