namespace QuitQ_Ecom.Exceptions
{
    public class CityNotFoundException : Exception
    {
        public CityNotFoundException(string message) : base(message)
        {
        }

        public CityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class StateNotFoundException : Exception
    {
        public StateNotFoundException(string message) : base(message)
        {
        }

        public StateNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GetAllCitiesException : Exception
    {
        public GetAllCitiesException(string message) : base(message)
        {
        }

        public GetAllCitiesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class AddCityException : Exception
    {
        public AddCityException(string message) : base(message)
        {
        }

        public AddCityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class DeleteCityException : Exception
    {
        public DeleteCityException(string message) : base(message)
        {
        }

        public DeleteCityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class UpdateCityStateException : Exception
    {
        public UpdateCityStateException(string message) : base(message)
        {
        }

        public UpdateCityStateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
