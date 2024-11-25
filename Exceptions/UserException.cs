using System;

namespace QuitQ_Ecom.Exceptions
{
    public class AddUserException : Exception
    {
        public AddUserException(string message) : base(message) { }
        public AddUserException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class DeleteUserException : Exception
    {
        public DeleteUserException(string message) : base(message) { }
        public DeleteUserException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GetUsersByUserTypeException : Exception
    {
        public GetUsersByUserTypeException(string message) : base(message) { }
        public GetUsersByUserTypeException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GetAllUsersException : Exception
    {
        public GetAllUsersException(string message) : base(message) { }
        public GetAllUsersException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GetUserByIdException : Exception
    {
        public GetUserByIdException(string message) : base(message) { }
        public GetUserByIdException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class UpdateUserException : Exception
    {
        public UpdateUserException(string message) : base(message) { }
        public UpdateUserException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
        public UserNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
