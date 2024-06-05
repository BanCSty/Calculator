using Calculator.Domain.Entities;
using Calculator.Domain.ValueObjects;

namespace Calculator.Domain.Services.Interfaces
{
    public interface ICalculationService
    {
        CalculationResult PerformCalculation(Calculation calculation);
    }
}
