using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey(true);

            // Создаем класс для выполнения http-запросов
            HttpClient httpClient = new HttpClient();

            while (true)
            {
                try
                {
                    // Запрашиваем у пользователя ввод числа
                    Console.Write("Enter a number: ");
                    string userInput = Console.ReadLine();

                    // Выполняем запрос с использованием введенного числа
                    HttpResponseMessage response = await httpClient.GetAsync($"http://numbersapi.com/{userInput}?json");

                    // Проверяем статус ответа
                    if (response.IsSuccessStatusCode)
                    {
                        // Читаем ответ как строку
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Парсим ответ в объект NumberFact
                        NumberFact numberFact = JsonConvert.DeserializeObject<NumberFact>(responseBody);

                        if (numberFact.Found)
                        {
                            Console.WriteLine($"Fact about {numberFact.Number}: {numberFact.Text}");
                        }
                        else
                        {
                            Console.WriteLine($"There are no facts about '{numberFact.Number}'");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                // Зацикливание
                Console.WriteLine("Do you want to continue? (y/n)");
                char reply = Console.ReadKey(true).KeyChar;
                if (reply == 'n' || reply == 'N')
                {
                    break;
                }
            }
        }
    }

    public class NumberFact
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("found")]
        public bool Found { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}