using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TCRS.Web.Models.Entities
{
    public class Person : IdentityUser
    {
        /// <summary>
        /// کاربران سایت
        /// </summary>
        public Person()
        {
            ClassRooms = new HashSet<ClassRoom>();
        }
        public string FName { get; set; }
        public string LName { get; set; }
        public string NationalCode { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }


    }
}
