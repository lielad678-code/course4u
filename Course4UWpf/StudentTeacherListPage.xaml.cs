using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for StudentTeacherListPage.xaml
    /// </summary>
    public partial class StudentTeacherListPage : Page
    {
      
        private List<Student> studentsList;

        public StudentTeacherListPage(string user)
        {
            InitializeComponent();
            if(user == "student")
            {

            StudentDB sdb = new StudentDB();
            studentsList = sdb.SelectAll();
            dgStudentTeacherList.ItemsSource = studentsList;
            }
            else if(user == "teacher")
            {

            TeacherDB tdb = new TeacherDB();
            List<Teacher> teachersList = tdb.SelectAll();
            dgStudentTeacherList.ItemsSource = teachersList;
                
            }
        }

        private void dgStudentTeacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}