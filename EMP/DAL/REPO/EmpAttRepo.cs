using DAL.EF.Models;
using DAL.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.REPO
{
    public class EmpAttRepo : Repo, iRepo<EmpAtt, int, bool>
    {
        public bool Create(EmpAtt obj)
        {
            db.EmpAtts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<EmpAtt> Get()
        {
            return db.EmpAtts.ToList();
        }

        public EmpAtt Get(int id)
        {
            return db.EmpAtts.Find(id);
        }

        public EmpAtt Get3rd()
        {
            throw new NotImplementedException();
        }

        public List<EmpAtt> GetOnAbsent()
        {
            throw new NotImplementedException();
        }

        public List<string> GetOnHierarchy(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(EmpAtt obj)
        {
            throw new NotImplementedException();
        }
    }
}
