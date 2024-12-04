 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
                    writer.WriteLine("/Views/Societate transparent.png");
                    writer.WriteLine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Test.pdf"));
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

        public void Update(string ID)
        {
            // Commandparameters er en string hvor at, argumentet Logo tilgår MainViewModel.imageVMs[0].SelectedImage
            // Argumentet ContingencyDrawing tilgår MainViewModel.imageVMs[1].SelectedImage
            // Argumentet ContingencyPlan tilgår MainViewModel.imageVMs[2].SelectedImage
            string newpath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {


                if (ID == "Logo")
                {
                    newpath = openFileDialog.FileName;
                    //newpath.Replace(@"\", "/"); 
                    MainViewModel.imageVMs[0].SelectedImage = newpath;
                }
                else if (ID == "ContingencyDrawing")
                {
                    newpath = openFileDialog.FileName;
                    //newpath.Replace(@"\", "/"); 
                    MainViewModel.imageVMs[1].SelectedImage = newpath;
                }
                else if (ID == "ContingencyPlan")
                {
                    newpath = openFileDialog.FileName;
                    string[] check = newpath.Split('.');
                    if (check[1] != "pdf")
                    {
                        MessageBox.Show("Please only select pdf files", "Error: Wrong file type", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (check[1] == "pdf")
                    {
                        //newpath.Replace(@"\", "/"); 
                        MainViewModel.imageVMs[2].SelectedImage = newpath;
                    }
                }

                using (StreamWriter writer = new StreamWriter("Images.txt", false))
                {
                    writer.WriteLine(MainViewModel.imageVMs[0].SelectedImage);
                    writer.WriteLine(MainViewModel.imageVMs[1].SelectedImage);
                    writer.WriteLine(MainViewModel.imageVMs[2].SelectedImage);
                }


            }

        }

        public void Default()
        {

            MainViewModel.imageVMs[0].SelectedImage = "/ Views / Societate transparent.png";
            MainViewModel.imageVMs[1].SelectedImage = "/ Views / Societate transparent.png";
            MainViewModel.imageVMs[2].SelectedImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Test.pdf");

            using (StreamWriter writer = new StreamWriter("Images.txt", false))
            {
                writer.WriteLine(MainViewModel.imageVMs[0].SelectedImage);
                writer.WriteLine(MainViewModel.imageVMs[1].SelectedImage);
                writer.WriteLine(MainViewModel.imageVMs[2].SelectedImage);
            }
        }

    }

}
