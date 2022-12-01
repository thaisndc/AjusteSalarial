using System;

namespace AjusteSalarial.Models
{
    public interface IColaborador
    {
        string Nome { get; set; }
        string Função { get; set; }
        double Salárior { get; set; }
        int Anoadm { get; set; }
    }
}