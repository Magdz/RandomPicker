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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
