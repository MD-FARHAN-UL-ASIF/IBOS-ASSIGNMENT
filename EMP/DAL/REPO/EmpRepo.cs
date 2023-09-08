using DAL.EF.Models;
using DAL.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.REPO
{
    public class EmpRepo :Repo, iRepo<Emp, int, bool>
    {
        public bool Create(Emp obj)
        {
            db.Emps.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Emp> Get()
        {
            return db.Emps.ToList();
        }

        public Emp Get(int id)
        {
            return db.Emps.Find(id);
        }

        public Emp Get3rd()
        {
            return db.Emps
           .OrderByDescending(e => e.EmployeeSalary)
           .Skip(2)
           .Take(1)
           .FirstOrDefault();
        }

        public List<Emp> GetOnAbsent()
        {
            var empWithNoAbsentRecords = db.Emps
            .Where(emp =>
                emp.EmpAtt.All(att => att.IsAbsent == 0)
            )
            .OrderByDescending(emp => emp.EmployeeSalary)
            .ToList();

            return empWithNoAbsentRecords;
        }

        

        public bool Update(Emp obj)
        {
            var exObj = Get(obj.EmployeeId);
            if (exObj == null)
            {
                return false;
            }
            exObj.EmployeeName = obj.EmployeeName;
            exObj.EmployeeCode = obj.EmployeeCode;

            db.Emps.Update(exObj);
            return db.SaveChanges() > 0;
        }

        public List<string> GetOnHierarchy(int id)
        {
            var hierarchy = new List<string>();
            var visitedIds = new HashSet<int>(); 



            while (id != 0)
            {
                if (visitedIds.Contains(id))
                {
                    break;
                }



                var employee = db.Emps.FirstOrDefault(e => e.EmployeeId == id);



                if (employee == null)
                {
                    throw new Exception("Employee not found");
                }



                hierarchy.Add(employee.EmployeeName);
                visitedIds.Add(id); 
                id = employee.SupervisorId;
            }

            return hierarchy;
        }
    }
}
