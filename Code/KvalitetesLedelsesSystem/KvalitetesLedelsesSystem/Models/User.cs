using KvalitetesLedelsesSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.Models
{
    public class User
    {
        private static int idCount = 0;

        
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public User(string username, string name, string company)
        {

            UserName = $"{username}{idCount++}";
            Name = name;
            Company = company;
        }

        
    }
}
