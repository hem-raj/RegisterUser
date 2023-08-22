using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterUserAPI.Data;
using RegisterUserAPI.Models;

namespace RegisterUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsDA _userDetailsDA;

        public UserDetailsController(IUserDetailsDA userDetailsDA)
        {
            _userDetailsDA = userDetailsDA;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserDetails()
        {
            var userDetailsList = await _userDetailsDA.GetUserDetails();
            if (userDetailsList == null)
            {
                return NotFound();
            }
            return userDetailsList.ToList();
        }

        // GET: api/UserDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetails>> GetUserDetails(int id)
        {
            var userDetails = await _userDetailsDA.GetUserDetails(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return userDetails;
        }

        // PUT: api/UserDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetails(int id, UserDetails userDetails)
        {
            if (id != userDetails.Id)
            {
                return BadRequest();
            }

            string editUserDetailsResult = await _userDetailsDA.PutUserDetails(id, userDetails);
            if (editUserDetailsResult == "NotFound")
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/UserDetails
        [HttpPost]
        public async Task<ActionResult<UserDetails>> PostUserDetails(UserDetails userDetails)
        {
          if (userDetails == null)
          {
              return Problem("The data in received object is null.");
          }
            var userDetailsRes = await _userDetailsDA.PostUserDetails(userDetails);

            return CreatedAtAction("GetUserDetails", new { id = userDetailsRes.Id }, userDetailsRes);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetails(int id)
        {
            string deleteUserDetailsResult = await _userDetailsDA.DeleteUserDetails(id);
            
            if (deleteUserDetailsResult == "NotFound")
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
