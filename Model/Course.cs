using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Course:BaseEntity
    {
        
        private CourseType courseTypeValue;
        private Teacher teacher;
        private string  dayInWeek;
        private int price;
        private DateTime startHour;
        private DateTime endHour;
        private DateTime startDate;
        private DateTime endDate;
        private int roomNumber;
        private bool isSignedIn;

        public Teacher Teacher { get; set; }
        public string  DayInWeek { get; set; }
        public int Price { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomNumber { get; set; }
        public bool IsSignedIn { get; set; }
        public CourseType CourseTypeValue { get; set; }
    }
}
