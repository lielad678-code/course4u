using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AdminDB : UserDB
    {
        protected override void CreateModel(BaseEntity entity)
        {

            Admin admin = entity as Admin;
            base.CreateModel(admin);
        }
        protected override BaseEntity NewEntity()
        {
            return new Admin();
        }
        public Admin Login(string email, string password)
        {
            this.command.CommandText = $@"
        SELECT  UserTbl.[ID], UserTbl.[FirstName], UserTbl.[LastName], UserTbl.[Email],
                UserTbl.[Password], UserTbl.[BirthDate], UserTbl.[Gender], UserTbl.[PhoneNumber]
        FROM    AdminTbl 
        INNER JOIN UserTbl ON AdminTbl.[ID] = UserTbl.[ID]
        WHERE UserTbl.[Email] = '{email}' AND UserTbl.[Password] = '{password}'";
            AdminList admin = new AdminList(base.Select());


            if (admin.Count > 0)
                return admin[0];

            return null;
        }
        public override void Update(BaseEntity entity)
        {
            Admin admin = entity as Admin;

            if (admin != null)
            {
                this.updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
                this.updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }

        }
        //not in use there are no diffrences for student
        //
        public override string CreateUpdateSQL(BaseEntity entity)
        {
            Admin admin = entity as Admin;


            string sqlStr = $@"UPDATE AdminTbl SET [ID] = {admin.Id} WHERE [ID] = {admin.Id}";

            return sqlStr;
        }
    }
}
