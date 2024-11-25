using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Exceptions;
using QuitQ_Ecom.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuitQ_Ecom.Repository
{
    public class CityRepositoryImpl : ICity
    {
        private readonly QuitQEcomContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CityRepositoryImpl> _logger;

        public CityRepositoryImpl(QuitQEcomContext context, IMapper mapper, ILogger<CityRepositoryImpl> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CityDTO> GetCityById(int cityId)
        {
            try
            {
                var city = await _context.Cities.FindAsync(cityId);
                if (city == null)
                    throw new CityNotFoundException($"City with ID {cityId} not found.");

                return _mapper.Map<CityDTO>(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get city by ID {CityId}.", cityId);
                throw new CityNotFoundException("Failed to get city by ID.", ex);
            }
        }

        public async Task<CityDTO> UpdateCityState(int cityId, int stateId)
        {
            try
            {
                var city = await _context.Cities.FindAsync(cityId);
                if (city == null)
                {
                    _logger.LogWarning("City with ID {CityId} not found.", cityId);
                    throw new CityNotFoundException($"City with ID {cityId} not found.");
                }

                var state = await _context.States.FindAsync(stateId);
                if (state == null)
                {
                    _logger.LogWarning("State with ID {StateId} not found.", stateId);
                    throw new StateNotFoundException($"State with ID {stateId} not found.");
                }

                city.StateId = stateId;
                await _context.SaveChangesAsync();

                return _mapper.Map<CityDTO>(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update city state.");
                throw new UpdateCityStateException("Failed to update city state.", ex);
            }
        }

        public async Task<List<CityDTO>> GetAllCities()
        {
            try
            {
                var cities = await _context.Cities.ToListAsync();
                return _mapper.Map<List<CityDTO>>(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all cities.");
                throw new GetAllCitiesException("Failed to get all cities.", ex);
            }
        }

        public async Task<CityDTO> AddCity(CityDTO cityDTO)
        {
            try
            {
                var city = _mapper.Map<City>(cityDTO);
                _context.Cities.Add(city);
                await _context.SaveChangesAsync();
                return _mapper.Map<CityDTO>(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add city.");
                throw new AddCityException("Failed to add city.", ex);
            }
        }

        public async Task<bool> DeleteCity(int cityId)
        {
            try
            {
                var city = await _context.Cities.FindAsync(cityId);
                if (city == null)
                {
                    _logger.LogWarning("City with ID {CityId} not found.", cityId);
                    throw new CityNotFoundException($"City with ID {cityId} not found.");
                }

                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete city with ID {CityId}.", cityId);
                throw new DeleteCityException("Failed to delete city.", ex);
            }
        }
    }
}
