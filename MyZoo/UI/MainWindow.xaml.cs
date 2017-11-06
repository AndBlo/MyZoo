using MyZoo.DAL;
using MyZoo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MyZoo
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

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
        {
            UserSearchModel search = new UserSearchModel()
            {
                Discrimination = ComboBoxDiscrimination.Text,
                Type = ComboBoxType.Text,
                SpeciesSearch = TextBoxSearchSpecies.Text,
            };

            var access = new DataAccessZoo();
            var animal = access.GetDetailedAnimal(search);

            animal.AllowEdit = false;
            animal.AllowNew = false;

            ListBoxResultList.ItemsSource = animal;
        }

        private void ButtonRemove_OnClick(object sender, RoutedEventArgs e)
        {
            DataAccessZoo dataAccess = new DataAccessZoo();
            var animal = (AnimalDetailed)ListBoxResultList.SelectedItem;
            try
            {
                dataAccess.RemoveAnimal(animal.AnimalId);
                var list =  ListBoxResultList.ItemsSource as BindingList<AnimalDetailed>;
                list.Remove(animal);
                ClearAnimalDetailsLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearAnimalDetailsLabels()
        {
            LabelCountry.Content = "";
            LabelEnvironment.Content = "";
            LabelFather.Content = "";
            LabelMother.Content = "";
            LabelId.Content = "";
            LabelName.Content = "";
            LabelSex.Content = "";
            LabelWeight.Content = "";
            LabelType.Content = "";
            ListBoxParentsTo.ItemsSource = null;
        }

        private void ListBoxResultList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGridResultDetails. = ((AnimalDetailed)ListBoxResultList.SelectedItem)
            if (ListBoxResultList.SelectedItem != null && ListBoxResultList.SelectedItem is AnimalDetailed)
            {
                var animal = (AnimalDetailed)ListBoxResultList.SelectedItem;

                LabelId.Content = animal.AnimalId;
                LabelName.Content = animal.Name;
                LabelSex.Content = animal.Sex;
                LabelWeight.Content = animal.WeightInKilogram;
                LabelCountry.Content = animal.CountryOfOrigin;
                LabelSpecies.Content = animal.Species;
                LabelType.Content = animal.Type;
                LabelEnvironment.Content = animal.Environment;
                LabelMother.Content = animal.Mother;
                LabelFather.Content = animal.Father;
                ListBoxParentsTo.ItemsSource = animal.ChildList;
            }

        }

        private void LabelName_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            SetTextBoxTextToLabelText(LabelName, TextBoxName);
        }

        private void LabelSex_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetTextBoxTextToLabelText(LabelSex, TextBoxSex);
        }

        private void LabelWeight_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetTextBoxTextToLabelText(LabelWeight, TextBoxWeight);
        }

        private void LabelCountry_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetTextBoxTextToLabelText(LabelCountry, TextBoxCountry);
        }

        private void LabelSpecies_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetTextBoxTextToLabelText(LabelSpecies, TextBoxSpecies);
        }

        private void LabelType_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetTextBoxTextToLabelText(LabelType, TextBoxType);
        }

        private void LabelEnvironment_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetTextBoxTextToLabelText(LabelEnvironment, TextBoxEnvironment);
        }

        private void LabelMother_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetTextBoxTextToLabelText(LabelMother, TextBoxMother);
        }

        private void LabelFather_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetTextBoxTextToLabelText(LabelFather, TextBoxFather);
        }

        private void LabelParentsTo_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxParentsTo.Visibility = Visibility.Visible;
        }

        private void LabelId_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBoxId.Visibility = Visibility.Visible;
        }

        private void TextBoxId_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelId, TextBoxId);
        }

        private void TextBoxName_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelName, TextBoxName);
        }

        private void TextBoxSex_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelSex, TextBoxSex);
        }

        private void TextBoxWeight_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelWeight, TextBoxWeight);
        }

        private void TextBoxCountry_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelCountry, TextBoxCountry);
        }

        private void TextBoxSpecies_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelSpecies, TextBoxSpecies);
        }

        private void TextBoxType_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelType, TextBoxType);
        }

        private void TextBoxEnvironment_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelEnvironment, TextBoxEnvironment);
        }

        private void TextBoxMother_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelMother, TextBoxMother);
        }

        private void TextBoxFather_OnKeyDown(object sender, KeyEventArgs e)
        {
            SetLabelTextToTextBoxText(e, LabelFather, TextBoxFather);
        }

        private void ComboBoxParentsTo_OnKeyDown(object sender, KeyEventArgs e)
        {
            //SetLabelTextToTextBoxText(e, LabelParentsTo, ComboBoxParentsTo);
        }

        private void SetLabelTextToTextBoxText(KeyEventArgs e, Label label, TextBox textBox)
        {
            if (e.Key == Key.Enter)
            {
                string text = TextBoxId.Text;
                label.Content = "hej";
                textBox.Visibility = Visibility.Hidden;
            }
        }

        private void SetTextBoxTextToLabelText(Label label, TextBox textBox)
        {
            textBox.Visibility = Visibility.Visible;
            string text = (string)label.Content;
            TextBoxId.Text = "hej";
        }

        private void ButtonEditAnimal_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
