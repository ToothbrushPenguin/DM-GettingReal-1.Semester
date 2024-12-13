using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Haley.Services;
using KvalitetesLedelsesSystem.Models;
namespace KvalitetesLedelsesSystem.ViewModels
{
    public class ColourRepository
    {
        private List<Colour> colours = new List<Colour>();
 
        // Checks if Colours.txt file exist, if not, then create Colours.txt file and add default images
        // If Colours.txt exists read the file and at the values
        public ColourRepository()
        {
            if (!File.Exists("Colours.txt"))
            {

                using (StreamWriter writer = new StreamWriter("Colours.txt"))
                {
                    //First add is Background Color
                    //Second add is Foreground Color
                    //Thrid add is Accent Color
                    writer.WriteLine("#3F3F3F");
                    writer.WriteLine("#FF1E1E1E");
                    writer.WriteLine("#FF373232");
                }
            }
            if (File.Exists("Colours.txt"))
            {
                string line;
                int i = 0;
                using (StreamReader reader = new StreamReader("Colours.txt"))
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        colours.Add((new Colour(line)));
                        i++;
                        line = reader.ReadLine();
                    }
                }


            }
                
        }

        public void Update(string ID,string newColor)
        { 
            if (ID == "Background")
            {
                colours[0].selectedColour = newColor;
            }
            else if (ID == "Foreground")
            {
                colours[1].selectedColour = newColor;
            }
            else if (ID == "Accent")
            {
                colours[2].selectedColour = newColor;
            }
            
            // updates log file
            using (StreamWriter writer = new StreamWriter("Colours.txt"))
            {
                writer.WriteLine(colours[0].selectedColour);
                writer.WriteLine(colours[1].selectedColour);
                writer.WriteLine(colours[2].selectedColour);
            }
        }

        public void Default() 
        {
            colours[0].selectedColour = "#3F3F3F";
            colours[1].selectedColour = "#FF1E1E1E";
            colours[2].selectedColour = "#FF373232";
            //MainViewModel.colourVMs[0].SelectedColour = "#3F3F3F";
            //MainViewModel.colourVMs[1].SelectedColour = "#FF1E1E1E";
            //MainViewModel.colourVMs[2].SelectedColour = "#FF373232";
            using (StreamWriter writer = new StreamWriter("Colours.txt"))
            {
                //First add is Background Color
                //Second add is Foreground Color
                //Thrid add is Accent Color
                writer.WriteLine("#3F3F3F");
                writer.WriteLine("#FF1E1E1E");
                writer.WriteLine("#FF373232");
            }
        }
        public List<Colour> GetAll() { return colours; }
    }
}


