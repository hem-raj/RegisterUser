
using Microsoft.EntityFrameworkCore;
using RegisterUserAPI.Models;

namespace RegisterUserAPI.Data{
    public class UserDetailsDA : IUserDetailsDA
    {
        private readonly MyProjContext _context;
        public UserDetailsDA(MyProjContext context){
            _context = context;
        }

        public async Task<IEnumerable<UserDetails>> GetUserDetails()
        {
            if (_context.UserDetails == null) {
                return new List<UserDetails>();
            }

            return await _context.UserDetails.ToListAsync();
        }

        public async Task<UserDetails?> GetUserDetails(int id)
        {
            var userDetails = await _context.UserDetails.FindAsync(id);

            return userDetails ?? new();
        }

        public async Task<string> PutUserDetails(int id, UserDetails userDetails)
        {
            _context.Entry(userDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(id))
                {
                    return "NotFound";
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<UserDetails> PostUserDetails(UserDetails userDetails)
        {
            UserDetails emptyUserDetails = new();
            if (userDetails == null)
            {
                return emptyUserDetails;
            }
            _context.UserDetails.Add(userDetails);
            await _context.SaveChangesAsync();

            return userDetails;
        }
        
        public async Task<string> DeleteUserDetails(int id)
        {
            var userDetails = await _context.UserDetails.FindAsync(id);
            if (userDetails == null)
            {
                return "NotFound";
            }

            _context.UserDetails.Remove(userDetails);
            await _context.SaveChangesAsync();
            return "Success";
        }

        private bool UserDetailsExists(int id)
        {
            return (_context.UserDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}