using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSample.Models
{
    public class Contacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [DisplayName(" First Name ")]
        [StringLength(160)]
        public String FirstName{get; set; }

        [Required]
        [DisplayName(" Last Name ")]
        [StringLength(160)]
        public String LastName { get; set; }

        [DisplayName(" Email ")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
           ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }


        [DisplayName(" DOB ")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DisplayName(" # of rigs ")]
        public int NumberOfComputers { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }

    }
}
