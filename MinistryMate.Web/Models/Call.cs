using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMate.Web.Models
{
    public class Call
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
    }
}
