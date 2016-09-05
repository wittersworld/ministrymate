using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistryMate.Core.Models
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
        public IEnumerable<Publication> PlacedPublications { get; set; }
    }
}
