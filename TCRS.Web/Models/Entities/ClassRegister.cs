using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCRS.Web.Models.Entities
{
    public class ClassRegister
    {
        /// <summary>
        /// کلاس های بارگزاری شده
        /// </summary>
        public int RegisterID { get; set; }
        public int ClassRoomID_FK { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public string PersonID_FK { get; set; }
        public Person Person { get; set; }
        public int ClassTypeID_FK { get; set; }
        public ClassType ClassType { get; set; }
        public int ClassTimeTypeID_FK { get; set; }
        public ClassTimeType ClassTimeType { get; set; }
        public short StudentNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }




    }
}
