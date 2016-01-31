using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace RandomPicker
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void burgerIcon_Click(object sender, RoutedEventArgs e)
        {
            if (menuGrid.IsVisible)
                menuGrid.Visibility = Visibility.Collapsed;
            else
                menuGrid.Visibility = Visibility.Visible;
        }

        private void Pick_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Program.getLength() == 0)
            {
                Picked_Record.Text = null;
                return;
            }
            int index = (new Random().Next()) % (Program.getLength());
            Picked_Record.Text = Program.getPick(index);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (Manual_Input.Text != null)
            {
                Program.AddPick(Manual_Input.Text);
                Manual_Input.Text = null;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File | *.txt| Excel | *.xlsx";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.EndsWith(".txt"))
            {
                openFileDialog.OpenFile();
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string line = reader.ReadLine();
                while (line != null)
                {
                    Program.AddPick(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
