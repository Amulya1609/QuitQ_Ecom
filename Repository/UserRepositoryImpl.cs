using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Models;
using QuitQ_Ecom.Exceptions; // Import the custom exceptions namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace QuitQ_Ecom.Repository
{
    public class UserRepositoryImpl : IUser
    {
        private readonly QuitQEcomContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepositoryImpl> _logger;

        public UserRepositoryImpl(QuitQEcomContext quitQEcomContext, IMapper mapper, ILogger<UserRepositoryImpl> logger)
        {
            _context = quitQEcomContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> AddUser(UserDTO userDto)
        {
            try
            {
                if (userDto == null)
                {
                    throw new ArgumentNullException(nameof(userDto), "UserDTO cannot be null");
                }

                var userEntity = _mapper.Map<UserDTO, User>(userDto);

                await _context.Users.AddAsync(userEntity);

                await _context.SaveChangesAsync();

                return _mapper.Map<UserDTO>(userEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding user: {Message}", ex.Message);
                throw new AddUserException("Failed to add user", ex); // Throw AddUserException
            }
        }

        public async Task<UserDTO> DeleteUserById(int userId)
        {
            try
            {
                var userobj = await _context.Users.FindAsync(userId);
                if (userobj == null)
                {
                    throw new UserNotFoundException($"User with ID {userId} not found");
                }

                _context.Users.Remove(userobj);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDTO>(userobj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user with ID {UserId}: {Message}", userId, ex.Message);
                throw new DeleteUserException("Failed to delete user", ex); // Throw DeleteUserException
            }
        }

        public async Task<List<UserDTO>> GetUsersByUserType(int usertypeId)
        {
            try
            {
                var users = await _context.Users.Where(x => x.UserTypeId == usertypeId).ToListAsync();
                if (users == null || users.Count == 0)
                {
                    throw new UserNotFoundException($"User type with ID {usertypeId} not found or has no users");
                }
                return _mapper.Map<List<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving users by user type with ID {UserTypeId}: {Message}", usertypeId, ex.Message);
                throw new GetUsersByUserTypeException("Failed to retrieve users by user type", ex); // Throw GetUsersByUserTypeException
            }
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var objs = await _context.Users.ToListAsync();
                if (objs == null)
                    throw new GetAllUsersException("No users found");
                return _mapper.Map<List<UserDTO>>(objs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all users: {Message}", ex.Message);
                throw new GetAllUsersException("Failed to retrieve all users", ex); // Throw GetAllUsersException
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            try
            {
                var UserObj = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (UserObj == null)
                    throw new UserNotFoundException($"User with ID {id} not found");
                return _mapper.Map<UserDTO>(UserObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving user with ID {UserId}: {Message}", id, ex.Message);
                throw new GetUserByIdException("Failed to retrieve user by ID", ex); // Throw GetUserByIdException
            }
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDto)
        {
            try
            {
                var userEntity = await _context.Users.FindAsync(userDto.UserId);
                if (userEntity == null)
                {
                    throw new UserNotFoundException($"User with ID {userDto.UserId} not found");
                }

                _mapper.Map(userDto, userEntity);

                await _context.SaveChangesAsync();

                return _mapper.Map<UserDTO>(userEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user: {Message}", ex.Message);
                throw new UpdateUserException("Failed to update user", ex); // Throw UpdateUserException
            }
        }
        public async Task<UserDTO> UpdateUserDetails(UserDTO updatedUserDto)
        {
            try
            {
                // Retrieve the existing user from the database
                var existingUser = await _context.Users.FindAsync(updatedUserDto.UserId);
                if (existingUser == null)
                {
                    throw new UserNotFoundException($"User with ID {updatedUserDto.UserId} not found");
                }

                // Update the existing user entity with the new details
                _mapper.Map(updatedUserDto, existingUser);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return the updated user DTO
                return _mapper.Map<UserDTO>(existingUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating user details: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ResetPassword(string userEmail, string newPassword)
        {
            try
            {
                var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                if (userEntity == null)
                {
                    throw new UserNotFoundException($"User with email {userEmail} not found");
                }

                userEntity.Password = HashPassword(newPassword);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while resetting user password: {Message}", ex.Message);
                return false;
            }
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
