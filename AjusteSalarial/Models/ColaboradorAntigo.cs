namespace AjusteSalarial.Models
{
    public class ColaboradorAntigo : Colaborador
    {
        public ColaboradorAntigo(string nome, string funcao, double salárior, int anoadm) : base(nome, funcao, salárior, anoadm)
        {

        }

        public void AjusteSalario(double porcent)// 10 = +10%
        {
            Salario = (Salario * (porcent / 100)) + Salario;
        }

    }
}