using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSample.Models
{
    public class ContactsAddresses
    {
        public IEnumerable<Contacts>  ContactA { get; set; }
        public IEnumerable<Addresses> AddressA { get; set; }
    }
}
