using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Emp
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeCode { get; set; }

        [Required]
        public int EmployeeSalary { get; set; }

        [Required]
        public int SupervisorId { get; set; }

        public ICollection<EmpAtt> EmpAtt { get; set; }

    }
}
