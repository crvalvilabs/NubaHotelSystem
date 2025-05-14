using NubaHotel.BookingSystem.Application.Mappers;
using NubaHotel.BookingSystem.Domain.Repositories;

namespace NubaHotel.BookingSystem.Application.CQRS.Booking.Command.CreateBooking
{
    /// <summary>
    /// Handles the creation of bookings by processing a <see cref="CreateBookingCommand"/>.
    /// </summary>
    /// <remarks>
    /// This class is responsible for coordinating the process of creating new bookings in the system.
    /// It uses an <see cref="IBookingRepository"/> for data persistence and a <see cref="BookingMapper"/>
    /// to map the command data to a booking entity.
    /// </remarks>
    public class CreateBookingHandler : ICreateBookingHandler
    {
        /// <summary>
        /// Represents the repository for managing booking data within the system.
        /// </summary>
        /// <remarks>
        /// This field is an instance of <see cref="IBookingRepository"/> and is used to interact with
        /// the data storage layer for performing operations related to bookings, such as adding or retrieving bookings.
        /// </remarks>
        private readonly IBookingRepository _bookingRepository;

        /// <summary>
        /// Provides an instance of <see cref="BookingMapper"/> used for mapping data between booking-related domain entities
        /// and data transfer objects.
        /// </summary>
        /// <remarks>
        /// This field is used during the booking creation process to convert data from the command model to the
        /// appropriate booking domain entity, ensuring consistent and correct mappings within the application.
        /// </remarks>
        private readonly BookingMapper _bookingMapper;

        /// <summary>
        /// Handles the process of creating a booking based on a provided <see cref="CreateBookingCommand"/>.
        /// </summary>
        /// <remarks>
        /// The <see cref="CreateBookingHandler"/> is responsible for managing the creation of bookings
        /// by mapping the data from the command to a domain entity and persisting it using the repository.
        /// </remarks>
        public CreateBookingHandler(IBookingRepository bookingRepository, BookingMapper bookingMapper)
        {
            _bookingRepository = bookingRepository;
            _bookingMapper = bookingMapper;
        }

        /// <summary>
        /// Handles the execution of the provided <see cref="CreateBookingCommand"/> to create a new booking in the system.
        /// </summary>
        /// <param name="command">The booking command containing the data required to create a new booking.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation of processing the booking command.</returns>
        public async Task Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = _bookingMapper.MapToBooking(command);
            await _bookingRepository.AddBookingAsync(booking, cancellationToken);
        }
    }
}