using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Models;

namespace QuitQ_Ecom.Repository
{
    public interface IUser
    {
        Task<UserDTO> AddUser(UserDTO user);
        Task<UserDTO> DeleteUserById(int userId);
        Task<List<UserDTO>> GetUsersByUserType(int usertypeId);

        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> UpdateUserDetails(UserDTO updatedUserDto);
        Task<bool> ResetPassword(string userEmail, string newPassword);


    }
}
