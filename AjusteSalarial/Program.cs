using AjusteSalarial.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AjusteSalarial
{
    class Program
    {
        static void Main(string[] args)
        {
            var colaboradores = new List<Colaborador>();

            while (true)
            {
                Console.WriteLine("=============== AJUSTE SALARIAL DE COLABORADORES ===============");
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Consultar Funcionários");
                Console.WriteLine("3 - Sair/Fechar");
                Console.Write("Opção: ");

                var option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Nome do funcionário: ");
                        string nome = Console.ReadLine();

                        Console.Write("Função do funcionário: ");
                        string funcao = Console.ReadLine();

                        //aceita vírgula ou ponto e evita exception
                        Console.Write("Salário do funcionário (ex.: 3500,75 ou 3500.75): ");
                        string salarioStr = Console.ReadLine()?.Trim();
                        salarioStr = salarioStr?.Replace(',', '.');
                        if (!double.TryParse(salarioStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double salario))
                        {
                            Console.WriteLine("Salário inválido.\n");
                            break;
                        }

                        // valida ano e evita exception
                        Console.Write("Ano de admissão do funcionário (ex.: 2021): ");
                        var anoStr = Console.ReadLine();
                        if (!int.TryParse(anoStr, out int anoadm))
                        {
                            Console.WriteLine("Ano inválido.\n");
                            break;
                        }
                        if (anoadm < 1950 || anoadm > DateTime.Now.Year)
                        {
                            Console.WriteLine("Ano de admissão fora do intervalo válido.\n");
                            break;
                        }

                        if (anoadm > 2019)
                        {
                            // Colaborador "novo": sem ajuste automático
                            var colaborador = new Colaborador(nome, funcao, salario, anoadm);
                            colaboradores.Add(colaborador);

                            Console.WriteLine("Funcionário cadastrado!\n");
                        }
                        else
                        {
                            // Colaborador "antigo": pode ter ajuste
                            var colaborador = new ColaboradorAntigo(nome, funcao, salario, anoadm);
                            colaboradores.Add(colaborador);

                            Console.WriteLine("Funcionário cadastrado!\n");

                            if (colaborador.Salario > 7000)
                            {
                                colaborador.AjusteSalario(10); // +10%
                                Console.WriteLine($"Salário atual de {colaborador.Nome}: R$ {colaborador.Salario.ToString("F2", CultureInfo.InvariantCulture)}\n");
                            }
                            else
                            {
                                Console.Write("Digite a porcentagem para ajuste salarial (ex.: 7,5): ");
                                var pStr = Console.ReadLine()?.Trim();
                                pStr = pStr?.Replace(',', '.');
                                if (!double.TryParse(pStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double porcent))
                                {
                                    Console.WriteLine("Porcentagem inválida.\n");
                                    break;
                                }

                                colaborador.AjusteSalario(porcent);
                                Console.WriteLine($"Salário com ajuste de {colaborador.Nome}: R$ {colaborador.Salario.ToString("F2", CultureInfo.InvariantCulture)}\n");
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("=== Lista de Funcionários ===");
                        // feedback se não houver registros
                        if (colaboradores.Count == 0)
                        {
                            Console.WriteLine("Nenhum colaborador cadastrado.\n");
                            break;
                        }

                        colaboradores.ForEach(c => Console.WriteLine(c.ToString()));
                        Console.WriteLine();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Erro. Tente novamente!\n");
                        break;
                }
            }
        }
    }
}
