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
            Course course = entity as Course;

            string sqlStr = $@"
UPDATE CourseTbl
SET 
    TeacherID = {course.Teacher.Id},
    CourseTypeID = {course.CourseTypeValue.Id},
    DayInWeek = '{course.DayInWeek}',
    StartHour = '{course.StartHour:HH:mm:ss}',
    EndHour = '{course.EndHour:HH:mm:ss}',
    StartDate = '{course.StartDate:yyyy-MM-dd}',
    EndDate = '{course.EndDate:yyyy-MM-dd}',
    Price = {course.Price},
    RoomNumber = {course.RoomNumber}
WHERE ID = {course.Id};
";

            return sqlStr;
        }

        protected override void CreateModel(BaseEntity entity)
        {
            Course course = entity as Course;

            course.Id = (int)this.reader["ID"];

            int teacher = (int)this.reader["TeacherID"];
            TeacherDB teacherDB = new TeacherDB();
            course.Teacher = teacherDB.GetTeacherById(teacher);


            int courseTypeId= (int)this.reader["CourseTypeID"];
            CourseTypeDB courseTypeDB = new CourseTypeDB();
            course.CourseTypeValue = courseTypeDB.GetCourseTypeByID(courseTypeId);

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
SELECT * FROM CourseTbl;";


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
        public CourseList SignNewCourse(int studentID, int courseID)
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
        public void ExecuteNonQuery(string sql)
        {
            this.command.CommandText = sql;
            this.command.ExecuteNonQuery();
        }
    }
}
