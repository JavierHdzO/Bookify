namespace Bookify.SharedKernel;

public record Error(string Code, string Message)
{
    public static Error NullValue => new("NullValue", "Value cannot be null");
    public static Error None => new(string.Empty, string.Empty);

}
