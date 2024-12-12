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

namespace H12Oef3Medewerkers
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            errorLabel.Content = "Geen error";
            updateSalaryButton.IsEnabled = false;
            salaryTextBox.IsEnabled = false;

            Output();
        }

        string[] employees = {"Kristof", "Sander", "Koen"};
        string[] employeeNumbers = {"M01", "M02", "M03"};
        decimal[] salaries = {0, 0, 0};

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (summaryListBox.SelectedIndex != -1)
            {
                updateSalaryButton.IsEnabled = true;
                salaryTextBox.IsEnabled = true;
                salaryTextBox.Text = salaries[summaryListBox.SelectedIndex].ToString();
            }
            else
            {
                updateSalaryButton.IsEnabled = false;
                salaryTextBox.IsEnabled = false;
            }
        }

        private void updateSalaryButton_Click(object sender, RoutedEventArgs e)
        {
            if (summaryListBox.SelectedIndex != -1)
            {
                string inputNewSalary = salaryTextBox.Text;
                decimal newSalary;

                bool isInputValid = decimal.TryParse(inputNewSalary, out newSalary);

                if (isInputValid == false || newSalary < 0)
                {
                    errorLabel.Content = "U moet een geldig salaris ingeven";
                    salaryTextBox.Focus();
                }
                else
                {
                    salaries[summaryListBox.SelectedIndex] = newSalary;
                    errorLabel.Content = "Geen error";
                }

                summaryListBox.Items.Clear();

                Output();
            }
        }

        private void Output()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = $"{employees[i]} - {employeeNumbers[i]} - €{salaries[i]}";
                summaryListBox.Items.Add(listBoxItem);
            }
        }
    }
}