﻿using KvalitetesLedelsesSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KvalitetesLedelsesSystem.Views
{
    /// <summary>
    /// Interaction logic for AdminCRUD.xaml
    /// </summary>
    public partial class AdminCRUD : Window
    {
        
        public AdminCRUD(MainViewModel mainViewModel)
        {
            InitializeComponent();

            DataContext = mainViewModel;
        
        }
        

    }
}