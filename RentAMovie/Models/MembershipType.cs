using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAMovie.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string MembershipTypeName { get; set; }
        public float Rate { get; set; }
        public int DurationInMonth { get; set; }
        public float Discount { get; set; }

    }
}