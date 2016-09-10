using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMate.Web.Models
{
    public class VisitPublication
    {
        public int Id { get; set; }
        public int PublicationId { get; set; }
        public virtual Publication Publication { get; set; }
        public int VisitId { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
