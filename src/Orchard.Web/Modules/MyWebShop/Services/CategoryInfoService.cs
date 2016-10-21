using MyWebShop.Models;
using MyWebShop.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.ContentManagement.Records;
using Orchard.Core.Settings.Metadata.Records;
using Orchard.Data;
using Orchard.MediaLibrary.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebShop.Services
{
    public class CategoryInfoService:ICategoryInfoService
    {
        private IRepository<ContentTypeDefinitionRecord> _contentTypeRepository;
        private IContentManager _contentManager;
        public CategoryInfoService(IRepository<ContentTypeDefinitionRecord> contentTypeRepository, IContentManager contentManager)
        {
            _contentTypeRepository = contentTypeRepository;
            _contentManager = contentManager;
        }
        public IList<ProductListViewModel> GetProductByType(string contentType)
        {
            IList<ProductListViewModel> result=new List<ProductListViewModel>();
            var contentTypeRecord = _contentTypeRepository.Get(x => x.Name == contentType);
            if (contentTypeRecord != null)
            {
                var products = _contentManager.Query(contentType).ForPart<ProductPart>().List();
                result=products.Select(p => new ProductListViewModel()
                {
                    ProductItem=p,
                    ProductTitle = _contentManager.GetItemMetadata(p).DisplayText,
                    ProductLink = "../"+p.ContentItem.As<IAliasAspect>().Path,
                    ProductType=contentTypeRecord.DisplayName,
                    ProductImage = p.ContentItem.Parts.SelectMany(x => x.Fields.OfType<MediaLibraryPickerField>()).First().MediaParts.FirstOrDefault()
                 
                }).ToList();
            }
            return result;
        }
    }
}