using Cidean.GF.Api.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace Cidean.GF.Api.Controllers
{
    public class ImportBusinessesController : ApiController
    {

        public void Post()
        {
            var work = new Core.Data.UnitOfWork(new Core.Data.DataContext());
            
            var url = System.Web.Hosting.HostingEnvironment.MapPath("~/Data/output.xml");
            XElement doc = XElement.Load(url);

            var items = doc.Elements();
            foreach (var item in items)
            {
                var newBusiness = new Business();
                newBusiness.Name = item.Element("title").Value;
                newBusiness.Address = item.Element("address").Value;
                newBusiness.Phone = item.Element("phone").Value;
                newBusiness.Url = item.Element("url").Value;
                newBusiness.LocationUrl = item.Element("googleplus").Value;
                newBusiness.Rating = Decimal.Parse(item.Element("rating").Value);
                work.Businesses.Add(newBusiness);
            }

            work.Complete();
            work.Dispose();

        }




    }
}
