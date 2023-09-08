using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MonthlyAttService
    {
        public List<MonthlyAttDTO> GetMonthlyReport()
        {
            var reports = new List<MonthlyAttDTO>();

            
            var employees = DataAccessFactory.EmpData().Get();

            foreach (var employee in employees)
            {
               
                var attendanceRecords = DataAccessFactory.AttData().Get()
                    .Where(a => a.EmployeeId == employee.EmployeeId && a.AttendenceDate.Month == DateTime.Now.Month)
                    .ToList();

                // Calculate the report data
                var report = new MonthlyAttDTO
                {
                    EmployeeName = employee.EmployeeName,
                    Month = DateTime.Now.ToString("MMMM"), // Replace with the actual month name
                    PayableSalary = employee.EmployeeSalary, // Replace with the actual logic for calculating payable salary
                    TotalPresent = attendanceRecords.Count(a => a.IsPresent == 1),
                    TotalAbsent = attendanceRecords.Count(a => a.IsAbsent == 1),
                    TotalOffday = attendanceRecords.Count(a => a.IsOffday == 1),
                };

                reports.Add(report);
            }

            return reports;
        }
    }
}
