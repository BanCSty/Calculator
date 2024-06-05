using Calculator.Application.Implementations;
using Calculator.Application.Interfaces;
using Calculator.Domain.Entities;
using Calculator.Domain.Services.Interfaces;
using Calculator.Domain.ValueObjects;
using Moq;

namespace Calculator.Tests.Application.Services
{
    public class CalculationApplicationServiceTests
    {
        private readonly Mock<ICalculationService> _mockCalculationService;
        private readonly ICalculationApplicationService _calculationApplicationService;

        public CalculationApplicationServiceTests()
        {
            _mockCalculationService = new Mock<ICalculationService>();
            _calculationApplicationService = new CalculationApplicationService(_mockCalculationService.Object);
        }

        [Theory]
        [InlineData(1, 2, "+", 3)]
        [InlineData(5, 3, "-", 2)]
        [InlineData(2, 3, "*", 6)]
        [InlineData(6, 3, "/", 2)]
        public void Calculate_PerformsCorrectOperation(double operand1, double operand2, string operation, double expectedResult)
        {
            // Arrange
            var calculation = new Calculation(operand1, operand2, operation switch
            {
                "+" => OperationType.Addition,
                "-" => OperationType.Subtraction,
                "*" => OperationType.Multiplication,
                "/" => OperationType.Division,
                _ => throw new InvalidOperationException("Invalid operator")
            });
            _mockCalculationService.Setup(s => s.PerformCalculation(It.IsAny<Calculation>()))
                                   .Returns(new CalculationResult(expectedResult));

            // Act
            var result = _calculationApplicationService.Calculate(operand1, operand2, operation);

            // Assert
            Assert.Equal(expectedResult, result);
            _mockCalculationService.Verify(s => s.PerformCalculation(It.IsAny<Calculation>()), Times.Once);
        }

        [Fact]
        public void Calculate_InvalidOperator_ThrowsInvalidOperationException()
        {
            // Arrange
            double operand1 = 1;
            double operand2 = 2;
            string invalidOperation = "^";

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _calculationApplicationService.Calculate(operand1, operand2, invalidOperation));
        }

        [Fact]
        public void Calculate_DivisionByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            double operand1 = 1;
            double operand2 = 0;
            string operation = "/";

            _mockCalculationService.Setup(s => s.PerformCalculation(It.IsAny<Calculation>()))
                                   .Throws<DivideByZeroException>();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculationApplicationService.Calculate(operand1, operand2, operation));
        }
    }
}
