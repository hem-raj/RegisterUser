using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegisterUserAPI.Models;
using WebApp.Data;
using WebApp.Services;
using WebApp.Services.interfaces;

namespace WebApp.Controllers
{
    public class UserDetailsController : Controller
    {
        //private readonly MyProjContext _context;
        private readonly IUserDetailsService _service;
        // public UserDetailsController(MyProjContext context)
        public UserDetailsController(IUserDetailsService service)
        {
            //_context = context;
            _service = service;
        }

        // GET: UserDetails
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserDetails> userDetails = await _service.GetAllUserDetails();
            //return userDetails.Any() ? View(userDetails) : Problem("Users are not available.");
            return View(userDetails);
        }

        // GET: UserDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            UserDetails userDetails = await _service.GetUserDetailsById(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // GET: UserDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Password,Role")] UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                var userDetailsRes = await _service.AddUserDetails(userDetails);
                if (userDetailsRes.Id >= 1)
                    return RedirectToAction(nameof(Index));
            }
            return View(userDetails);
        }

        // GET: UserDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var userDetails = await _service.GetUserDetailsById(id);
            if (userDetails == null)
            {
                return NotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Password,Role")] UserDetails userDetails)
        {
            if (id != userDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string editResult = await _service.EditUserDetails(id, userDetails);
                    if (editResult == "Failed")
                        return View(userDetails);
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userDetails);
        }

        // GET: UserDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var userDetails = await _service.GetUserDetailsById(id);
            if (userDetails == null)
            {
                return NotFound();
            }

            return View(userDetails);
        }

        // POST: UserDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userDetails = await _service.GetUserDetailsById(id);
            if (userDetails == null)
            {
                return Problem("Entity set 'MyProjContext.UserDetails'  is null.");
            }

            if (userDetails != null)
            {
                string deleteResult = await _service.DeleteUserDetails(id);
                if (deleteResult == "Failed")
                        return View(userDetails);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
