using Proteus.Shared.Entities.Dtos;

namespace Proteus.Shared.Contracts
{
    public interface IProteusFactory<in T, TU>
    {
        OperationResult<TU> Execute(T request);
        ErrorDto? Validate(T request);
    }
}
