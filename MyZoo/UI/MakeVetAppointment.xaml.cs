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
using MyZoo.DAL;

namespace MyZoo.UI
{
    /// <summary>
    /// Interaction logic for MakeVetAppointment.xaml
    /// </summary>
    public partial class MakeVetAppointment : Window
    {
        public MakeVetAppointment()
        {
            InitializeComponent();
            DataAccessZoo dataAccess = new DataAccessZoo();
            var list = dataAccess.GetVeterinaryList();
            ComboBoxVeterinarians.ItemsSource = list;
        }

        private void ButtonMakeBooking_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonNameSearch_OnClick(object sender, RoutedEventArgs e)
        {
            string name = TextBoxNameSearch.Text;
            DataAccessZoo dataAccess = new DataAccessZoo();
            var list = dataAccess.GetSimpleAnimalByName(name);

            ListBoxNameResult.ItemsSource = list;
        }

        private void ListBoxNameResult_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataAccessZoo dataAccess = new DataAccessZoo();
            //var list = dataAccess.GetBookingByAnimalIdList();
        }
    }
}
