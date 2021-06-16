using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EDashboard.Utility
{
    public class AppConfig
    {
        public static string ConnectionString
        {
            get
            {
                string conn = "Data Source=uskanme2ed01.na.imtn.com;Initial Catalog=e2edashboard;User ID=e2edashboard;Password=e2edashboard;Trusted_Connection=True;MultipleActiveResultSets=True";
                return conn;
            }
        }
    }
}
