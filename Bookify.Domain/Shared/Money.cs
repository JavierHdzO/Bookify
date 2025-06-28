namespace Bookify.Domain.Common;

public record Money(decimal Amount, Currency Currency) 
{

    public static Money operator +(Money left, Money rigth) 
    {
        if (left.Currency != rigth.Currency) 
        {
            throw new InvalidOperationException("Currencies have to be equal");
        }

        return new Money(left.Amount + rigth.Amount, left.Currency);
    }

    public static Money operator -(Money left, Money rigth) 
    {
        if (left.Currency != rigth.Currency) 
        {
            throw new InvalidOperationException("Currencies have to be equal");
        }
        return new Money(left.Amount - rigth.Amount, left.Currency);
    }

    public bool IsZero() => this == Zero(Currency);
    public static Money Zero() => new(0, Currency.None);
    public static Money Zero(Currency currency) => new(0, currency);
}