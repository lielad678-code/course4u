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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;


namespace Course4UWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User loggedInUser;

        public static User LoggedInUser
        {
            get { return loggedInUser; }
            set { loggedInUser = value; }
        }
        //public MainWindowwindow(string )

        public MainWindow(User user)
        {

            InitializeComponent();
            UpdateButtonText();

            LoggedInUser = user;

            if (loggedInUser is Teacher)
            {
                btnTeacherList.Visibility = Visibility.Collapsed;
                btnSignNewTeacher.Visibility = Visibility.Collapsed;
                btnCourses.Visibility = Visibility.Collapsed;   
            }
            

            if (loggedInUser is Student)
            {
                btnStudentList.Visibility = Visibility.Collapsed;
                btnTeacherList.Visibility = Visibility.Collapsed;
                btnSignNewTeacher.Visibility = Visibility.Collapsed;
                btnAttendance.Visibility = Visibility.Collapsed;
            }
            
            if (loggedInUser is Admin)
            {
                btnAttendance.Visibility = Visibility.Collapsed;

            }

        }
        private void UpdateButtonText()
        {
            //if (LoggedInUser is Teacher)//atendence student list schedual and settings
            //{
            //    Course.Content = "My schedule";
            //}
            //if (LoggedInUser is Student)//my courses Sign up to a course and settings
            //{
            //    btnAttendanceSignNew.Content = "Sign up to a course";
            //}
            //if (LoggedInUser is Admin)//all courses user list sign a teacher and settings
            //{
            //    Course.Content = "All courses";
            //    btnStudentList.Content = "User List";
            //    btnAttendanceSignNew.Content = "Sign a new teacher";

            //}
        }

        private void TeacherList_Click(object sender, RoutedEventArgs e)
        {
            // הנחה שיש לך פקד Frame בשם MainFrame ב-MainWindow
            MainFrame.Navigate(new StudentTeacherListPage("teacher"));
        }


        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingsPage());

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            loggedInUser = null;

            LoginWindow LogOutWindow = new LoginWindow();
            LogOutWindow.Show();

            this.Close();
        }

        private void StudentList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudentTeacherListPage("student"));

        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SchedulePage());


        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CourseWithUserControlPage ());
        }

        private void SignNewTeacher_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SignNewTeacherPage());

        }
        private void Attendance_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
