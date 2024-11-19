using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.Commands
{
    public class NavigationCommand
    {
        public Action<string> Action { get; set; }

         
    }
}
