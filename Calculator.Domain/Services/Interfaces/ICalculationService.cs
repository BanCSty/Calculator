using Calculator.Domain.Entities;
using Calculator.Domain.ValueObjects;

namespace Calculator.Domain.Services.Interfaces
{
    internal interface ICalculationService
    {
        CalculationResult PerformCalculation(Calculation calculation);
    }
}
