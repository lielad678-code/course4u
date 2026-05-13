using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            // 👇 טען מורים מהדאטהבייס
            TeacherDB teacherDB = new TeacherDB();
            List<Teacher> teachers = teacherDB.SelectAll();

            TeacherComboBox.ItemsSource = teachers;

            if (MainWindow.loggedInUser is Admin)
            {
                EditButton.Visibility = Visibility.Visible;
                SignButton.Visibility = Visibility.Collapsed;
                SaveChangesButton.Visibility = Visibility.Collapsed;
            }

            if (MainWindow.loggedInUser is Student)
            {
                SaveChangesButton.Visibility = Visibility.Collapsed;
                SignButton.Visibility = Visibility.Visible;
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
            // מעבר למצב עריכה של מורה
            TeacherDisplayPanel.Visibility = Visibility.Collapsed;
            TeacherComboBorder.Visibility = Visibility.Visible;

            // שאר השדות
            DayText.IsReadOnly = false;
            EndHourText.IsReadOnly = false;
            PriceText.IsReadOnly = false; 
            StartHourText.IsReadOnly = false;

            StartDateText.Visibility = Visibility.Collapsed;
            EndDateText.Visibility = Visibility.Collapsed;

            StartDatePickerBorder.Visibility = Visibility.Visible;
            EndDatePickerBorder.Visibility = Visibility.Visible;

            EditButton.Visibility = Visibility.Collapsed;
            SaveChangesButton.Visibility = Visibility.Visible;
        }
         
        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            Course c = DataContext as Course;

            //@TODO - liel handle course type object
            //c.CourseTypeValue = CourseNameText.Text;
            c.DayInWeek = DayText.Text;
            c.StartHour = DateTime.Parse(StartHourText.Text);
            c.EndHour = DateTime.Parse(EndHourText.Text);

            // 👇 במקום TextBox
            c.StartDate = StartDatePicker.SelectedDate ?? DateTime.Now;
            c.EndDate = EndDatePicker.SelectedDate ?? DateTime.Now;

            c.RoomNumber = int.Parse(RoomText.Text);
            c.Price = int.Parse(PriceText.Text);

            CourseDB db = new CourseDB();
            db.Update(c);
            db.SaveChanges();


            MessageBox.Show("Course updated successfully");

            // 👇 חזרה למצב תצוגה
            StartDateText.Visibility = Visibility.Visible;
            EndDateText.Visibility = Visibility.Visible;

            StartDatePickerBorder.Visibility = Visibility.Collapsed;
            EndDatePickerBorder.Visibility = Visibility.Collapsed;

            SaveChangesButton.Visibility = Visibility.Collapsed;
            EditButton.Visibility = Visibility.Visible;
        }
    }
}

