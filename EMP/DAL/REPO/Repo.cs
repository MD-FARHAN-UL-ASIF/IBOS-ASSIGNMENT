using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.REPO
{
    public class Repo
    {
        public EMPContext db;
        public Repo()
        {
            var options = new DbContextOptionsBuilder<EMPContext>()
                .UseInMemoryDatabase(databaseName: "Employee")
                .Options;

            db = new EMPContext(options);
        }
    }
}
