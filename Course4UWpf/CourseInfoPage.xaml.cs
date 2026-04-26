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
    /// Interaction logic for CourseInfoPage.xaml
    /// </summary>
    public partial class CourseInfoPage : Page
    {
        public CourseInfoPage()
        {
            InitializeComponent();
        }
        private Course currentCourse;
        public CourseInfoPage(Course course)
        {
            InitializeComponent();
            this.DataContext = course;
            currentCourse = course;
            if (MainWindow.loggedInUser is Admin)
                SignButton.Content = "Edit";
            if(currentCourse.IsSignedIn)
            {
                SignButton.Visibility = Visibility.Collapsed;
            }
            else
                deleteButton.Visibility = Visibility.Collapsed;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CourseWithUserControlPage());


        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            CourseDB courseDB = new CourseDB(); // Create an instance of CourseDB
            courseDB.SignNewCourse(MainWindow.loggedInUser.Id, currentCourse.Id); // Use the instance to call the method
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new CourseWithUserControlPage());

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
