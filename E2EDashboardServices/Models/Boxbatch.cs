using System;
using System.Collections.Generic;

#nullable disable

namespace E2EDashboardServices.Models
{
    public partial class Boxbatch
    {
        public string Batchreferenceid { get; set; }
        public string Batchname { get; set; }
        public string Sitename { get; set; }
        public DateTime? Releasetime { get; set; }
        public string Boxno { get; set; }
        public DateTime? Scandate { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Updateddate { get; set; }
        public string Batchclass { get; set; }
        public string Releasestatus { get; set; }
        public int? Imagecount { get; set; }
        public int? Doccount { get; set; }
        public string ParentBoxNbr { get; set; }
        public string Iskofax { get; set; }
    }
}
