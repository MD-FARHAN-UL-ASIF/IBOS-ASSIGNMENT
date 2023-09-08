using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EMPContext : DbContext
    {

        

        public EMPContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Emp> Emps { get; set; }
        public DbSet<EmpAtt> EmpAtts { get; set; }
    }
}
