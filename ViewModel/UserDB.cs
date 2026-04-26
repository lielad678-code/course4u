using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class UserDB : BaseDB
    {
        public override string CreateDeleteSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
        public override string CreateInsertSQL(BaseEntity entity)
        { 
            User user = entity as User;
            
            string sqlStr = $"INSERT INTO UserTbl ([FirstName], [LastName], [Email], [Password], [BirthDate], [Gender], [PhoneNumber]) " +
                $"VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}', '{user.BirthDate}', '{user.Gender}', '{user.PhoneNumber}')";
            return sqlStr;
        }

        public override string CreateUpdateSQL(BaseEntity entity)
        {
            User user = entity as User;

            string sqlStr = $@"UPDATE UserTbl SET 
                [FirstName] = '{user.FirstName}', 
                [LastName] = '{user.LastName}', 
                [Email] = '{user.Email}', 
                [Password] = '{user.Password}', 
                [BirthDate] = #{user.BirthDate}#, 
                [PhoneNumber] = '{user.PhoneNumber}'
              WHERE [ID] = {user.Id}";


            return sqlStr;
        }

        protected override void CreateModel(BaseEntity entity)
        {
            User user = entity as User;

            // -- Users
            user.Id = (int)this.reader["ID"];
            user.FirstName = this.reader["FirstName"].ToString();
            user.LastName = this.reader["LastName"].ToString();
            user.Email = this.reader["Email"].ToString();
            user.Password = this.reader["Password"].ToString();
            user.BirthDate = Convert.ToDateTime(this.reader["BirthDate"]);
            user.Gender = this.reader["Gender"].ToString();
            user.PhoneNumber = this.reader["PhoneNumber"].ToString();

        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
    }
}
