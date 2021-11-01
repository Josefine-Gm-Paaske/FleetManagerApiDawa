using FMWebApITekMod10.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaoFactory
    {
        public static IDao<TModel> Create<TModel>(IDataContext dataContext)
        {
            if (typeof(IDataContext<HttpClient>).IsAssignableFrom(dataContext.GetType()))
            {
                return CreateHttpClientDao<TModel>(dataContext);
            }
            if (typeof(IDataContext<IRestClient>).IsAssignableFrom(dataContext.GetType()))
            {
                return CreateRestSharpClientDao<TModel>(dataContext);
            }
            throw new DaoException("DataContext connection not supported");
        }

        private static IDao<TModel> CreateRestSharpClientDao<TModel>(IDataContext dataContext)
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(Customers) => new Daos.RestSharp.CustomerDao(dataContext) as IDao<TModel>,
                _ => throw new DaoException("Unknown model type")
            };
        }

        private static IDao<TModel> CreateHttpClientDao<TModel>(IDataContext dataContext)
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(Customers) => new Daos.Http.CustomerDao(dataContext) as IDao<TModel>,
                _ => throw new DaoException("Unknown model type")
            };
        }
    }
}
