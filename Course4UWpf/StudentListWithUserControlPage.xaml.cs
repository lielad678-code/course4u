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
    /// Interaction logic for StudentListWithUserControlPage.xaml
    /// </summary>
    public partial class StudentListWithUserControlPage : Page
    {
        public StudentListWithUserControlPage()
        {
            InitializeComponent();
            LoadStudents();

        }
        private void LoadStudents()
        {
            StudentDB sdb = new StudentDB();
            StudentList students = sdb.SelectAll();

            foreach (Student item in students)
            {
                // יצירת מופע חדש של הפקד שיצרנו
                UserCard studentCard = new UserCard();

                // חיבור האובייקט של התלמיד ל-DataContext של הכרטיס
                studentCard.DataContext = item;

                // הוספת הכרטיס לתצוגה
                gridUsers.Children.Add(studentCard);
            }
        }

    }
}
