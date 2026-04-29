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
            {

                SignButton.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.loggedInUser is Student)
            {

                EditButton.Visibility = Visibility.Collapsed;
            }



        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CourseWithUserControlPage());


        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.loggedInUser is Student)
            {

                CourseDB courseDB = new CourseDB(); // Create an instance of CourseDB
                courseDB.SignNewCourse(MainWindow.loggedInUser.Id, currentCourse.Id); // Use the instance to call the method
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow.MainFrame.Navigate(new CourseWithUserControlPage());
            }

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

                DayText.IsReadOnly = false;
                EndDateText.IsReadOnly = false;
                EndHourText.IsReadOnly = false;
                PriceText.IsReadOnly = false;
                FirstNameText.IsReadOnly = false;
                LastNameText.IsReadOnly = false;
                StartHourText.IsReadOnly = false;
                StartDateText.IsReadOnly = false;

                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow.MainFrame.Navigate(new CourseInfoPage(currentCourse));
            
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            Course c = DataContext as Course;

            c.CourseType = CourseNameText.Text;
            c.DayInWeek = DayText.Text;
            c.StartHour = DateTime.Parse(StartHourText.Text);
            c.EndHour = DateTime.Parse(EndHourText.Text);
            c.StartDate = DateTime.Parse(StartDateText.Text);
            c.EndDate = DateTime.Parse(EndDateText.Text);
            c.RoomNumber = int.Parse(RoomText.Text);
            c.Price = int.Parse(PriceText.Text);
            CourseDB db = new CourseDB();
            db.CreateUpdateSQL(c); // מפעיל CreateUpdateSQL

            MessageBox.Show("Course updated successfully");
        }
    }
}

