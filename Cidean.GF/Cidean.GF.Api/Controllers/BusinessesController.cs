using Cidean.GF.Api.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cidean.GF.Api.Controllers
{
    public class BusinessesController : ApiController
    {

        // GET: api/Default
        public IEnumerable<Business> Get()
        {
            var work = new Core.Data.UnitOfWork(new Core.Data.DataContext());
            return work.Businesses.GetAll();
        }

    }
}
