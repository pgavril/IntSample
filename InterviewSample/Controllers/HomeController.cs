using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewSample.Data;
using InterviewSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactsContext _context;

        public HomeController(ContactsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ComputerStatistics()
        {
            var data =
                _context.Contacts.GroupBy(k => k.NumberOfComputers)
                    .Select(ko => new StatisticsViewModel {ComputersCount = ko.Key, ContactsCount = ko.Count()});

            return View(await data.AsNoTracking().ToListAsync()); ;
        }

        public async Task<ActionResult> AddressStats()
        {
            var data = from ct in _context.Contacts
                       join a in _context.Addresses on ct.ID equals a.ContactID
                       // where ct.ID == 1
                       group a by a.Name into aName
                       select new StatisticsViewModel
                       {
                           Name = aName.Key,
                           AddressCount = aName.Count()
                       };

            return View(await data.AsNoTracking().ToListAsync()); ;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
