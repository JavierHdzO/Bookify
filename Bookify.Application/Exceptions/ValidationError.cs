namespace Bookify.Application.Exceptions;

public sealed record ValidationError(string ErrorCode, string ErrorMessage);
