using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.Models
{
    public class ImageTod
    {
        
        public string selectedPath;

        public ImageTod(string basePath)
        { 
         selectedPath = basePath;
        }
    }
}
