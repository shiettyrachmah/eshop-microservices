using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    /// <summary>
    /// loggingbehavior berasal dari mediator dan irequest akan menggabungkan operasi command dan query
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="logger"></param>
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest:notnull, IRequest<TResponse> where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle request = {Request} - Response = {Response} - Send Request = {request}", typeof(TRequest).Name, typeof(TResponse).Name, request);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();
            timer.Stop();

            var timerTaken = timer.Elapsed;
            if(timerTaken.Seconds > 3)
            {
                logger.LogInformation("[PERORMANCE] The request {Request} took {timerTaken}", typeof(TRequest).Name, timerTaken.Seconds);
            }

            logger.LogInformation("[END] Handle {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);

            return response;
        }
    }
}
