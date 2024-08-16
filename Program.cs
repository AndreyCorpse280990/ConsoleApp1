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
               
                    // Запрашиваем у пользователя ввод числа
                    Console.Write("Enter a number ");
                    string userInput = Console.ReadLine();


                    // Выполняем запрос с использованием введенного числа
                    HttpResponseMessage response = await httpClient.GetAsync($"http://numbersapi.com/{userInput}?json");

                    // спарсить ответ в объект Numberfact
                    NumberFast numberFast = JsonConvert.DeserializeObject<NumberFast>(json.Boby);

                if (numberFast.Found)
                {
                    Console.WriteLine($"Found fast about {numberFast.Number}: {numberFast.Text}");
                } else
                {
                    Console.WriteLine($"there are not facts about '{numberFast.Number}'");
                }
                // зацикливание 
                Console.WriteLine("Dou want to continue? (y/n");
                char reply = Console.ReadKey(true).KeyChar;
                if("nNtT",)
            }
        }
    }
}