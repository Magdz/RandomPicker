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
using System.Windows.Media.Animation;
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
        bool isVisible = false;
        private void burgerIcon_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbHide = Resources["sbHideGrid"] as Storyboard;
            Storyboard sbShow = Resources["sbShowGrid"] as Storyboard;

            if (isVisible)
            {
                sbHide.Begin(menuGrid);
                isVisible = false;
            }   
            else
            {
                sbShow.Begin(menuGrid);
                isVisible = true;
            }


            //if (menuGrid.IsVisible)
            //    menuGrid.Visibility = Visibility.Collapsed;
            //else
            //    menuGrid.Visibility = Visibility.Visible;
        }

        private void Pick_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Program.getLength() == 0)
            {
                Picked_Record.Content = null;
                return;
            }
            int index = (new Random().Next()) % (Program.getLength());
            Picked_Record.Content = Program.getPick(index);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (Manual_Input.Text != null)
            {
                Program.AddPick(Manual_Input.Text);
                Manual_Input.Text = "Quick Add";
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

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void titlebar_Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            base.OnMouseLeftButtonDown(e);
            if (e.ClickCount == 2)
                AdjustWindowSize();
            this.DragMove();
        }
        private void AdjustWindowSize()
        {
            bool isMaximized;
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                isMaximized = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                isMaximized = true;
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void Manual_Input_GotFocus(object sender, RoutedEventArgs e)
        {
            Manual_Input.Text = null;
            Manual_Input.Foreground = Brushes.Black;
        }

        private void Manual_Input_LostFocus(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
