using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Connection //parent class use inherentance
    {
        public string GetConnection()   // return object private
        {
            return "Server=mssqlstud.fhict.local;Database=dbi523722_craftconn;User Id=dbi523722_craftconn;Password=AmazingCraftC;";
        }
    }
}
