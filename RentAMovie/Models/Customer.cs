using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAMovie.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        //references
        public MembershipType MembershipType { get; set; }

        //Reference a Column
        [Display(Name = "Membership Type")]
        [Required]
        public int MembershipTypeId { get; set; }

    }
}