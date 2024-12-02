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

        public void Update(string ID)
        {
           
            var colorPicker = new ColorPickerDialog();
            string? newColor;

            // Shows a colorpicker dialog wich returns true when a color is picked
            if (colorPicker.ShowDialog() == true)
            {
                newColor = colorPicker.SelectedColor.ToString();

                if (ID == "Background")
                {
                    MainViewModel.colourVMs[0].SelectedColour = newColor;
                }
                else if (ID == "Foreground")
                {
                    MainViewModel.colourVMs[1].SelectedColour = newColor;
                }
                else if (ID == "Accent")
                {
                    MainViewModel.colourVMs[2].SelectedColour = newColor;
                }
                
            }
            // updates log file
            using (StreamWriter writer = new StreamWriter("Colours.txt"))
            {
                writer.WriteLine(MainViewModel.colourVMs[0].SelectedColour);
                writer.WriteLine(MainViewModel.colourVMs[1].SelectedColour);
                writer.WriteLine(MainViewModel.colourVMs[2].SelectedColour);
            }
        }

        public void Default() 
        {
            MainViewModel.colourVMs[0].SelectedColour = "#3F3F3F";
            MainViewModel.colourVMs[1].SelectedColour = "#FF1E1E1E";
            MainViewModel.colourVMs[2].SelectedColour = "#FF373232";
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


