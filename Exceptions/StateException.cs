using System;

namespace QuitQ_Ecom.Repository.Exceptions
{
    // Exception for when the state DTO is null
    public class NullStateDtoException : Exception
    {
        public NullStateDtoException() : base("StateDTO cannot be null.") { }
    }

    // Exception for when the state with the specified ID is not found
    public class StateNotFoundException : Exception
    {
        public StateNotFoundException(int stateId) : base($"State with ID {stateId} not found.") { }
    }

    // Exception for when an error occurs while adding a state
    public class AddStateException : Exception
    {
        public AddStateException(Exception innerException) : base("Error occurred while adding state.", innerException) { }
    }

    // Exception for when an error occurs while deleting a state
    public class DeleteStateException : Exception
    {
        public DeleteStateException(int stateId, Exception innerException) : base($"Error occurred while deleting state with ID {stateId}.", innerException) { }
    }

    // Exception for when an error occurs while retrieving all states
    public class GetAllStatesException : Exception
    {
        public GetAllStatesException(Exception innerException) : base("Error occurred while retrieving all states.", innerException) { }
    }

    // Exception for when an error occurs while retrieving cities by state ID
    public class GetCitiesByStateIdException : Exception
    {
        public GetCitiesByStateIdException(int stateId, Exception innerException) : base($"Error occurred while retrieving cities for state with ID {stateId}.", innerException) { }
    }

    // Exception for when an error occurs while retrieving a state by ID
    public class GetStateByIdException : Exception
    {
        public GetStateByIdException(int stateId, Exception innerException) : base($"Error occurred while retrieving state with ID {stateId}.", innerException) { }
    }

    // Exception for when an error occurs while updating a state
    public class UpdateStateException : Exception
    {
        public UpdateStateException(int stateId, Exception innerException) : base($"Error occurred while updating state with ID {stateId}.", innerException) { }
    }
}


