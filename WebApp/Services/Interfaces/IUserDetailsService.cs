
using RegisterUserAPI.Models;

namespace WebApp.Services.interfaces
{
    public interface IUserDetailsService {
        Task<IEnumerable<UserDetails>> GetAllUserDetails();
        Task<UserDetails> GetUserDetailsById(int? id);
        Task<string> EditUserDetails(int id, UserDetails userDetails);
        Task<UserDetails> AddUserDetails(UserDetails userDetails);
        Task<string> DeleteUserDetails(int id);
    }
}