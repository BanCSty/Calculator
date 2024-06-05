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

        /// <summary>
        /// Performs arithmetic operation with numbers 
        /// </summary>
        /// <remake>
        /// Sample request:
        /// Get /calculate?operand1=1&operand2=2&operation=+
        /// </remake>
        /// <param name="operand1">1</param>
        /// <param name="operand2">2</param>
        /// <param name="operation">+</param>
        /// <returns>Return 3</returns>
        /// <response code="200">Success</response>
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
