using Bookify.Domain.Entities.Abstractions;
using Bookify.Domain.Entities.Users.Events;
using Bookify.Domain.Entities.Users.ValueObjects;

namespace Bookify.Domain.Entities.Users;

public class User : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    private User(
        Guid id,
        FirstName firstName,
        LastName lastName,
        Email email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);

        user.Raise(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}
