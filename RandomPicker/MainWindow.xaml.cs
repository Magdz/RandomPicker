using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace RandomPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Hide();
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
        }
    }
}
