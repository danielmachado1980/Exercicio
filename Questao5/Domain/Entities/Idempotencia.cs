namespace Questao5.Domain.Entities
{
    public class Idempotencia
    {
        public string Id { get; set; }
        public string RequestId { get; set; } 
        public string Result { get; set; }
    }
}
