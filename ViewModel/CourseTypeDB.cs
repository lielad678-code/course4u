using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CourseTypeDB:BaseDB
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
            CourseType courseType = entity as CourseType;
            courseType.Id = (int)this.reader["Id"];
            courseType.CourseName = this.reader["Course"].ToString();

        }
        protected override BaseEntity NewEntity()
        {
            return new CourseType();
        }


        public CourseType GetCourseTypeByID(int courseType)
        {
            this.command.CommandText = $@"SELECT * FROM CourseTypeTbl
                WHERE CourseTypeTbl.ID = {courseType};";

            CourseTypeList list = new CourseTypeList(Select());

            if (list.Count > 0)
                return list[0];

            return null;
        }

    }
}
