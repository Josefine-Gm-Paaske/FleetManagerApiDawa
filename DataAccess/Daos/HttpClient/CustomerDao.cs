using FMWebApITekMod10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace DataAccess.Daos.Http
{
    class CustomerDao : BaseDao<HttpClient>, IDao<Customers>
    {
        public CustomerDao(IDataContext dataContext) : base(dataContext as IDataContext<HttpClient>)
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
            using HttpClient client = DataContext.Open();

            string resource = "/postnumre";

            HttpResponseMessage response = client.GetAsync(resource).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseJson = response.Content.ReadAsStringAsync().Result;
                IEnumerable<City> result = JsonConvert.DeserializeObject<IEnumerable<City>>(responseJson);
                return result;
            }
            return null;
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
