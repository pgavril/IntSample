using InterviewSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSample.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ContactsContext context)
        {
            context.Database.EnsureCreated();
          //  context.Database.Se

            // Look for any students.
            if (context.Contacts.Any())
            {
                return;   // DB has been seeded
            }

            var contact = new Contacts[]
            {
            new Contacts{FirstName="Carson",LastName="Alexander",BirthDate=DateTime.Parse("2005-09-01")},
            new Contacts{FirstName="Meredith",LastName="Alonso",BirthDate=DateTime.Parse("2002-09-01")},
            new Contacts{FirstName="Arturo",LastName="Anand",BirthDate=DateTime.Parse("2003-09-01")},
            new Contacts{FirstName="Gytis",LastName="Barzdukas",BirthDate=DateTime.Parse("2002-09-01")},
            new Contacts{FirstName="Yan",LastName="Li",BirthDate=DateTime.Parse("2002-09-01")},
            new Contacts{FirstName="Peggy",LastName="Justice",BirthDate=DateTime.Parse("2001-09-01")},
            new Contacts{FirstName="Laura",LastName="Norman",BirthDate=DateTime.Parse("2003-09-01")},
            new Contacts{FirstName="Nino",LastName="Olivetto",BirthDate=DateTime.Parse("2005-09-01")}
            //     new Contacts{ID=4022,FirstName="Carson",LastName="Alexander",BirthDate=DateTime.Parse("2005-09-01")},
            //new Contacts{ID=4032,FirstName="Meredith",LastName="Alonso",BirthDate=DateTime.Parse("2002-09-01")},
            //new Contacts{ID=4042,FirstName="Arturo",LastName="Anand",BirthDate=DateTime.Parse("2003-09-01")},
            //new Contacts{ID=402,FirstName="Gytis",LastName="Barzdukas",BirthDate=DateTime.Parse("2002-09-01")},
            //new Contacts{ID=402,FirstName="Yan",LastName="Li",BirthDate=DateTime.Parse("2002-09-01")},
            //new Contacts{ID=22,FirstName="Peggy",LastName="Justice",BirthDate=DateTime.Parse("2001-09-01")},
            //new Contacts{ID=42,FirstName="Laura",LastName="Norman",BirthDate=DateTime.Parse("2003-09-01")},
            //new Contacts{ID=2,FirstName="Nino",LastName="Olivetto",BirthDate=DateTime.Parse("2005-09-01")}
            };
            foreach( var s in contact)
            {
                context.Contacts.Add(s);
            }
            context.SaveChanges();

            var adresses = new Addresses[]
            {
                new Addresses{Name = "work", ContactID = 1, AddressLine1="Streeet1",Zip="33333"},
                new Addresses{Name = "Home", ContactID = 1,AddressLine1="Streeet1",Zip="33333"},
                new Addresses{Name = "Home", ContactID = 2,AddressLine1 ="Streeet2",Zip="33333"},
                new Addresses{Name = "Home", ContactID = 3,AddressLine1="Streeet3",Zip="33333"},
                new Addresses{Name = "work", ContactID = 3,AddressLine1="Streeet4",Zip="33333"},
                new Addresses{Name = "Home", ContactID = 4,AddressLine1="Streeet5",Zip="33333"},
                new Addresses{Name = "work", ContactID = 3,AddressLine1="Streeet6",Zip="33333"},
                new Addresses{Name = "work", ContactID = 1, AddressLine1="Streeet1",Zip="33333"},
                new Addresses{Name = "Home", ContactID = 5,AddressLine1="Streeet1",Zip="33333"},
                new Addresses{Name = "Home", ContactID = 2,AddressLine1 ="Streeet2",Zip="33333"},
                new Addresses{Name = "Home", ContactID = 6,AddressLine1="Streeet3",Zip="33333"},
                new Addresses{Name = "work", ContactID = 7,AddressLine1="Streeet4",Zip="33333"},
                //new Addresses{Name = "Home", ContactID = 8,AddressLine1="Streeet5",Zip=3},
                //new Addresses{Name = "work", ContactID = 9,AddressLine1="Streeet6",Zip=4},
                //new Addresses{Name = "Home", ContactID = 10,AddressLine1="Streeet5",Zip=3},
                //new Addresses{Name = "work", ContactID = 11,AddressLine1="Streeet6",Zip=4}
            //new Addresses{ID=1050,AddressLine1="Streeet1",Zip=33333},
            //new Addresses{ID=4022,AddressLine1="Streeet1",Zip=3},
            //new Addresses{ID=4041,AddressLine1="Streeet1",Zip=3},
            //new Addresses{ID=1045,AddressLine1="Streeet1",Zip=4},
            //new Addresses{ID=3141,AddressLine1="Streeet1",Zip=4},
            //new Addresses{ID=2021,AddressLine1="Streeet1",Zip=3},
            //new Addresses{ID=2042,AddressLine1="Streeet1",Zip=4}
            };
            foreach (var c in adresses)
            {
                context.Addresses.Add(c);
            }
            context.SaveChanges();

            //var ca = new ContactToAddress[]
            //{
            //new ContactToAddress{ContactId=1,AddressId=1},
            //new ContactToAddress{ContactId=1,AddressId=2},
            //new ContactToAddress{ContactId=1,AddressId=3},
            //new ContactToAddress{ContactId=2,AddressId=4},
            //new ContactToAddress{ContactId=2,AddressId=5},
            //new ContactToAddress{ContactId=2,AddressId=6},
            //new ContactToAddress{ContactId=3,AddressId=1},
            //new ContactToAddress{ContactId=4,AddressId=1},
            //new ContactToAddress{ContactId=4,AddressId=2},
            //new ContactToAddress{ContactId=5,AddressId=3},
            //new ContactToAddress{ContactId=6,AddressId=4},
            //new ContactToAddress{ContactId=7,AddressId=4},
            //};
            //foreach (var e in ca)
            //{
            //    context.ContactToAddress.Add(e);
            //}
            //context.SaveChanges();
        }
    }
}
