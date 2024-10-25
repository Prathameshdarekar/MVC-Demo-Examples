using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Services
{
    public interface IProductService
    {
        IEnumerable<string> GetProducts();
    }
}