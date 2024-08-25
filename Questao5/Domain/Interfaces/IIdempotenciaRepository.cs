using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IIdempotenciaRepository
    {
        void Create(Idempotencia idempontency);
        Idempotencia GetByRequestId(string requestId);
    }
}
