using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TeacherDB : UserDB
    {
        public override string CreateDeleteSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Insert(BaseEntity entity)
        {
            Teacher teacher = entity as Teacher;

            if (teacher != null)
            {
                this.inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                this.inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public override string CreateInsertSQL(BaseEntity entity)
        {
            Teacher teacher = entity as Teacher;

            string sqlStr = $@"INSERT INTO TeacherTbl (id, TeachingCourseID, Salary)
                      VALUES ({teacher.Id}, {teacher.TeachingCourseID}, {teacher.Salary})";

            return sqlStr;
        }
        public override void Update(BaseEntity entity)
        {
            Teacher teacher = entity as Teacher;

            if (teacher != null)
            {
                this.updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
                this.updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }

        }

        public override string CreateUpdateSQL(BaseEntity entity)
        {
            Teacher teacher = entity as Teacher;


            string sqlStr = $@"UPDATE TeacherTbl SET
                        TeachingCourseID = {teacher.TeachingCourseID}, 
                        Salary = {teacher.Salary}
                      WHERE ID = {teacher.Id}";

            return sqlStr;
        }

        protected override BaseEntity NewEntity()
        {
            return new Teacher();
        }

        protected override void CreateModel(BaseEntity entity)
        {
            Teacher teacher = entity as Teacher;

            base.CreateModel(teacher);

            teacher.TeachingCourseID = (int)this.reader["TeachingCourseID"];
            teacher.Salary = (int)this.reader["Salary"];

        }
          
        public Teacher GetTeacherById(int teacher)
        {
            this.command.CommandText = $@"SELECT 
    UserTbl.FirstName, 
    UserTbl.LastName, 
    UserTbl.Email, 
    UserTbl.Password, 
    UserTbl.BirthDate, 
    UserTbl.Gender, 
    UserTbl.PhoneNumber, 
    TeacherTbl.ID, 
    TeacherTbl.TeachingCourseID, 
    TeacherTbl.Salary
FROM UserTbl 
INNER JOIN TeacherTbl 
    ON UserTbl.ID = TeacherTbl.ID
WHERE TeacherTbl.ID = {teacher};";




            TeacherList list = new TeacherList(Select());

            if (list.Count > 0)
                return list[0];

            return null;
        }

        public TeacherList SelectAll()
        {
            this.command.CommandText = @"
    SELECT 
        UserTbl.ID,
        UserTbl.FirstName, 
        UserTbl.LastName, 
        UserTbl.Email, 
        UserTbl.Password, 
        UserTbl.BirthDate, 
        UserTbl.Gender, 
        UserTbl.PhoneNumber, 
        TeacherTbl.TeachingCourseID, 
        TeacherTbl.Salary
    FROM UserTbl 
    INNER JOIN TeacherTbl 
        ON UserTbl.ID = TeacherTbl.ID;
    ";

            return new TeacherList(base.Select());
        }


        public Teacher Login(string email, string password)
        {
            this.command.CommandText = $@"
        SELECT  UserTbl.[ID], UserTbl.[FirstName], UserTbl.[LastName], UserTbl.[Email],
                UserTbl.[Password], UserTbl.[BirthDate], UserTbl.[Gender], UserTbl.[PhoneNumber], TeacherTbl.TeachingCourseID, TeacherTbl.Salary
        FROM    TeacherTbl 
        INNER JOIN UserTbl ON TeacherTbl.[ID] = UserTbl.[ID]
        WHERE UserTbl.[Email] = '{email}' AND UserTbl.[Password] = '{password}'";
            TeacherList teachers = new TeacherList(base.Select());

            if (teachers.Count > 0)
                return teachers[0];

            return null;
        }

    }
}