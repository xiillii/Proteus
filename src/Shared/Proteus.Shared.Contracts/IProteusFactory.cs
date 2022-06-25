namespace Proteus.Shared.Contracts
{
    public interface IProteusFactory<in T, TU>
    {
        OperationResult<TU> Execute(T request);
        bool Validate(T request);
    }
}
