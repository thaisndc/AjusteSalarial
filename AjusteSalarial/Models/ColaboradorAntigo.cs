using AjusteSalarial.Models;
using System;

namespace AjusteSalarial.Models
{
    public class ColaboradorAntigo : Colaborador
    {
        public ColaboradorAntigo(string nome, string função, double salárior, int anoadm) : base(nome, função, salárior, anoadm)
        {

        }

        public void AjusteSalario(double porcent)
        {
            Salárior = (Salárior * (porcent / 100)) + Salárior;
        }

    }
}