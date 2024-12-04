using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.Models
{
    class Contingency_Responsible : User
    {
        public string Password { get; set; }

        public Contingency_Responsible(string username, string name, string company, bool checkInStatus, string password)
            : base(username, name, company, checkInStatus)
        {
            Password = password;
        }

        public override string ToString()
        {
            return $"{UserName};{Name};{Company};{Password}";
        }
    }
}
