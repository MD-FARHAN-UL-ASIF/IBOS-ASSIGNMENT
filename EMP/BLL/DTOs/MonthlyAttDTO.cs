using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MonthlyAttDTO
    {
        public string EmployeeName { get; set; }

        public string Month { get; set; }

        public int PayableSalary { get; set; }

        public int TotalPresent { get; set; }

        public int TotalAbsent { get; set; }

        public int TotalOffday { get; set; }
    }
}
