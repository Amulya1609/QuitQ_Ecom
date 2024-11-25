using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Models;
using QuitQ_Ecom.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuitQ_Ecom.Repository
{
    public class UserAddressRepositoryImpl : IUserAddress
    {
        private readonly QuitQEcomContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserAddressRepositoryImpl> _logger;

        public UserAddressRepositoryImpl(QuitQEcomContext quitQEcomContext, IMapper mapper, ILogger<UserAddressRepositoryImpl> logger)
        {
            _context = quitQEcomContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserAddressDTO> GetActiveUserAddressByUserId(int userId)
        {
            try
            {
                var userAddressobj = await _context.UserAddresses.FirstOrDefaultAsync(x => x.UserId == userId && x.StatusId == 1);
                if (userAddressobj == null)
                {
                    //throw new UserAddressNotFoundException($"Active user address not found for user ID {userId}");
                    return null;
                }
                return _mapper.Map<UserAddressDTO>(userAddressobj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving active user address for user ID {UserId}: {Message}", userId, ex.Message);
                throw new UserAddressNotFoundException("Failed to retrieve active user address", ex);
            }
        }

        public async Task<UserAddressDTO> AddUserAddress(UserAddressDTO userAddressDTO)
        {
            try
            {
                var userAddress = _mapper.Map<UserAddress>(userAddressDTO);
                _context.UserAddresses.Add(userAddress);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserAddressDTO>(userAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding user address: {Message}", ex.Message);
                throw new UserAddressAddException("Failed to add user address", ex);
            }
        }

        public async Task<bool> DeleteUserAddress(int userAddressId)
        {
            try
            {
                var userAddress = await _context.UserAddresses.FindAsync(userAddressId);
                if (userAddress == null)
                {
                    throw new UserAddressNotFoundException($"User address with ID {userAddressId} not found");
                }

                _context.UserAddresses.Remove(userAddress);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user address with ID {UserAddressId}: {Message}", userAddressId, ex.Message);
                throw new UserAddressDeleteException("Failed to delete user address", ex);
            }
        }

        public async Task<List<UserAddressDTO>> GetUserAddressesByUserId(int userId)
        {
            try
            {
                var userAddresses = await _context.UserAddresses.Where(u => u.UserId == userId).ToListAsync();
                return _mapper.Map<List<UserAddressDTO>>(userAddresses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving user addresses for user ID {UserId}: {Message}", userId, ex.Message);
                throw new UserAddressNotFoundException("Failed to retrieve user addresses", ex);
            }
        }

        public async Task<UserAddressDTO> UpdateUserAddress(int userAddressId, UserAddressDTO userAddressDTO)
        {
            
            try
            {
                var userAddress = await _context.UserAddresses.FindAsync(userAddressId);
                if (userAddress == null)
                    throw new UserAddressNotFoundException($"User address with ID {userAddressId} not found");
                userAddress.StatusId = 1;
                //userAddress = _mapper.Map(userAddressDTO, userAddress);

                var otherUserAddresses = await _context.UserAddresses
    .Where(address => address.UserId == userAddress.UserId && address.UserAddressId != userAddressId)
    .ToListAsync();

                foreach (var address in otherUserAddresses)
                {
                    address.StatusId = 2;
                }
                await _context.SaveChangesAsync();
                return _mapper.Map<UserAddressDTO>(userAddress);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user address: {Message}", ex.Message);
                throw new UserAddressUpdateException("Failed to update user address", ex);
            }
        }
    }
}
