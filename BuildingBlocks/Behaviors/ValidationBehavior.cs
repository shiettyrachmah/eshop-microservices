using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
    /// <summary>
    /// validationbehavior berasal dari mediator dan akan ditrigger berdasarkan command saja bukan command dan query
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="validator"></param>
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validator) : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(validator.Select(x => x.ValidateAsync(context, cancellationToken)));

            var failures = validationResults.Where(x => x.Errors.Any()).SelectMany(x => x.Errors).ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return await next();
        }
    }
}
