using Cidean.GF.Api.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cidean.GF.Api.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBusinessesRepository Businesses { get; }
        int Complete();
    }
}