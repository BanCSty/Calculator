namespace Calculator.Application.Interfaces
{
    public interface ICalculationApplicationService
    {
        double Calculate(double operand1, double operand2, string operation);
    }
}
