using MediatR;

namespace BuildingBlocks.CQRS
{
    //command yang tidak memberikan respon apapun
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {

    }

    //command yang memberikan respon apapun. ditandai dengan respon nya notnull
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
