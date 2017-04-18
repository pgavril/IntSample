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
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Required]
        [DisplayName(" First Name ")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public String FirstName{get; set; }

        [Required]
        [DisplayName(" Last Name ")]
        [StringLength(100, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public String LastName { get; set; }

        [DisplayName(" Email ")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
           ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }


        [DisplayName(" DOB ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [DisplayName(" # of rigs ")]
        public int NumberOfComputers { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public virtual ICollection<Addresses> Addresses { get; set; }

    }
}
