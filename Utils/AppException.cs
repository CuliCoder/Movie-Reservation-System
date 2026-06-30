namespace Movie_Reservation_System.Utils;

public abstract class AppException(string message, int status) : Exception(message)
{
    public int StatusCode { get; } = status;
}

public class NotFoundException(string message) : AppException(message, StatusCodes.Status404NotFound);

public class InvalidOperationException(string message) : AppException(message, StatusCodes.Status409Conflict);

public class DbUpdateConcurrencyException(string message) : AppException(message, StatusCodes.Status409Conflict);

public class DbUpdateException(string message) : AppException(message, StatusCodes.Status422UnprocessableEntity);

public class OperationCanceledException(string message) : AppException(message, StatusCodes.Status499ClientClosedRequest);