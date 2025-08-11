namespace AjusteSalarial.Models
{
    public interface IColaborador
    {
        string Nome { get; set; }
        string Funcao { get; set; }
        double Salario { get; set; }
        int Anoadm { get; set; }
    }
}