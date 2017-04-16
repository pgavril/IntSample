using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterviewSample.Data;
using InterviewSample.Models;
using Microsoft.AspNetCore.Authorization;

namespace InterviewSample.Controllers
{
    [Authorize]
    public class AddressesController : Controller
    {
        private readonly ContactsContext _context;

        public AddressesController(ContactsContext context)
        {
            _context = context;    
        }

        // GET: Addresses
        public async Task<IActionResult> Index1(IQueryable param)
        {
            if(param == null)
                 return View(await _context.Addresses.ToListAsync());
            else
            {
                return View(param);
            }
        }
        public async Task<IActionResult> Index()
        {
           
                return View(await _context.Addresses.ToListAsync());
         
        }
        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses
                .SingleOrDefaultAsync(m => m.ID == id);
            if (addresses == null)
            {
                return NotFound();
            }

            return View(addresses);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,AddressLine1,AddressLine2,City,StateCode,Zip")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addresses);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addresses);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses.SingleOrDefaultAsync(m => m.ID == id);
            if (addresses == null)
            {
                return NotFound();
            }
            return View(addresses);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,AddressLine1,AddressLine2,City,StateCode,Zip")] Addresses addresses)
        {
            if (id != addresses.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addresses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressesExists(addresses.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(addresses);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses
                .SingleOrDefaultAsync(m => m.ID == id);
            if (addresses == null)
            {
                return NotFound();
            }

            return View(addresses);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addresses = await _context.Addresses.SingleOrDefaultAsync(m => m.ID == id);
            _context.Addresses.Remove(addresses);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AddressesExists(int id)
        {
            return _context.Addresses.Any(e => e.ID == id);
        }
    }
}
