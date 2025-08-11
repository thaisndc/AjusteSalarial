using System.Globalization;

namespace AjusteSalarial.Models
{
    public class Colaborador : IColaborador
    {
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public double Salario { get; set; }
        public int Anoadm { get; set; }

        public Colaborador(string nome, string funcao, double salarior, int anoadm)
        {
            Nome = nome;
            Funcao = funcao;
            Salario = salarior; // salário atual
            Anoadm = anoadm; // ano contratação
        }

        public override string ToString()
        {
            var br = new CultureInfo("pt-BR");
            return $"Nome: {Nome} - Função: {Funcao} - Ano de admissão: {Anoadm} - Salário atual: {Salario.ToString("C", br)}";
        }
    }
}