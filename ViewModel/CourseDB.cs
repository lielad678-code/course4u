using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CourseDB : BaseDB
    {
        public override string CreateDeleteSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override string CreateInsertSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override string CreateUpdateSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void CreateModel(BaseEntity entity)
        {
            Course course = entity as Course;

            course.Id = (int)this.reader["ID"];

            int teacher = (int)this.reader["TeacherID"];
            TeacherDB teacherDB = new TeacherDB();
            course.Teacher = teacherDB.GetTeacherById(teacher);

            course.CourseType = this.reader["CourseTypeID"].ToString();


            course.Price = (int)this.reader["Price"];
            course.DayInWeek = this.reader["DayInWeek"].ToString();
            course.StartHour = Convert.ToDateTime(this.reader["StartHour"]);
            course.EndHour = Convert.ToDateTime(this.reader["EndHour"]);
            course.StartDate = Convert.ToDateTime(this.reader["StartDate"]);
            course.EndDate = Convert.ToDateTime(this.reader["EndDate"]);
            course.RoomNumber = (int)this.reader["RoomNumber"];

        }

        public CourseList SelectAll()
        {

            this.command.CommandText = @"
SELECT 
    CourseTbl.ID,
    CourseTbl.TeacherID ,
    CourseTypeTbl.Course AS CourseTypeID,
    CourseTbl.DayInWeek,
    CourseTbl.StartHour,
    CourseTbl.EndHour,
    CourseTbl.StartDate,
    CourseTbl.EndDate,
    CourseTbl.Price,
    CourseTbl.RoomNumber
FROM CourseTbl
LEFT JOIN CourseTypeTbl
    ON CourseTbl.CourseTypeID = CourseTypeTbl.ID;
";


            return new CourseList(base.Select());
        }

        public CourseList SelectMyCourses(int StudentID)
        {

            this.command.CommandText = $@"SELECT 
            CourseTbl.ID, 
            CourseTypeTbl.Course AS CourseTypeID, 
            CourseTbl.TeacherID, 
            CourseTbl.DayInWeek, 
            CourseTbl.StartHour, 
            CourseTbl.EndHour, 
            CourseTbl.StartDate, 
            CourseTbl.EndDate, 
            CourseTbl.Price, 
            CourseTbl.RoomNumber 
        FROM (CourseTbl 
        INNER JOIN StudentCourseTbl ON CourseTbl.ID = StudentCourseTbl.CourseID)
        LEFT JOIN CourseTypeTbl ON CourseTbl.CourseTypeID = CourseTypeTbl.ID
        WHERE StudentCourseTbl.StudentID = {StudentID};

";

            //            this.command.CommandText = $@"SELECT CourseTbl.ID, CourseTbl.CourseTypeID, CourseTbl.TeacherID, CourseTbl.DayInWeek, CourseTbl.StartHour, CourseTbl.EndHour, CourseTbl.StartDate, CourseTbl.EndDate, CourseTbl.Price, CourseTbl.RoomNumber FROM StudentTbl 
            //LEFT JOIN CourseTypeTbl
            //    ON CourseTbl.CourseTypeID = CourseTypeTbl.ID
            //WHERE (((StudentTbl.ID)= {StudentID}));

            //";



            return new CourseList(base.Select());
        }
        public CourseList SelectNotMyCourses(int StudentID)
        {

            this.command.CommandText = $@"SELECT 
    CourseTbl.ID, 
    CourseTypeTbl.Course AS CourseTypeID, 
    CourseTbl.TeacherID, 
    CourseTbl.DayInWeek, 
    CourseTbl.StartHour, 
    CourseTbl.EndHour, 
    CourseTbl.StartDate, 
    CourseTbl.EndDate, 
    CourseTbl.Price, 
    CourseTbl.RoomNumber
FROM CourseTbl
LEFT JOIN CourseTypeTbl
    ON CourseTbl.CourseTypeID = CourseTypeTbl.ID
WHERE CourseTbl.ID NOT IN 
(
    SELECT CourseID 
    FROM StudentCourseTbl 
    WHERE StudentID = {StudentID}
);

";


            return new CourseList(base.Select());
        }
        public CourseList SignNewCourse(int studentID,int courseID)
        {

            this.command.CommandText = $@"INSERT INTO StudentCourseTbl (StudentID, CourseID)
VALUES ({studentID}, {courseID});

";


            return new CourseList(base.Select());
        }

        protected override BaseEntity NewEntity()
        {
            return new Course();
        }

    }
}
