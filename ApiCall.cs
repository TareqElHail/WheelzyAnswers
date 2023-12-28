using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiUrl = "https://notrealapi.com/lottery/play";
        int attempts = 10;

        for (int i = 0; i < attempts; i++)
        {
            try
            {
                int customerNumber = GenerateRandomNumber();
                Console.WriteLine($"Attempt {i + 1}: Sending customer number {customerNumber}...");

                int result = await PlayLottery(apiUrl, customerNumber);

                Console.WriteLine($"Received result: {result}");

                // Check if you won
                if (result == customerNumber)
                {
                    Console.WriteLine("Congratulations! You won!");
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, you didn't win this time.");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                // Handle specific HTTP request issues
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                // Handle other exceptions
            }

            // Introduce a delay between attempts if needed
            await Task.Delay(1000); // 1 second delay
        }
    }

    static async Task<int> PlayLottery(string apiUrl, int customerNumber)
    {
        using (var client = new HttpClient())
        {
            var content = new StringContent($"{{\"customerNumber\": {customerNumber}}}");

            var response = await client.PostAsync(apiUrl, content);

            response.EnsureSuccessStatusCode(); // Ensure the request was successful

            string resultString = await response.Content.ReadAsStringAsync();
            return int.Parse(resultString);
        }
    }

    static int GenerateRandomNumber()
    {
        Random rand = new Random();
        return rand.Next(1000, 9999);
    }
}
