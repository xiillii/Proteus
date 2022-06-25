using Proteus.Shared.Entities.Dtos;

namespace Proteus.Shared.Contracts.Handlers
{
    /// <summary>
    /// The handler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU"></typeparam>
    public interface IProteusHandler<in T, TU>
    {
        /// <summary>
        /// Validate the request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ErrorDto? Validate(T? request);

        /// <summary>
        /// Execute the operation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        OperationResult<TU> Execute(T? request);
    }
}
