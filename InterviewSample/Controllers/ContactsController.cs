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
    public class ContactsController : Controller
    {
        private readonly ContactsContext _context;

        public ContactsController(ContactsContext context)
        {
            _context = context;    
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts
                .SingleOrDefaultAsync(m => m.ID == id);
            if (contacts == null)
            {
                return NotFound();
            }

            //var results = context.Actions.Include("User");
            return View(contacts);
        }
        public async Task<IActionResult> SearchFirstName(string q)
        {
            var search = await _context.Contacts
           // .Include("Addresses")
            .Where(a => a.LastName.Contains(q)).ToListAsync();
          //  .Take(20);
            return View(search);
        }
        public async Task<IActionResult> SearchLastName(string q)
        {
            var search = await _context.Contacts
                // .Include("Addresses")
                .Where(a => a.FirstName.Contains(q)).ToListAsync();
           ;
            return View(search);
        }
        public async Task<IActionResult> ShowAllAddresses(int id)
        {
            var query = await (from ct in _context.Contacts
                        //join ca in _context.ContactToAddress on ct.ID equals ca.ContactId
                        join a in _context.Addresses on ct.ID equals a.ContactID
                        where ct.ID == id
                        select a).ToListAsync();

            return View("~/Views/Addresses/Index.cshtml", query);
        }
        public async Task<IActionResult> ShowAllPart(int id)
        {
            var query = await (from ct in _context.Contacts
                                   //join ca in _context.ContactToAddress on ct.ID equals ca.ContactId
                               join a in _context.Addresses on ct.ID equals a.ContactID
                               where ct.ID == id
                               && a.Name.Contains("work")
                               select a).ToListAsync();

            return PartialView("ViewAllP", query);
        }
        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,EmailAddress,BirthDate,NumberOfComputers")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacts);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts.SingleOrDefaultAsync(m => m.ID == id);
            if (contacts == null)
            {
                return NotFound();
            }
            return View(contacts);
        }
        public async Task<IActionResult> EditPart(int id)
        {
          
            var query =  await (from ct in _context.Contacts
                             //join ca in _context.ContactToAddress on ct.ID equals ca.ContactId
                         join a in _context.Addresses on ct.ID equals a.ContactID
                         where ct.ID == id
                         select a).FirstOrDefaultAsync();
            
            //   return View("EditPart", contacts);
            return PartialView("TestView", query);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,EmailAddress,BirthDate,NumberOfComputers")] Contacts contacts)
        {
            if (id != contacts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactsExists(contacts.ID))
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
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts
                .SingleOrDefaultAsync(m => m.ID == id);
            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacts = await _context.Contacts.SingleOrDefaultAsync(m => m.ID == id);
            _context.Contacts.Remove(contacts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContactsExists(int id)
        {
            return _context.Contacts.Any(e => e.ID == id);
        }
    }
}
