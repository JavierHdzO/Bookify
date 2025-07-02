using MediatR;
using Bookify.SharedKernel;


namespace Bookify.Application.Abstractions.Messaging;

internal interface IQuery<TResponse> 
    : IRequest<Result<TResponse>>;


