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
            listBox.ItemsSource = Program.PickingList;
        }
        bool menuIsVisible = false;
        bool listIsVisible = false;
        bool labelIsVisible = false;

        private void burgerIcon_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbHide = Resources["sbHideGrid"] as Storyboard;
            Storyboard sbShow = Resources["sbShowGrid"] as Storyboard;
            
            if (menuIsVisible)
            {
                sbHide.Begin(menuGrid);
                menuIsVisible = false;
            }   
            else
            {
                sbShow.Begin(menuGrid);
                menuIsVisible = true;
            }
        }

        private void Pick_Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbHide = Resources["sbHideLabel"] as Storyboard;
            Storyboard sbShow = Resources["sbShowLabel"] as Storyboard;

            if (Program.getLength() == 0)
            {
                Picked_Record.Content = null;
                Program.setPickingList();
                updateList();
            }
            if (Program.getLength() == 0)
            {
                    sbShow.Begin(warningLabel);
                    labelIsVisible = true;
                    return;
                
            }
            if (Program.getLength() > 0)
            {
                if (labelIsVisible)
                {
                    sbHide.Begin(warningLabel);
                    labelIsVisible = false;
                }
            }
            int index = (new Random().Next()) % (Program.getLength());
            Picked_Record.Content = Program.getPick(index);
            updateList();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (Manual_Input.Text != null)
            {
                Program.AddPick(Manual_Input.Text);
                Manual_Input.Text = "Quick Add";
                updateList();
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
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
            updateList();
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
           
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
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

        private void updateList()
        {
            listBox.SetBinding(ListBox.ItemsSourceProperty, new Binding());
            listBox.ItemsSource = Program.PickingList;
        }

        private void View_Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbHide = Resources["sbHideList"] as Storyboard;
            Storyboard sbShow = Resources["sbShowList"] as Storyboard;

            if (listIsVisible)
            {
                sbHide.Begin(listGrid);
                listIsVisible = false;
            }
            else
            {
                sbShow.Begin(listGrid);
                listIsVisible = true;
            }

        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listBox_KeyUp(object sender, KeyEventArgs e)
        {
            String item = listBox.SelectedItem.ToString();
            if (e.Key == Key.Delete)
            {
                Program.deletePick(item);
                updateList();
            }
        }
    }
}
