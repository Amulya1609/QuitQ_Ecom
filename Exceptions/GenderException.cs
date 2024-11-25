using System;

namespace QuitQ_Ecom.Exceptions
{
    public class AddGenderException : Exception
    {
        public AddGenderException(string message) : base(message) { }
        public AddGenderException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class DeleteGenderException : Exception
    {
        public DeleteGenderException(string message) : base(message) { }
        public DeleteGenderException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GetAllGendersException : Exception
    {
        public GetAllGendersException(string message) : base(message) { }
        public GetAllGendersException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GetGenderByIdException : Exception
    {
        public GetGenderByIdException(string message) : base(message) { }
        public GetGenderByIdException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GenderNotFoundException : Exception
    {
        public GenderNotFoundException(string message) : base(message) { }
        public GenderNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class UpdateGenderException : Exception
    {
        public UpdateGenderException(string message) : base(message) { }
        public UpdateGenderException(string message, Exception innerException) : base(message, innerException) { }
    }
}
