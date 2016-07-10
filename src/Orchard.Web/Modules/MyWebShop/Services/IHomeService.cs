using MyWebShop.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebShop.Services
{
    public interface IHomeService : IDependency 
    {
        IEnumerable<ProductPart> GetHomeProductCategory();
    }
}
