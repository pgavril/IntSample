using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter,string searchString,int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var contacts = _context.Contacts.Include(c => c.Addresses).AsNoTracking();
            //List<Contacts> cts ;

            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = _context.Contacts
                      .Where(a => a.FirstName.Contains(searchString) || a.FirstName.Contains(searchString));
            }
            //else
            //{
            //     cts = await EntityFrameworkQueryableExtensions.ToListAsync((from c in _context.Contacts
            //         select c));

            //}
        //    var contacts = cts.ToAsyncEnumerable();
            switch (sortOrder)
            {
                case "name_desc":
                    contacts = contacts.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    contacts = contacts.OrderBy(s => s.BirthDate);
                    break;
                case "date_desc":
                    contacts = contacts.OrderByDescending(s => s.BirthDate);
                    break;
                default:
                    contacts = contacts.OrderBy(s => s.LastName);
                    break;
            }

                  return View(await contacts.AsNoTracking().ToListAsync());
           
            //int pageSize = 3;
            //var z = contacts.ToEnumerable().AsQueryable();
            //return View (PaginatedList<Contacts>.Create(QueryableExtensions.AsNoTracking(z), page ?? 1, pageSize));
    }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync(_context.Contacts, m => m.ID == id);
            if (contacts == null)
            {
                return NotFound();
            }

            //var results = context.Actions.Include("User");
            return View(contacts);
        }
        public async Task<IActionResult> SearchFirstName(string q)
        {
            var search = await EntityFrameworkQueryableExtensions.ToListAsync(_context.Contacts
                    // .Include("Addresses")
                    .Where(a => a.LastName.Contains(q)));
          //  .Take(20);
            return View(search);
        }
        public async Task<IActionResult> SearchLastName(string q)
        {
            var search = await EntityFrameworkQueryableExtensions.ToListAsync(_context.Contacts
                    // .Include("Addresses")
                    .Where(a => a.FirstName.Contains(q)));
           ;
            return View(search);
        }
        public async Task<IActionResult> ShowAllAddresses(int id)
        {
            var query = await EntityFrameworkQueryableExtensions.ToListAsync((from ct in _context.Contacts
                //join ca in _context.ContactToAddress on ct.ID equals ca.ContactId
                join a in _context.Addresses on ct.ID equals a.ContactID
                where ct.ID == id
                select a));

            return View("~/Views/Addresses/Index.cshtml", query);
        }
        public async Task<IActionResult> ShowAllPart(int id)
        {
            var query = await EntityFrameworkQueryableExtensions.ToListAsync((from ct in _context.Contacts
                //join ca in _context.ContactToAddress on ct.ID equals ca.ContactId
                join a in _context.Addresses on ct.ID equals a.ContactID
                where ct.ID == id
                      && a.Name.Contains("work")
                select a));

            return PartialView("ViewAllP", query);
        }
        // GET: Contacts/Create
        public IActionResult Create()
        {
            PopulateAddressDropDownList();
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
            PopulateAddressDropDownList();
            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts.SingleAsync(m => m.ID == id);
            if (contacts == null)
            {
                return NotFound();
            }
            return View(contacts);
        }
        public async Task<IActionResult> EditPart(int id)
        {
            var query =  await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync((from ct in _context.Contacts
                //join ca in _context.ContactToAddress on ct.ID equals ca.ContactId
                join a in _context.Addresses on ct.ID equals a.ContactID
                where ct.ID == id  && a.Name.Contains("Home")
                select a));
            
            //   return View("EditPart", contacts);
            return PartialView("TestView", query);
        }
        private void PopulateAddressDropDownList(object selectaddress = null)
        {
            var q = from d in _context.Addresses
                                   orderby d.Name
                                   select d;
           // var ls = new SelectList(q.AsNoTracking(), "ID", "Name");
          //  ViewBag.AddressID = ls;//new SelectList(q.AsNoTracking(), "AddressID", "Name", selectaddress);
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
        //    var cont = await _context.Contacts.SingleAsync(c => c.ID == id);

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
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                //var query = await (from ct in _context.Contacts//join ca in _context.ContactToAddress on ct.ID equals ca.ContactId
                //                   join a in _context.Addresses on ct.ID equals a.ContactID
                //                   where ct.ID == id
                //                   select a).ToListAsync();
                //PopulateAddressDropDownList(query);
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

            var contacts = await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync(_context.Contacts, m => m.ID == id);
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
            var contacts = await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync(_context.Contacts, m => m.ID == id);
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
