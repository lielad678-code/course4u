using Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ViewModel;

namespace Course4UWpf
{
    public partial class TeacherListPage : Page
    {
        // This is your data source
        private readonly List<Teacher> teachers = new List<Teacher>
        {


        };
        public List<Teacher> Teachers { get; set; }
        public TeacherListPage()
        {
            InitializeComponent();

            // This line connects the List to the DataGrid in the UI
            TeacherGrid.ItemsSource = teachers;
            // 2. Initialize the list BEFORE calling InitializeComponent
            Teachers = new List<Teacher>();
       

            // 3. Set the DataContext to this class
            this.DataContext = this;
        }
    }
}