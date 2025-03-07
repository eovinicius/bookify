using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid Id) : IDomainEvent;