using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmpAttDTO
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateOnly AttendenceDate { get; set; }

        public int IsPresent { get; set; }

        public int IsAbsent { get; set; }

        public int IsOffday { get; set; }

        public DAL.EF.Models.Emp Emp { get; set; }
    }
}
