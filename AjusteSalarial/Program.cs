using AjusteSalarial.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

using AjusteSalarial;

namespace AjusteSalarial
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Colaborador> colaboradors = new List<Colaborador>();

            while (true)
            {
                string option;

                Console.WriteLine("===============AJUSTE SALARIAL DE COLABORADORES===============");
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Consultar Funcionarios");
                Console.WriteLine("3 - Sair/Fechar");

                option = Console.ReadLine();

                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Nome do funcionário: ");
                        string nome = Console.ReadLine();
                        Console.Write("Função do funcionário: ");
                        string função = Console.ReadLine();
                        Console.Write("Salário do funcionário: ");
                        double salárior = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Ano de admissão do funcionário: ");
                        int anoadm = int.Parse(Console.ReadLine());


                        if (anoadm > 2019)
                        {
                            Colaborador colaborador = new Colaborador(nome, função, salárior, anoadm);
                            colaboradors.Add(colaborador);

                            Console.WriteLine("Funcionário cadastrado!!!\n");
                        }
                        else
                        {
                            ColaboradorAntigo colaborador = new ColaboradorAntigo(nome, função, salárior, anoadm);
                            colaboradors.Add(colaborador);

                            Console.WriteLine("Funcionário cadastrado!!!\n");

                            if (colaborador.Salárior > 7000)
                            {
                                
                                colaborador.AjusteSalario(10);
                                Console.WriteLine("Salário atual de " + colaborador.Nome + ": R$" + colaborador.Salárior.ToString("F2", CultureInfo.InvariantCulture) + "\n");
                            }
                            else
                            {
                                
                                Console.Write("Digite a porcentagem para ajuste salarial: ");
                                double porcent = Convert.ToDouble(Console.ReadLine());
                                colaborador.AjusteSalario(porcent);
                                Console.WriteLine("Salário com Ajuste será de " + colaborador.Nome + ": R$" + colaborador.Salárior.ToString("F2", CultureInfo.InvariantCulture) + "\n");
                                Console.WriteLine();
                            }
                        }

                        break;

                    case "2":
                        Console.WriteLine("Lista de Funcionários");
                        colaboradors.ForEach(colaborador =>
                        {
                            Console.WriteLine(colaborador.ToString());
                        });
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Erro. Tente novamente!!!\n");
                        break;
                }
            }
        }
    }
}