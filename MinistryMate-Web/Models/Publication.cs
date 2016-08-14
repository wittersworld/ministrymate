using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMate_Web.Models
{
    public enum PublicationType
    {
        Book,
        Magazine,
        Brochure,
        Tract,
        CampaignTract,
        Video,
        Link
    }

    public class Publication
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public PublicationType PublicationType { get; set; }
    }
}
