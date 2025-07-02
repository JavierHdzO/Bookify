using MediatR;
using Bookify.SharedKernel;

namespace Bookify.Application.Abstractions.Messaging;

internal interface ICommand : IRequest<Result>, IBaseCommand;

internal interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;