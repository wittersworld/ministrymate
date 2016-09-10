using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMate.Web.Models
{
    public enum VisitType
    {
        InitialVisit,
        ReturnVisit,
        BibleStudy,
        NotAtHome
    }

    public class Visit
    {
        public int Id { get; set; }
        public int CallId { get; set; }
        public VisitType VisitType { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
        public IEnumerable<VisitPublication> PlacedPublications { get; set; }
    }
}
