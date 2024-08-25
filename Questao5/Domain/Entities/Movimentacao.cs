namespace Questao5.Domain.Entities
{
    public class Movimentacao 
    {
        public string Id { get; set; }
        public int IdConta { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
    }
}
