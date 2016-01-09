using System.Windows;

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
