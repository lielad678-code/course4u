using Course4UWpf.Controls;
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
    /// Interaction logic for CourseWithUserControlPage.xaml
    /// </summary>
    /// 

    public partial class CourseWithUserControlPage : Page
    {
        public CourseWithUserControlPage()
        {
            InitializeComponent();
            if (MainWindow.loggedInUser is Admin)
            {
                txtMyCourses.Text = "All Courses";
                txtFindNewCourses.Visibility = Visibility.Collapsed;
                gridNewCourses.Visibility = Visibility.Collapsed;
            }
            LoadCourse();
        }

        private void LoadCourse()
        {
            if (MainWindow.loggedInUser is Admin)
            {
                CourseDB cdb = new CourseDB();
                CourseList courses = cdb.SelectAll();

                foreach (Course item in courses)
                {
                    // יצירת מופע חדש של הפקד שיצרנו
                    CourseCard courseCard = new CourseCard();

                    // חיבור האובייקט של התלמיד ל-DataContext של הכרטיס
                    courseCard.DataContext = item;


                    // הוספת הכרטיס לתצוגה
                    gridMyCourses.Children.Add(courseCard);
                }

            }
            if (MainWindow.loggedInUser is Student)
            {
                CourseDB cdb = new CourseDB();
                CourseList courses = cdb.SelectMyCourses(MainWindow.loggedInUser.Id);

                foreach (Course item in courses)
                {
                    // יצירת מופע חדש של הפקד שיצרנו
                    CourseCard courseCard = new CourseCard();

                    // חיבור האובייקט של התלמיד ל-DataContext של הכרטיס
                    courseCard.DataContext = item;
                    item.IsSignedIn = true;

                    // הוספת הכרטיס לתצוגה
                    gridMyCourses.Children.Add(courseCard);
                }

                CourseDB cdb1 = new CourseDB();
                CourseList courses1 = cdb1.SelectNotMyCourses(MainWindow.loggedInUser.Id);
                foreach (Course item in courses1)   //New course student can sign
                {
                    // יצירת מופע חדש של הפקד שיצרנו
                    CourseCard courseCard = new CourseCard();

                    // חיבור האובייקט של התלמיד ל-DataContext של הכרטיס
                    courseCard.DataContext = item;
                    item.IsSignedIn = false;

                    // הוספת הכרטיס לתצוגה
                    gridNewCourses.Children.Add(courseCard);

                }


            }
        }
    }
}
