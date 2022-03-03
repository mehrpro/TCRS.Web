using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.Models.Entities
{
    public class ClassTimeType
    {
        /// <summary>
        /// زمان اجرا کلاس جبرانی - طبق برنامه 
        /// </summary>
        public ClassTimeType()
        {
            ClassRegisters = new HashSet<ClassRegister>();
        }

        public int TypeID { get; set; }
        public string ClassTimeTypeTitle { get; set; }
        public bool IsActive { get; set; }



        public virtual ICollection<ClassRegister> ClassRegisters { get; set; }
    }
}
