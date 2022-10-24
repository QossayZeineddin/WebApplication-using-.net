using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class userController : Controller
    {
        private readonly WebApplication1Context _context;
        
        // dependency injection
        public userController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: user
        // public async Task<IActionResult> Index()
        // {
        //       return _context.users != null ? 
        //                   View(await _context.users.ToListAsync()) :
        //                   Problem("Entity set 'WebApplication1Context.users'  is null.");
        // }
        
        //https://localhost:7134/user?name=Ghos
        [HttpGet]
        public async Task<IActionResult> Index(string? name , string? email)
        {
            var user = from VAR in _context.users
                select VAR;
            if (!string.IsNullOrEmpty(name))
            {
                user = user.Where(s => s.name!.Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                user = user.Where(s => s.email!.Contains(email));

            }

            return View(await user.ToListAsync());
        }

        // GET: user/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var users = await _context.users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: user/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: user/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,password,email,gender,phone_num,dateOfBrith")] users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: user/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var users = await _context.users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: user/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("Id,name,password,email,gender,phone_num,dateOfBrith")] users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!usersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: user/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var users = await _context.users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            if (_context.users == null)
            {
                return Problem("Entity set 'WebApplication1Context.users'  is null.");
            }
            var users = await _context.users.FindAsync(id);
            if (users != null)
            {
                _context.users.Remove(users);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool usersExists(double id)
        {
          return (_context.users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
