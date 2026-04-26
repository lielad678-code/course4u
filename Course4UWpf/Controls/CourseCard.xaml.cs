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
namespace Course4UWpf.Controls
{
    /// <summary>
    /// Interaction logic for CourseCard.xaml
    /// </summary>
    public partial class CourseCard : UserControl
    {
        public CourseCard()
        {
            InitializeComponent();
          
        }
        private void btnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            var course = this.DataContext as Course;
            if (course == null)
                return;

            var nav = NavigationService.GetNavigationService(this);
            if (nav != null)
            {
                nav.Navigate(new CourseInfoPage( course));
                return;
            }

        }
    }
}
