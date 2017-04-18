using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InterviewSample.Models
{
    public class ContactsViewModel: Contacts
    {
        private Contacts contacts;

        public ContactsViewModel(Contacts contacts)
        {
            this.contacts = contacts;
        }

        public SelectList AddressList { get; set; }
    }

}
