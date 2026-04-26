using Model;
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
using ViewModel;

namespace Course4UWpf
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private bool ValidateFields(out string errorMessage, out Control focusControl)
        {
            errorMessage = "";
            focusControl = null;

            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string firstName = FirstNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string parentPhoneNumber = ParentPhoneNumberTextBox.Text.Trim();
            DateTime? birthDate = BirthDatePicker.SelectedDate;
            ComboBoxItem selectedGender = GenderComboBox.SelectedItem as ComboBoxItem;

            if (string.IsNullOrWhiteSpace(email))
            {
                errorMessage = "Email is required.";
                focusControl = EmailTextBox;
                return false;
            }
            //if (!email.Contains("@"))
            //{
            //    errorMessage = "Please enter a valid email address.";
            //    focusControl = EmailTextBox;
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Password is required.";
                focusControl = PasswordBox;
                return false;
            }
            //if (password.Length < 3)
            //{
            //    errorMessage = "Password must be at least 3 characters long.";
            //    focusControl = PasswordBox;
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(firstName))
            {
                errorMessage = "First name is required.";
                focusControl = FirstNameTextBox;
                return false;
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                errorMessage = "Last name is required.";
                focusControl = LastNameTextBox;
                return false;
            }
          
            if (string.IsNullOrWhiteSpace(parentPhoneNumber))
            {
                errorMessage = "Parent phone number is required.";
                focusControl = ParentPhoneNumberTextBox;
                return false;
            }
            if (!birthDate.HasValue)
            {
                errorMessage = "Birth date is required.";
                focusControl = BirthDatePicker;
                return false;
            }
            if (selectedGender == null)
            {
                errorMessage = "Please select a gender.";
                focusControl = GenderComboBox;
                return false;
            }

            return true;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessageTextBlock.Text = "";

            string errorMessage;
            Control focusControl;
            if (!ValidateFields(out errorMessage, out focusControl))
            {
                ErrorMessageTextBlock.Text = errorMessage;
                focusControl?.Focus();
                return;
            }
            else
            {
                // All fields are valid, continue with registration logic
                string email = EmailTextBox.Text.Trim();
                string password = PasswordBox.Password;
                string firstName = FirstNameTextBox.Text.Trim();
                string lastName = LastNameTextBox.Text.Trim();
                string parentPhoneNumber = ParentPhoneNumberTextBox.Text.Trim();
                DateTime birthDate = BirthDatePicker.SelectedDate.Value;
                ComboBoxItem selectedGender = GenderComboBox.SelectedItem as ComboBoxItem;
                string gender = selectedGender.Content.ToString();
                try
                {
                    // Create new student 
                    Student student = new Student
                    {
                        Email = email,
                        Password = password,
                        FirstName = firstName,
                        LastName = lastName,
                        BirthDate = birthDate,
                        Gender = gender,
                        PhoneNumber = parentPhoneNumber // Setting PhoneNumber to ensure it's not null in UserTbl
                    };

                    // Insert student into database
                    StudentDB db = new StudentDB();
                    db.Insert(student);
                    db.SaveChanges();

                    // Show success message
                    MessageBox.Show("Registration successful! You can now log in.", "Success", 
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    // Navigate back to login window
                    var loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    ErrorMessageTextBlock.Text = "Registration failed: " + ex.Message;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        // Event handler to make the borderless window draggable
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // Event handler for the custom Close button
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
