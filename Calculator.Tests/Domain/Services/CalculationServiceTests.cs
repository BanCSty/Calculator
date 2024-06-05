using Calculator.Domain.Entities;
using Calculator.Domain.Services.Implementations;
using Calculator.Domain.Services.Interfaces;

namespace Calculator.Tests.Domain.Services
{
    public class CalculationServiceTests
    {
        private readonly ICalculationService _calculationService;

        public CalculationServiceTests()
        {
            _calculationService = new CalculationService();
        }

        [Fact]
        public void PerformCalculation_Addition_ReturnsCorrectResult()
        {
            var calculation = new Calculation(1, 2, OperationType.Addition);
            var result = _calculationService.PerformCalculation(calculation);
            Assert.Equal(3, result.Value);
        }

        [Fact]
        public void PerformCalculation_Subtraction_ReturnsCorrectResult()
        {
            var calculation = new Calculation(5, 3, OperationType.Subtraction);
            var result = _calculationService.PerformCalculation(calculation);
            Assert.Equal(2, result.Value);
        }

        [Fact]
        public void PerformCalculation_Multiplication_ReturnsCorrectResult()
        {
            var calculation = new Calculation(2, 3, OperationType.Multiplication);
            var result = _calculationService.PerformCalculation(calculation);
            Assert.Equal(6, result.Value);
        }

        [Fact]
        public void PerformCalculation_Division_ReturnsCorrectResult()
        {
            var calculation = new Calculation(6, 3, OperationType.Division);
            var result = _calculationService.PerformCalculation(calculation);
            Assert.Equal(2, result.Value);
        }

        [Fact]
        public void PerformCalculation_DivisionByZero_ThrowsDivideByZeroException()
        {
            var calculation = new Calculation(1, 0, OperationType.Division);
            Assert.Throws<DivideByZeroException>(() => _calculationService.PerformCalculation(calculation));
        }
    }
}
