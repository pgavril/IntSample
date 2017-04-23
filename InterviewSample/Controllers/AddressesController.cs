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
using Microsoft.EntityFrameworkCore.Extensions.Internal;

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

     
        public async Task<IActionResult> Index()
        {
            //var courses = _context.Contacts
            //.Include(c => c.Addresses)
            //.AsNoTracking();
            await PopulateContactsDropDownList();
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

        private async Task<int> PopulateContactsDropDownList(object selectaddress = null)
        {
            var q =  await (from d in _context.Contacts
                    orderby d.LastName
                    select d).ToListAsync();
          //   var ls = new SelectList(q, "ID", "LastName");
             ViewBag.contactsID = new SelectList(q, "ID", "LastName");
            return 0;
        }

        private async Task<int> PopulateDropDownList(object selectaddress = null)
        {
            var q = await (from d in _context.Contacts
                           orderby d.LastName
                           select d).ToListAsync();
            //   var ls = new SelectList(q, "ID", "LastName");
            ViewBag.contactsID = new SelectList(q, "LastName", "LastName");
            return 0;
        }

        // GET: Addresses/Create
        public async Task<IActionResult> Create()
        {
            await PopulateContactsDropDownList();
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ContactID,Name,AddressLine1,AddressLine2,City,StateCode,Zip")] Addresses addresses)
        {
            await PopulateContactsDropDownList();
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
            await PopulateContactsDropDownList();
            return View(addresses);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ContactID,Name,AddressLine1,AddressLine2,City,StateCode,Zip")] Addresses addresses)
        {
            if (id != addresses.ID)
            {
                return NotFound();
            }
            await PopulateContactsDropDownList();
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
