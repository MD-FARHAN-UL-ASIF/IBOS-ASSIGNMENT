using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public DateTime AttendenceDate { get; set; }

        [Required]
        public int IsPresent { get; set; }

        [Required]
        public int IsAbsent { get; set; }

        [Required]
        public int IsOffday { get; set; }

 //       public virtual Emp Emp { get; set; }
    }
}
