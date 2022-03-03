using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.Models.Entities
{
    /// <summary>
    /// نوع کلاس حضوری مجازی
    /// </summary>
    public class ClassType
    {

        public ClassType()
        {
            ClassRegisters = new HashSet<ClassRegister>();
        }

        public int ClassTypeID { get; set; }
        public string ClassTypeTitle { get; set; }
        public bool IsActive { get; set; }



        public virtual ICollection<ClassRegister> ClassRegisters { get; set; }
    }
}
