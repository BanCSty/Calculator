namespace Calculator.Domain.Entities
{

    public class Calculation
    {
        public double Operand1 { get; private set; }
        public double Operand2 { get; private set; }
        public OperationType Operation { get; private set; }
        public double? Result { get; private set; }

        public Calculation(double operand1, double operand2, OperationType operation)
        {
            Operand1 = operand1;
            Operand2 = operand2;
            Operation = operation;
        }

        public void SetResult(double result)
        {
            Result = result;
        }
    }

    public enum OperationType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
