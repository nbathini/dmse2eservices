using System;
using System.Collections.Generic;

#nullable disable

namespace E2EDashboardServices.Models
{
    public partial class Location
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationType { get; set; }
        public long SeqNo { get; set; }
        public string KronosOrgId { get; set; }
        public string BaseLaborRate { get; set; }
        public string BaseLaborRateFortemp { get; set; }
        public string P4pMaxrate { get; set; }
        public decimal? BaseRate { get; set; }
        public string Region { get; set; }
        public string Clustr { get; set; }
        public string Country { get; set; }
    }
}
