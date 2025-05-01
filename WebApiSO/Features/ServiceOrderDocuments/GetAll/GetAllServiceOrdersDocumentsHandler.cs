using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Extensions;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;
using System.Linq.Dynamic.Core;
using WebApiSO.Data.Dtos;

namespace WebApiSO.Features.ServiceOrderDocuments.GetAll
{
    public class GetAllServiceOrdersDocumentsHandler : IServiceHandler<Pagination, IEnumerable<ServiceOrderDocDto>>
    {
        private readonly IRepository repository;
        //private readonly IAzureStorageManager azureStorageManager;

        public GetAllServiceOrdersDocumentsHandler([FromKeyedServices("SO_Repository")] IRepository repository/*, IAzureStorageManager azureStorageManager*/)
        {
            this.repository = repository;
            //this.azureStorageManager = azureStorageManager;
        }

        public async Task<Result<IEnumerable<ServiceOrderDocDto>>> Handle(Pagination pagination)
        {
            pagination = Pagination.Create(pagination);

            var entity = repository.Entity<ServiceOrderDocument>();
            var serviceOrders = repository.Entity<ServiceOrder>();
            var documentTypes = repository.Entity<DocumentType>();

            entity = Search(entity, pagination);

            var result = entity.ApplyPagination(pagination).ToDynamicList<ServiceOrderDocument>().Select(ServiceOrderDocDto.ToDto).ToList();

            //for (int i = 0; i < result.Count(); i++)
            //{
            //    var item = result.ElementAt(i);
            //    item.Url = azureStorageManager.GetSasUri(item.Name!);
            //}
            List<ServiceOrderDocDto> newList = [];
            foreach (var item in result)
            {
                item.ServiceOrder = CustomServiceOrderDto.ToDto(await serviceOrders.FirstOrDefaultAsync(so => so.Id == item.ServiceOrderId));
                item.DocumentType = DocumentTypeDto.ToDto(await documentTypes.FirstOrDefaultAsync(t => t.Id == item.DocumentTypeId));
                newList.Add(item);
            }

            return Result<IEnumerable<ServiceOrderDocDto>>.SuccessWith(result, pagination, CustomStatusCode.StatusOk);
        }

        private IQueryable<ServiceOrderDocument> Search(IQueryable<ServiceOrderDocument> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Name.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
