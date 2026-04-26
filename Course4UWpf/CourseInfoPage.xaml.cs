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

        public CourseInfoPage(Course course)
        {
            InitializeComponent();
            this.DataContext = course;
            if(MainWindow.loggedInUser is Admin)
                SignButton.Content = "Edit";
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CourseWithUserControlPage());


        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.loggedInUser is Admin)
            {
                //to add course edit.

            }


        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
