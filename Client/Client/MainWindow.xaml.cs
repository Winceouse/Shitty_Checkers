﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Single_Player_Menu(object sender, RoutedEventArgs e)
        {
            MainMenu.Hide();
            SinglePlayer singlePlayerWindow = new SinglePlayer();
            singlePlayerWindow.Show();
        }

        private void Multi_Player_Menu(object sender, RoutedEventArgs e)
        {
            MainMenu.Close();
        }
       
    }
    
}
