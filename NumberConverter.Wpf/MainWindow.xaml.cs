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
using NumeralSystemOperations;

namespace NumberConverter.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeBaseNumberSelection();
        }
        
        private void InitialValues()
        {
            cmbBase.SelectedIndex = 4;
            cmbNewBase.SelectedIndex = 1;
        }

        private void InitializeBaseNumberSelection()
        {
            List<int> BaseNumberSelection = new List<int>() { 1, 2, 3, 8, 10, 16 };
            
            cmbBase.ItemsSource = BaseNumberSelection;

            cmbNewBase.ItemsSource = BaseNumberSelection;

            chkToggleCustomBase.IsChecked = false;

            ToggleCustomInput(false);
        }

        private string GetSelectedBaseStr()
        {
            string result;

            if ((bool)chkToggleCustomBase.IsChecked)
            {
                result = txtBase.Text;
            }
            else
            {
                result = cmbBase.Text;
            }

            return result;
        }

        private string GetSelectedNewBaseStr()
        {
            string result;

            if ((bool)chkToggleCustomBase.IsChecked)
            {
                result = txtNewBase.Text;
            }
            else
            {
                result = cmbNewBase.Text;
            }

            return result;
        }

        private void ToggleCustomInput(bool toggleOn = true)
        {
            txtBase.IsEnabled = toggleOn;
            cmbBase.IsEnabled = !toggleOn;

            txtNewBase.IsEnabled = toggleOn;
            cmbNewBase.IsEnabled = !toggleOn;

            if (toggleOn)
            {
                txtBase.Visibility = Visibility.Visible;
                cmbBase.Visibility = Visibility.Collapsed;

                txtNewBase.Visibility = Visibility.Visible;
                cmbNewBase.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtBase.Visibility = Visibility.Collapsed;
                cmbBase.Visibility = Visibility.Visible;

                txtNewBase.Visibility = Visibility.Collapsed;
                cmbNewBase.Visibility = Visibility.Visible;
            }
        }

        private bool InputIsValid()
        {
            string currentBaseStr = GetSelectedBaseStr();
            string targetBaseStr = GetSelectedNewBaseStr();
            int currentBaseInput;
            int targetBaseInput;

            return
                txtToConvert.Text != string.Empty
                && currentBaseStr != string.Empty
                && targetBaseStr != string.Empty
                && int.TryParse(currentBaseStr, out currentBaseInput)
                && int.TryParse(targetBaseStr, out targetBaseInput)
                && currentBaseInput > 0
                && targetBaseInput > 0;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitialValues();
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (!InputIsValid())
            {
                MessageBox.Show("Please fill out all fields with valid values");
                return;
            }

            string currentBaseStr = GetSelectedBaseStr();
            string targetBaseStr = GetSelectedNewBaseStr();

            string numberToConvert = txtToConvert.Text;
            int currentBase = int.Parse(currentBaseStr);
            int targetBase = int.Parse(targetBaseStr);

            try
            {
                txtResult.Text = Numerals.ConvertNumericSystem(numberToConvert, currentBase, targetBase);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout");
            }
        }

        private void ChkToggleCustomBase_Click(object sender, RoutedEventArgs e)
        {
            ToggleCustomInput((bool)chkToggleCustomBase.IsChecked);
        }
    }
}
