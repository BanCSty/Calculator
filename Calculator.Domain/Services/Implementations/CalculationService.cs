using Calculator.Domain.Entities;
using Calculator.Domain.Services.Interfaces;
using Calculator.Domain.ValueObjects;

namespace Calculator.Domain.Services.Implementations
{
    public class CalculationService : ICalculationService
    {
        public CalculationResult PerformCalculation(Calculation calculation)
        {
            double result = calculation.Operation switch
            {
                OperationType.Addition => calculation.Operand1 + calculation.Operand2,
                OperationType.Subtraction => calculation.Operand1 - calculation.Operand2,
                OperationType.Multiplication => calculation.Operand1 * calculation.Operand2,
                OperationType.Division => calculation.Operand2 != 0 ? calculation.Operand1 / calculation.Operand2 : throw new DivideByZeroException(),
                _ => throw new InvalidOperationException("Invalid operator")
            };

            calculation.SetResult(result);

            return new CalculationResult(result);
        }
    }
}
