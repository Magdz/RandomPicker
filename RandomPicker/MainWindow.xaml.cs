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
        }

        private void Manual_Clicked(object sender, RoutedEventArgs e)
        {
            Manual manual = new Manual();
            manual.Show();
        }

        private void Load_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File | *.txt| Excel | *.xlsx";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.EndsWith(".txt"))
            {
                openFileDialog.OpenFile();
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string line = reader.ReadLine();
                while(line != null)
                {
                    Program.AddPick(line);
                    line = reader.ReadLine();
                }
            }
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
    }
}
