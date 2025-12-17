using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eventplanner
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

        private void EventsVerwijderen(object sender, RoutedEventArgs e)
        {
            Type.Items.Clear();

            Type.ItemsSource = CreateEventTypeList();
        }

        private List<string> CreateEventTypeList()
        {
            return new List<string>()
            {
                "Festival",
                "Orkest",
                "Opera"               
               
            };
        }

        

        private void open(object sender, EventArgs e)
        {
            
            Type.ItemsSource = CreateEventTypeList();

        }

        private void voegToe(object sender, RoutedEventArgs e)
        {

            var naam = naamEvent.Text;
            var aantalText = aantalBezoekers.Text;
            var type = Type.SelectedItem;




            if (int.TryParse(aantalBezoekers.Text, out int aantal))
            {

                Textblock.Items.Add($"{type} - {naam}: {aantal}");        
            }
            else
            {
                MessageBox.Show($"Geef een geheel getal in", "Ongeldige waarde", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



        }
        private void Textblock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = Textblock.SelectedItems;
        }


        private void Afsluiten(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Verwijderen(object sender, RoutedEventArgs e)
        {
            
            if (Textblock.SelectedItems.Count > 0)
            {
                var selectedItems = Textblock.SelectedItems.Cast<string>().ToList();
                foreach (var item in selectedItems)
                {
                    Textblock.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Selecteer een event om te verwijderen.", "Geen selectie", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void allesWeg(object sender, RoutedEventArgs e)
        {

            Textblock.Items.Clear();
        }

        private void Standaard(object sender, RoutedEventArgs e)
        {
            Textblock.Items.Add($"Orkest - Jaarlijkse optreden: 100");

        }
    }
}