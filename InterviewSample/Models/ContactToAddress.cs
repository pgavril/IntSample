using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSample.Models
{
    public class ContactToAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
 
        public Contacts Contact { get; set; }
        public Addresses Addresses { get; set; }

    }
}
