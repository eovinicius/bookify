using System.ComponentModel.DataAnnotations;
using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Exceptions;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.ValueObjects;
using Bookify.Domain.Users;

namespace Bookify.Application.Bookings.ReserveBooking;

internal sealed class ReverseBookingCommandHandler : ICommandHandler<ReverseBookingCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingServicel;
    private readonly IDateTimeProvider _dateTimeProvider;
    public ReverseBookingCommandHandler(IUserRepository userRepository, IApartmentRepository apartmentRepository, IBookingRepository bookingRepository, IUnitOfWork unitOfWork, PricingService pricingServicel, IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _apartmentRepository = apartmentRepository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _pricingServicel = pricingServicel;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(ReverseBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.UserId, cancellationToken);

        if (user is null) return Result.Failure<Guid>(UserErrors.NotFound);

        var apartment = await _apartmentRepository.GetById(request.ApartmentId, cancellationToken);

        if (apartment is null) return Result.Failure<Guid>(ApartmentErrors.NotFound);

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if (await _bookingRepository.IsOverlapping(apartment, duration, cancellationToken))
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }

        try
        {
            var booking = Booking.Reverse(
                apartment,
                user.Id,
                duration,
                _dateTimeProvider.UtcNow,
                _pricingServicel);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return booking.Id;
        }
        catch (CoucurrencyExecption)
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }
    }
}
