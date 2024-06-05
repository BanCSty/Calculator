using System.Net.Http.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://localhost:7088/")
        };

        while (true) // Бесконечный цикл
        {
            Console.WriteLine("Calculator Client");
            Console.WriteLine("Enter the first number:");
            double operand1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            double operand2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operation (+, -, *, /):");
            string operation = Console.ReadLine();

            // Кодирование операции
            var encodedOperation = Uri.EscapeDataString(operation); 

            //Формирование запроса
            var query = $"api/Calculator/calculate?operand1={operand1}&operand2={operand2}&operation={encodedOperation}";

            try
            {
                var response = await httpClient.GetAsync(query);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<double>();
                Console.WriteLine($"The result is: {result}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }

            Console.WriteLine("Press Enter to continue or type 'exit' to quit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
                break; // Выход из цикла, если пользователь ввел 'exit'
        }
    }
}
