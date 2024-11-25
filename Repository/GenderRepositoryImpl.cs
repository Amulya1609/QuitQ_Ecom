using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Models;
using QuitQ_Ecom.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuitQ_Ecom.Repository
{
    public class GenderRepositoryImpl : IGender
    {
        private readonly QuitQEcomContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GenderRepositoryImpl> _logger;

        public GenderRepositoryImpl(QuitQEcomContext quitQEcomContext, IMapper mapper, ILogger<GenderRepositoryImpl> logger)
        {
            _context = quitQEcomContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenderDTO> AddGender(GenderDTO genderDTO)
        {
            try
            {
                var gender = _mapper.Map<Gender>(genderDTO);
                await _context.Genders.AddAsync(gender);
                await _context.SaveChangesAsync();
                return _mapper.Map<GenderDTO>(gender);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding gender: {Message}", ex.Message);
                throw new AddGenderException("Failed to add gender.", ex);
            }
        }

        public async Task<bool> DeleteGender(int genderId)
        {
            try
            {
                var gender = await _context.Genders.FindAsync(genderId);
                if (gender == null)
                    return false;
                _context.Genders.Remove(gender);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting gender with ID {GenderId}: {Message}", genderId, ex.Message);
                throw new DeleteGenderException("Failed to delete gender.", ex);
            }
        }

        public async Task<List<GenderDTO>> GetAllGenders()
        {
            try
            {
                var genders = await _context.Genders.ToListAsync();
                return _mapper.Map<List<GenderDTO>>(genders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all genders: {Message}", ex.Message);
                throw new GetAllGendersException("Failed to retrieve all genders.", ex);
            }
        }

        public async Task<GenderDTO> GetGenderById(int genderId)
        {
            try
            {
                var gender = await _context.Genders.FindAsync(genderId);
                if (gender == null)
                    throw new GenderNotFoundException($"Gender with ID {genderId} not found.");
                return _mapper.Map<GenderDTO>(gender);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving gender with ID {GenderId}: {Message}", genderId, ex.Message);
                throw new GetGenderByIdException("Failed to retrieve gender by ID.", ex);
            }
        }

        public async Task<GenderDTO> UpdateGender(GenderDTO genderDTO)
        {
            try
            {
                var gender = await _context.Genders.FindAsync(genderDTO.GenderId);
                if (gender == null)
                    throw new GenderNotFoundException($"Gender with ID {genderDTO.GenderId} not found.");

                gender.GenderName = genderDTO.GenderName;
                _context.Genders.Update(gender);
                await _context.SaveChangesAsync();
                return _mapper.Map<GenderDTO>(gender);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating gender: {Message}", ex.Message);
                throw new UpdateGenderException("Failed to update gender.", ex);
            }
        }
    }
}
