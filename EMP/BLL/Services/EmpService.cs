using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmpService
    {
        public static EmpDTO Create(EmpDTO employee)
        {
            var existingEmployees = DataAccessFactory.EmpData().Get();
            if (existingEmployees == null || !existingEmployees.Any())
            {
                employee.EmployeeId = 502030;
            }
            else
            {
                int maxEmployeeId = existingEmployees.Max(x => x.EmployeeId);
                employee.EmployeeId = maxEmployeeId + 1;
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmpDTO, Emp>();
                cfg.CreateMap<Emp, EmpDTO>();
            });
            var mapper = new Mapper(config);

            var emp = mapper.Map<Emp>(employee);

            var isSuccess = DataAccessFactory.EmpData().Create(emp);

            if (isSuccess)
            {
                var createEmployee = DataAccessFactory.EmpData().Get(emp.EmployeeId);

                var createEmpDTO = mapper.Map<EmpDTO>(createEmployee);

                return createEmpDTO;
            }
            else
            {
                return null;
            }
        }




        public static List<EmpDTO> Get()
        {
            var data = DataAccessFactory.EmpData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Emp, EmpDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<EmpDTO>>(data);
            return converted;
        }

        public static EmpDTO Get(int id)
        {
            var data = DataAccessFactory.EmpData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Emp, EmpDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<EmpDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }


        public static bool Update(EmpDTO employee)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmpDTO, Emp>();
                cfg.CreateMap<Emp, EmpDTO>();
            });
            var mapper = new Mapper(config);

            var emp = mapper.Map<Emp>(employee);

            var isSuccess = DataAccessFactory.EmpData().Update(emp);

            return isSuccess;
        }

        public static List<EmpDTO> GetOnAbsent()
        {
            var data = DataAccessFactory.EmpData().GetOnAbsent();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Emp, EmpDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<EmpDTO>>(data);
            return converted;
        }

        public static EmpDTO Get3rd()
        {
            var data = DataAccessFactory.EmpData().Get3rd();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Emp, EmpDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<EmpDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }

        public static List<string> GetEmployeeHierarchy(int id)
        {
            return DataAccessFactory.EmpData().GetOnHierarchy(id);
        }
    }
}
