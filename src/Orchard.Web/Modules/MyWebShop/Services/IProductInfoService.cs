using MyWebShop.Models;
using Orchard;
using Orchard.Autoroute.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebShop.Services
{
    public interface IProductInfoService : IDependency
    {
        ProductPart GetProduct(string path);
    }
}
