using MyWebShop.Models;
using MyWebShop.ViewModels;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebShop.Services
{
    public interface ICategoryInfoService : IDependency
    {
        IList<ProductListViewModel> GetProductByType(string contentType);
    }
}
