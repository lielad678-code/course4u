using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseTypeList:List<CourseType>
    {

        public CourseTypeList(IEnumerable<CourseType> list) : base(list) { }
        public CourseTypeList(IEnumerable<BaseEntity> list)
            : base(list.Cast<CourseType>().ToList()) { }

    }
}
