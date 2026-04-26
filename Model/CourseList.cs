using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseList:List<Course>
     {
        public CourseList()
        {

        }
        public CourseList(IEnumerable<Course> list) : base(list) { }
        public CourseList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Course>().ToList()) { }

    }
}
