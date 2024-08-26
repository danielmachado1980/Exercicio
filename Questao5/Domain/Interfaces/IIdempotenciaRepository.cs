
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Domain.Interfaces
{
    public interface IIdempotenciaRepository
    {
        void Create(Idempotencia idempontencia);
        Idempotencia GetByRequestId(string requestId);
    }
}
