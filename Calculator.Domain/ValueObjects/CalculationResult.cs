namespace Calculator.Domain.ValueObjects
{
    public class CalculationResult
    {
        public double Value { get; }

        public CalculationResult(double value)
        {
            Value = value;
        }
    }
}
