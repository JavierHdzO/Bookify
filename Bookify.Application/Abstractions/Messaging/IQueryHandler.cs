using Bookify.SharedKernel;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging;

internal interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
{
}
