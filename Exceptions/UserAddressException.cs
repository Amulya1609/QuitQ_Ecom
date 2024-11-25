using System;

namespace QuitQ_Ecom.Exceptions
{
    public class UserAddressNotFoundException : Exception
    {
        public UserAddressNotFoundException() { }

        public UserAddressNotFoundException(string message)
            : base(message) { }

        public UserAddressNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class UserAddressAddException : Exception
    {
        public UserAddressAddException() { }

        public UserAddressAddException(string message)
            : base(message) { }

        public UserAddressAddException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class UserAddressDeleteException : Exception
    {
        public UserAddressDeleteException() { }

        public UserAddressDeleteException(string message)
            : base(message) { }

        public UserAddressDeleteException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class UserAddressUpdateException : Exception
    {
        public UserAddressUpdateException() { }

        public UserAddressUpdateException(string message)
            : base(message) { }

        public UserAddressUpdateException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
