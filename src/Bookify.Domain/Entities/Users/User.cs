using Bookify.Domain.Entities.Abstractions;
using Bookify.Domain.Entities.Users.ValueObjects;

namespace Bookify.Domain.Entities.Users;

public class User : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    public User(
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
        return new User(Guid.NewGuid(), firstName, lastName, email);
    }
}
