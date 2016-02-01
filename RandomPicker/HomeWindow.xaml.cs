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
            Image img = new Image();
            InitializeComponent();
            listBox.ItemsSource = Program.PickingList;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            Storyboard MaxsbShow = Resources["MaxsbShowLabel"] as Storyboard;
            Storyboard MaxsbHide = Resources["MaxsbHideLabel"] as Storyboard;

            if (Program.getLength() == 0)
            {
                Picked_Record.Content = null;
                Program.setPickingList();
                updateList();
            }
            if (Program.getLength() == 0)
            {

                if (this.WindowState == WindowState.Maximized)
                {
                    MaxsbShow.Begin(warningLabel);
                    labelIsVisible = true;
                    return;
                }
                else
                {
                    sbShow.Begin(warningLabel);
                    labelIsVisible = true;
                    return;
                }

            }
            if (Program.getLength() > 0)
            {
                if (labelIsVisible)
                {
                    if (this.WindowState == WindowState.Maximized)
                    {
                        MaxsbHide.Begin(warningLabel);
                        labelIsVisible = false;
                    }
                    else
                    {
                        sbHide.Begin(warningLabel);
                        labelIsVisible = false;
                    }
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
            Image img = new Image();

            if (this.WindowState != WindowState.Maximized)
            {
                img.Source = new BitmapImage(new Uri(@"Assets/normalIcon.png", UriKind.Relative));
                this.WindowState = WindowState.Maximized;
                button.Content = img;
            }
            else
            {
                img.Source = new BitmapImage(new Uri(@"Assets/maximize.png", UriKind.Relative));
                this.WindowState = WindowState.Normal;
                button.Content = img;
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
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
            Storyboard MaxsbHide = Resources["MaxsbHideList"] as Storyboard;
            Storyboard MaxsbShow = Resources["MaxsbShowList"] as Storyboard;

            if (listIsVisible)
            {
                if (this.WindowState == WindowState.Maximized)
                    MaxsbHide.Begin(listGrid);
                else
                    sbHide.Begin(listGrid);
                listIsVisible = false;
            }
            else
            {
                if (this.WindowState == WindowState.Maximized)
                    MaxsbShow.Begin(listGrid);
                else
                    sbShow.Begin(listGrid);
                listIsVisible = true;
            }

        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Program.deleteList();
            updateList();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            String item = listBox.SelectedItem.ToString();
                Program.deletePick(item);
                updateList();
        }

        private void listBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            String item;
            if (e.Key == Key.Delete)
            {
                item = listBox.SelectedItem.ToString();
                Program.deletePick(item);
                updateList();
            }
        }
    }
}
