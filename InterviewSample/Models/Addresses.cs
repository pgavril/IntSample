using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewSample.Models
{
    public class Addresses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? ContactID { get; set; }

        [DisplayName("Comments")]
        public String Name { get; set; }

        [DisplayName(" Address...")]
        public String AddressLine1 { get; set; }

        [DisplayName(" Address 2")]
        public String AddressLine2 { get; set; }

        public String City { get; set; }
      
        [StringLength(40)]
        [DisplayName("State Code")]
        public String StateCode { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        [DataType(DataType.PostalCode)]
        public String Zip { get; set; }

        public virtual Contacts Contact { get; set; }


    }
}
