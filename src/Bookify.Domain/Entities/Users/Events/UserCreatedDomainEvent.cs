using Bookify.Domain.Entities.Abstractions;

namespace Bookify.Domain.Entities.Users.Events;

public record UserCreatedDomainEvent(Guid Id) : IDomainEvent;