using Calculator.Application.Interfaces;
using Calculator.Domain.Entities;
using Calculator.Domain.Services.Interfaces;

namespace Calculator.Application.Implementations
{
    public class CalculationApplicationService : ICalculationApplicationService
    {
        private readonly ICalculationService _calculationService;

        public CalculationApplicationService(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public double Calculate(double operand1, double operand2, string operation)
        {
            var operationType = operation switch
            {
                "+" => OperationType.Addition,
                "-" => OperationType.Subtraction,
                "*" => OperationType.Multiplication,
                "/" => OperationType.Division,
                _ => throw new InvalidOperationException("Invalid operator")
            };

            var calculation = new Calculation(operand1, operand2, operationType);
            var result = _calculationService.PerformCalculation(calculation);
            return result.Value;
        }
    }
}
