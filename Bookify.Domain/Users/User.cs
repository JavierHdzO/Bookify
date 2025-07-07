using Bookify.Domain.Abstractions;
using Bookify.Domain.Users.Events;

namespace Bookify.Domain.Users;

public sealed class User : Entity<User>
{
    private User(
        Guid id,
        FirstName firstName,
        LastName lastName, 
        Email email)
        :base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private User()
    {
    }

    public FirstName FirstName { get; private set; } 
    public LastName LastName { get; private set; } 
    public Email Email { get; private set; }

    public static User Create(FirstName firstName, LastName lastName, Email email) 
    {
        var user = new User(Guid.CreateVersion7(), firstName, lastName, email);

        user.RaiseDomainEvent( new UserCreatedDomainEvent(UserId: user.Id ));

        return user;
    }
}
