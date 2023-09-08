using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class EmpAtt
    {
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public DateTime AttendenceDate { get; set; }

        public int IsPresent { get; set; }

        public int IsAbsent { get; set; }

        public int IsOffday { get; set; }

 //       public virtual Emp Emp { get; set; }
    }
}
