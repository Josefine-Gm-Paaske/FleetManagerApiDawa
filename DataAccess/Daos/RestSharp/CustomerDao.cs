using FMWebApITekMod10.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Daos.RestSharp
{
    class CustomerDao : BaseDao<IRestClient>, IDao<Customers>
    {
        public CustomerDao(IDataContext dataContext) : base(dataContext as IDataContext<IRestClient>)
        {
        }

        public Customers Create(Customers model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customers model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> Read()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> Read(Func<Customers, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customers model)
        {
            throw new NotImplementedException();
        }
    }
}
