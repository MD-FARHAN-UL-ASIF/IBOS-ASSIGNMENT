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
    public  class AttService
    {
        public static EmpAttDTO Create(EmpAttDTO attendenceDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmpAttDTO, EmpAtt>();
                cfg.CreateMap<EmpAtt, EmpAttDTO>();
            });
            var mapper = new Mapper(config);

            var attendence = mapper.Map<EmpAtt>(attendenceDTO);

            var isSuccess = DataAccessFactory.AttData().Create(attendence);

            if (isSuccess)
            {
                var createAttendence = DataAccessFactory.AttData().Get(attendence.Id);

                var createAttendenceDTO = mapper.Map<EmpAttDTO>(createAttendence);

                return createAttendenceDTO;
            }
            else
            {
                return null;
            }
        }


        public static List<EmpAttDTO> Get()
        {
            var data = DataAccessFactory.AttData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<EmpAtt, EmpAttDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<EmpAttDTO>>(data);
            return converted;
        }

        public static EmpAttDTO Get(int id)
        {
            var data = DataAccessFactory.AttData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmpAtt, EmpAttDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<EmpAttDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }

        
    }
}
