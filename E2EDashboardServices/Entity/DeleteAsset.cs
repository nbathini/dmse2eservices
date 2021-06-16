using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EDashboard.Entity
{
    public class DeleteAsset
    {
        public string BoxNbr { get; set; }

        public string LoggedInUser { get; set; }
    }
}
