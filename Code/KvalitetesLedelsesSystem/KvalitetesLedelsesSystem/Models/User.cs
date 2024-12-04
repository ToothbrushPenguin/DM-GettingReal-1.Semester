﻿using KvalitetesLedelsesSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.Models
{
    public class User
    {
        

        
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public bool CheckInStatus { get; set; }

        public User(string username, string name, string company)
        {

            UserName = $"{username}";
            Name = name;
            Company = company;
            CheckInStatus = false;
        }

        public virtual string ToString() 
        {
            return $"{UserName};{Name};{Company}";
        }

        
    }
}
