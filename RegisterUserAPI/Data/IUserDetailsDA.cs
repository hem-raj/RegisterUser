
using RegisterUserAPI.Models;

namespace RegisterUserAPI.Data {
    public interface IUserDetailsDA {
        Task<IEnumerable<UserDetails>> GetUserDetails();

        Task<UserDetails?> GetUserDetails(int id);

        Task<string> PutUserDetails(int id, UserDetails userDetails);

        Task<UserDetails> PostUserDetails(UserDetails userDetails);

        Task<string> DeleteUserDetails(int id);
    }
}