using DAL.EF.Models;
using DAL.INTERFACES;
using DAL.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static iRepo<Emp, int, bool> EmpData()
        {
            return new EmpRepo();
        }

        public static iRepo<EmpAtt, int, bool> AttData()
        {
            return new EmpAttRepo();
        }
    }
}
