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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear any previous error messages
            ErrorMessageTextBlock.Text = "";

            // Get values from the input fields
            string userEmail = EmailTextBox.Text;
            string password = PasswordInputBox.Password; // Use .Password for PasswordBox

            // Validation
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(password))
            {
                ErrorMessageTextBlock.Text = "Email and password are required.";
                return; // Stop further execution
            }

            // Try teacher login
            TeacherDB tdb = new TeacherDB();
            Teacher teacher = tdb.Login(userEmail, password);

            if (teacher != null)
            {
                MainWindow.LoggedInUser = teacher;
                MainWindow teacherWindow = new MainWindow(teacher);
                teacherWindow.Show();

                this.Close();
                return; // Stop further execution
            }

            // Try student login
            StudentDB sdb = new StudentDB();
            Student student = sdb.Login(userEmail, password);

            if (student != null)
            {
                MainWindow.LoggedInUser = student;
                MainWindow studentWindow = new MainWindow(student);
                studentWindow.Show();
                this.Close();
                return;
            }
            // Try admin login
            AdminDB adb = new AdminDB();
            Admin admin = adb.Login(userEmail, password);

            if (admin != null)
            {
                //AdminWindow adminWindow = new AdminWindow();
                MainWindow.LoggedInUser = admin;
                MainWindow adminWindow = new MainWindow(admin);
                adminWindow.Show();
                this.Close();
                return;
            }

            // If neither teacher nor student logged in
            ErrorMessageTextBlock.Text = "Invalid email or password. Try Liel/123";
        }


        // Event handler to make the borderless window draggable
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // This allows the user to drag the window by clicking anywhere on it
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // Event handler for the custom Close button
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Closes the current window
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }






        //public partial class LoginWindow : Window
        //{
        //    public LoginWindow()
        //    {
        //        InitializeComponent();
        //    }

        //    private void LoginButton_Click(object sender, RoutedEventArgs e)
        //    {
        //        MessageTextBlock.Text = "";

        //        string userEmail = UsernameTextBox.Text.Trim();
        //        string password = PasswordInputBox.Password.Trim();

        //        if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(password))
        //        {
        //            ErrorMessageTextBlock.Text = "Username and password are required.";
        //            return;
        //        }

        //        // מנסים להתחבר כמורה
        //        TeacherDB teacherDB = new TeacherDB();
        //        Teacher teacher = teacherDB.Login(userEmail, password);

        //        if (teacher != null)
        //        {
        //            MainWindow mainWindow = new MainWindow(teacher); // תעביר teacher ל‑MainWindow
        //            mainWindow.Show();
        //            this.Close();
        //            return;
        //        }

        //        // אם לא מורה, מנסים להתחבר כתלמיד
        //        StudentDB studentDB = new StudentDB();
        //        Student student = studentDB.Login(userEmail, password); // צריך לממש Login גם ב‑StudentDB

        //        if (student != null)
        //        {
        //            MainWindow mainWindow = new MainWindow(student); // תעביר student ל‑MainWindow
        //            mainWindow.Show();
        //            this.Close();
        //            return;
        //        }

        //        // אם נכשל גם מורה וגם תלמיד
        //        ErrorMessageTextBlock.Text = "Invalid userEmail or password.";
        //    }

        //    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //    {
        //        if (e.ButtonState == MouseButtonState.Pressed)
        //            DragMove();
        //    }

        //    private void CloseButton_Click(object sender, RoutedEventArgs e)
        //    {
        //        this.Close();
        //    }
        //}



    }
}
