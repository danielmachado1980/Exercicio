namespace Questao5.Application.Queries.Responses
{
    public class SaldoContaResponse
    {
        public int Conta { get; set; }
        public string Titular { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
    }
}
