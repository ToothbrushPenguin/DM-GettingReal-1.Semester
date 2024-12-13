 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KvalitetesLedelsesSystem.Models;
using KvalitetesLedelsesSystem.ViewModels.Commands;
using Microsoft.Win32;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public class ImageRepository
    {
        private List<ImageTod> images = new List<ImageTod>();

        public ImageRepository()
        {
            // Checks if Images.txt file exist, if not, then create Images.txt file and add default images
            // If Images.txt exists read the file and at the values
            if (!File.Exists("Images.txt"))
            {
                using (StreamWriter writer = new StreamWriter("Images.txt"))
                {
                    //First add is LogoDrawing
                    //Second add is ContingencyDrawing
                    //Third add is ContingencyPlan
                    writer.WriteLine("/Views/Societate transparent.png");
                    writer.WriteLine("UCL_Evakueringsplan.png");
                    writer.WriteLine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Evakueringsplan UCL.pdf"));
                }
            }
            if (File.Exists("Images.txt"))
            {
                string line;
                int i = 0;

                using (StreamReader reader = new StreamReader("Images.txt"))
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        images.Add(new ImageTod(line));
                        i++;
                        line = reader.ReadLine();
                    }

                }
            }
        }

        public List<ImageTod> GetAll()
        { return images; }

        public void UpdateImage(string ID, string newPath)
        {
            // Commandparameters er en string hvor at, argumentet Logo tilgår MainViewModel.imageVMs[0].SelectedImage
            // Argumentet ContingencyDrawing tilgår MainViewModel.imageVMs[1].SelectedImage
            // Argumentet ContingencyPlan tilgår MainViewModel.imageVMs[2].SelectedImage
          
            {

                if (ID == "Logo")
                { 
                    images[0].selectedPath = newPath;
                }
                else if (ID == "ContingencyDrawing")
                {
                    images[1].selectedPath = newPath;
                }
                else if (ID == "ContingencyPlan")
                {

                    images[2].selectedPath = newPath;

                }

                using (StreamWriter writer = new StreamWriter("Images.txt"))
                {
                    writer.WriteLine(images[0].selectedPath);
                    writer.WriteLine(images[1].selectedPath);
                    writer.WriteLine(images[2].selectedPath);
                }

            }

        }

        public void Default()
        {

            MainViewModel.imageVMs[0].SelectedImage = "/Views/Societate transparent.png";
            MainViewModel.imageVMs[1].SelectedImage = "UCL_Evakueringsplan.png";
            MainViewModel.imageVMs[2].SelectedImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Evakueringsplan UCL.pdf");

            using (StreamWriter writer = new StreamWriter("Images.txt"))
            {
                writer.WriteLine(MainViewModel.imageVMs[0].SelectedImage);
                writer.WriteLine(MainViewModel.imageVMs[1].SelectedImage);
                writer.WriteLine(MainViewModel.imageVMs[2].SelectedImage);
            }
        }

    }

}
