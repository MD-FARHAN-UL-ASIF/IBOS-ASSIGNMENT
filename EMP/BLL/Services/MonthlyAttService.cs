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
            var currentDate = DateTime.Now;

            var employees = DataAccessFactory.EmpData().Get();

            foreach (var employee in employees)
            {
                var attendanceRecords = DataAccessFactory.AttData().Get()
                    .Where(a => a.EmployeeId == employee.EmployeeId && a.AttendenceDate.Month == currentDate.Month)
                    .ToList();

                var report = new MonthlyAttDTO
                {
                    EmployeeName = employee.EmployeeName,
                    Month = currentDate.ToString("MMMM"), 
                    PayableSalary = employee.EmployeeSalary, 
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
