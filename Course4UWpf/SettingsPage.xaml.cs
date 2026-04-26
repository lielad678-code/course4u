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
using Model;

namespace Course4UWpf
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {

        public SettingsPage()
        {
            InitializeComponent();
            txtFirstName.Text = MainWindow.loggedInUser.FirstName;
            txtLastName.Text = MainWindow.loggedInUser.LastName;
            txtEmail.Text = MainWindow.loggedInUser.Email;
            txtPhoneNumber.Text = MainWindow.loggedInUser.PhoneNumber;
            dtpickBirthdate.SelectedDate = MainWindow.loggedInUser.BirthDate;
            txtPassword.Password = MainWindow.loggedInUser.Password;

            //Teacher teacher = (Teacher)MainWindow.LoggedInUser;
            //DataContext = teacher;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SchedulePage());
        }

        //private bool ValidateFields(out string errorMessage, out Control focusControl)
        //{
        //    errorMessage = "";
        //    focusControl = null;

        //    string username = UsernameTextBox.Text.Trim();
        //    string password = PasswordBox.Password;
        //    string email = EmailTextBox.Text.Trim();
        //    string firstName = FirstNameTextBox.Text.Trim();
        //    string lastName = LastNameTextBox.Text.Trim();
        //    DateTime? startWorkDate = StartWorkDatePicker.SelectedDate;

        //    if (string.IsNullOrWhiteSpace(username))
        //    {
        //        errorMessage = "Username is required.";
        //        focusControl = UsernameTextBox;
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(password))
        //    {
        //        errorMessage = "Password is required.";
        //        focusControl = PasswordBox;
        //        return false;
        //    }
        //    if (password.Length > 15)
        //    {
        //        errorMessage = "Password must not be longer than 15 characters.";
        //        focusControl = PasswordBox;
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(email))
        //    {
        //        errorMessage = "Email is required.";
        //        focusControl = EmailTextBox;
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(firstName))
        //    {
        //        errorMessage = "First name is required.";
        //        focusControl = FirstNameTextBox;
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(lastName))
        //    {
        //        errorMessage = "Last name is required.";
        //        focusControl = LastNameTextBox;
        //        return false;
        //    }
        //    if (!startWorkDate.HasValue)
        //    {
        //        errorMessage = "Start work date is required.";
        //        focusControl = StartWorkDatePicker;
        //        return false;
        //    }
        //    return true;
        //}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessageTextBlock.Text = "";


            // Update model with UI values

            MainWindow.loggedInUser.Password = txtPassword.Password;
            MainWindow.loggedInUser.Email = txtEmail.Text.Trim();
            MainWindow.loggedInUser.FirstName = txtFirstName.Text.Trim();
            MainWindow.loggedInUser.LastName = txtLastName.Text.Trim();
            MainWindow.loggedInUser.PhoneNumber = txtPhoneNumber.Text.Trim();
            MainWindow.loggedInUser.BirthDate = dtpickBirthdate.SelectedDate.Value;
            if (MainWindow.loggedInUser is Teacher)
            {
                var db = new ViewModel.TeacherDB();
                db.Update(MainWindow.loggedInUser);
                db.SaveChanges();
            }
            else if (MainWindow.loggedInUser is Student)
            {
                var db = new ViewModel.StudentDB();
                db.Update(MainWindow.loggedInUser);
                db.SaveChanges();

            }
            else if (MainWindow.loggedInUser is Admin)
            {
                var db = new ViewModel.AdminDB();
                db.Update(MainWindow.loggedInUser);
                db.SaveChanges();
            }

            MessageBox.Show("user updates saved.");

            // Navigate back to the user page
            NavigationService?.Navigate(new SettingsPage());
        }

    }
}
