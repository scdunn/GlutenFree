using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cidean.GF.Api.Core.Domain;
using Cidean.GF.Api.Core.Interfaces;

namespace Cidean.GF.Api.Core.Data
{

    

    public class BusinessesRepository : Repository<Business>, IBusinessesRepository
    {
        public BusinessesRepository(DataContext context) 
            : base(context)
        {
        }


        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}