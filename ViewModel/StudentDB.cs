using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ViewModel
{
    public class StudentDB : UserDB
    {
        protected override void CreateModel(BaseEntity entity)
        {

            Student student = entity as Student;
            base.CreateModel(student);
        }
        protected override BaseEntity NewEntity()
        {
            return new Student();
        }

        public StudentList SelectAll()
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
    UserTbl.PhoneNumber
FROM UserTbl 
INNER JOIN StudentTbl 
    ON UserTbl.ID = StudentTbl.ID;";


            

            return new StudentList(base.Select());
        }



        public Student Login(string email, string password)
        {
            this.command.CommandText = $@"
        SELECT  UserTbl.[ID], UserTbl.[FirstName], UserTbl.[LastName], UserTbl.[Email],
                UserTbl.[Password], UserTbl.[BirthDate], UserTbl.[Gender], UserTbl.[PhoneNumber]
        FROM    StudentTbl 
        INNER JOIN UserTbl ON StudentTbl.[ID] = UserTbl.[ID]
        WHERE UserTbl.[Email] = '{email}' AND UserTbl.[Password] = '{password}'";
            StudentList students = new StudentList(base.Select());


            if (students.Count > 0)
                return students[0];

            return null;
        }

        

        // this case require multiple inputs
        // so we need to override the insert method
        public override void Insert(BaseEntity entity)
        {
            Student student = entity as Student;

            if (student != null)
            {
                this.inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                this.inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }

        public override string CreateInsertSQL(BaseEntity entity)
        {
            Student student = entity as Student;

            string sqlStr = $@"INSERT INTO StudentTbl
                                    ([id])
                            VALUES        ({student.Id})";

            return sqlStr;
        }
        public override void Update(BaseEntity entity)
        {
            Student student = entity as Student;

            if (student != null)
            {
                this.updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
                this.updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }

        }
        //not in use there are no diffrences for student
        //
        public override string CreateUpdateSQL(BaseEntity entity)
        {
            Student student = entity as Student;

            string sqlStr =  $@"UPDATE StudentTbl SET [ID] = {student.Id} WHERE [ID] = {student.Id}";

            return sqlStr;
        }



        //public override string CreateInsertSQL(BaseEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public override string CreateUpdateSQL(BaseEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public override string CreateDeleteSQL(BaseEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //#region Insert,Update,Delete

        //// this case require multiple inputs
        //// so we need to override the insert method
        //public override void Insert(BaseEntity entity)
        //{
        //    Student student = entity as Student;

        //    if (student != null)
        //    {
        //        this.inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
        //    }
        //}

        //public override string CreateInsertSQL(BaseEntity entity)
        //{
        //    Student student = entity as Student;

        //    string sqlStr = $"INSERT INTO tblStudent (id) VALUES ('{student.Id}')";

        //    return sqlStr;
        //}

        //public override string CreateUpdateSQL(BaseEntity entity)
        //{
        //    Student student = entity as Student;
        //    string sqlStr = $"UPDATE tblPeople SET Firstname = '{student.FirstName}', Lastname ='{student.LastName}', Telephone ='{student.Telephone}' WHERE ID={student.Id}";

        //    return sqlStr;
        //}

        //public override string CreateDeleteSQL(BaseEntity entity)
        //{
        //    Student student = entity as Student;
        //    string sqlStr = $"Delete from tblStudent WHERE ID={student.Id}";

        //    return sqlStr;
        //}
        //#endregion
    }
}