using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SubjectsPage.xaml
    /// </summary>
    public partial class SubjectsPage : Page
    {

        public SubjectsPage()
        {
            InitializeComponent();
            SubjectsGrid.ItemsSource = Subjects;
        }
      
        public ObservableCollection<Subject> Subjects { get; } = new ObservableCollection<Subject>()
        {
                new Subject { Subjects = "מתמטיקה", Units = 5 },
                new Subject { Subjects = "אנגלית", Units = 5 },
                new Subject { Subjects = "פיזיקה", Units = 5 },
                new Subject { Subjects = "היסטוריה", Units = 2 },
                new Subject { Subjects = "ספרות", Units = 2 },
                new Subject { Subjects = "מדמח", Units = 10 }
        };
    }
}
