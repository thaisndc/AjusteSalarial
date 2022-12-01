using AjusteSalarial.Models;
using System;
using System.Globalization;

namespace AjusteSalarial.Models
{
    public class Colaborador : IColaborador
    {
        public string Nome { get; set; }
        public string Função { get; set; }
        public double Salárior { get; set; }
        public int Anoadm { get; set; }

        public Colaborador(string nome, string função, double salárior, int anoadm)
        {
            Nome = nome;
            Função = função;
            Salárior = salárior; // salário atual
            Anoadm = anoadm; // ano contratação
        }

        public override string ToString()
        {
            return "Nome: " + Nome + " - Função: " + Função + " - Ano de admissão: " + Anoadm + " - Salário atual: R$ " + Salárior.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}