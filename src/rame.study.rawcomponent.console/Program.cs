// Copyright (c) 2025, RafaelMeloNet
// Todos os direitos reservados.
// All rights reserved.
//
// Este código é licenciado sob a licença BSD 3-Clause.
// This code is licensed under the BSD 3-Clause License.
//
// Consulte o arquivo LICENSE para obter mais informações.
// See the LICENSE file for more information.

using Microsoft.Extensions.Configuration;
using rame.study.rawcomponent.business;
using System.Diagnostics;

namespace rame.study.rawcomponent.console
{
    internal class Program
    {
        private static readonly IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        static void Main(string[] args)
        {
            bool executar = true;

            Console.Clear(); // Limpa a tela do console

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Executar por Dependencia");
            Console.WriteLine("2. Executar por WebApi");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");

            while (executar)
            {
                string escolha = Console.ReadLine() ?? string.Empty;

                switch (escolha)
                {
                    case "1":
                        ExecutarDependencia();
                        break;
                    case "2":
                        _ = ExecutarWebApi();
                        break;
                    case "3":
                        executar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }

            Console.WriteLine("Programa finalizado. Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        private static void ExecutarDependencia()
        {
            var businessFactory = new BusinessFactory(configuration);

            var businessDomain = businessFactory.BusinessDomain;

            businessDomain.DoBusinessFlow_A(DateTime.Now);
        }

        static async Task ExecutarWebApi()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:7256/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            Stopwatch stopwatch = new();
            long totalMilliseconds = 0;
            int requestCount = 0;
            DateTime startTime = DateTime.Now;

            while (true)
            {
                stopwatch.Restart();

                try
                {
                    var getResponse = await httpClient.GetAsync("api/BusinessDomain");
                    stopwatch.Stop();

                    if (getResponse.IsSuccessStatusCode)
                    {
                        var getContent = await getResponse.Content.ReadAsStringAsync();
                        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                        totalMilliseconds += elapsedMilliseconds;
                        requestCount++;

                        Console.WriteLine($"GET Result: {DateTime.Now.Second} | {elapsedMilliseconds} ms");
                    }
                    else
                    {
                        Console.WriteLine($"Erro na requisição GET: {getResponse.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na requisição GET: {ex.Message}");
                }


                // Calcula e exibe a média a cada segundo (ou a cada N requisições, ajustar conforme necessário)
                TimeSpan elapsedSinceStart = DateTime.Now - startTime;
                if (elapsedSinceStart.TotalSeconds >= 1)
                {
                    double averageRequestsPerSecond = (double)requestCount / elapsedSinceStart.TotalSeconds;
                    Console.WriteLine($"Média de requisições por segundo: {averageRequestsPerSecond:F2}");

                    // Reinicia as contagens para o próximo segundo
                    totalMilliseconds = 0;
                    requestCount = 0;
                    startTime = DateTime.Now;
                }
                // Uma pequena pausa para evitar sobrecarregar o servidor. Ajuste conforme necessário.
                await Task.Delay(10);

            }
        }
    }
}