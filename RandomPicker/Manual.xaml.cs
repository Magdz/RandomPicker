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

namespace RandomPicker
{
    /// <summary>
    /// Interaction logic for Manual.xaml
    /// </summary>
    public partial class Manual : Window
    {
        public Manual()
        {
            InitializeComponent();
        }

        private void Manual_Add_Clicked(object sender, RoutedEventArgs e)
        {
            if(Manual_Input.Text != null)
            {
                Program.AddPick(Manual_Input.Text);
                Manual_Input.Text = null;
            }
        }
    }
}
