using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Models;
using Microsoft.Extensions.Logging;
using QuitQ_Ecom.Repository.Exceptions; // Add this namespace for custom exceptions
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuitQ_Ecom.Repository
{
    public class StateRepositoryImpl : IState
    {
        private readonly QuitQEcomContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<StateRepositoryImpl> _logger;

        public StateRepositoryImpl(QuitQEcomContext context, IMapper mapper, ILogger<StateRepositoryImpl> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StateDTO> AddState(StateDTO stateDTO)
        {
            try
            {
                if (stateDTO == null)
                {
                    throw new NullStateDtoException(); // Throw custom exception if StateDTO is null
                }

                var state = _mapper.Map<State>(stateDTO);
                _context.States.Add(state);
                await _context.SaveChangesAsync();
                return _mapper.Map<StateDTO>(state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while adding state: {ex.Message}");
                throw new AddStateException(ex); // Throw custom exception
            }
        }

        public async Task<bool> DeleteState(int stateId)
        {
            try
            {
                var state = await _context.States.FindAsync(stateId);
                if (state == null)
                    return false;

                _context.States.Remove(state);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting state with ID {stateId}: {ex.Message}");
                throw new DeleteStateException(stateId, ex); // Throw custom exception
            }
        }

        public async Task<List<StateDTO>> GetAllStates()
        {
            try
            {
                var states = await _context.States.ToListAsync();
                return _mapper.Map<List<StateDTO>>(states);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving all states: {ex.Message}");
                throw new GetAllStatesException(ex); // Throw custom exception
            }
        }

        public async Task<List<CityDTO>> GetCitiesByStateId(int stateId)
        {
            try
            {
                var cities = await _context.Cities.Where(x => x.StateId == stateId).ToListAsync();
                return _mapper.Map<List<CityDTO>>(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving cities with State ID {stateId}: {ex.Message}");
                throw new GetCitiesByStateIdException(stateId, ex); // Throw custom exception
            }
        }

        public async Task<StateDTO> GetStateById(int stateId)
        {
            try
            {
                var state = await _context.States.FindAsync(stateId);
                if (state == null)
                {
                    throw new StateNotFoundException(stateId); // Throw custom exception if state is not found
                }
                return _mapper.Map<StateDTO>(state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving state with ID {stateId}: {ex.Message}");
                throw new GetStateByIdException(stateId, ex); // Throw custom exception
            }
        }

        public async Task<StateDTO> UpdateState(int stateId, StateDTO stateDTO)
        {
            try
            {
                var state = await _context.States.FindAsync(stateId);
                if (state == null)
                {
                    throw new StateNotFoundException(stateId); // Throw custom exception if state is not found
                }

                _mapper.Map(stateDTO, state);
                await _context.SaveChangesAsync();
                return _mapper.Map<StateDTO>(state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating state with ID {stateId}: {ex.Message}");
                throw new UpdateStateException(stateId, ex); // Throw custom exception
            }
        }
    }
}
