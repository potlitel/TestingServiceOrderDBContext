using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Extensions;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;
using System.Linq.Dynamic.Core;
using WebApiSO.Data.Dtos;

namespace WebApiSO.Features.ServiceOrderDocuments.GetAllBySOId
{
    public class GetServiceOrdersDocumentsBySOIdHandler : IServiceHandler<long, IEnumerable<ServiceOrderDocDto>>
    {
        private readonly IRepository repository;

        public GetServiceOrdersDocumentsBySOIdHandler([FromKeyedServices("SO_Repository")] IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<IEnumerable<ServiceOrderDocDto>>> Handle(long id)
        {
            Pagination pagination = new Pagination(10);

            List<string> errors = [];
            if (!repository.Exist<ServiceOrder>(id))
                errors.Add($"{typeof(ServiceOrder).Name} not found");

            if (errors.Count > 0)
                return Result<IEnumerable<ServiceOrderDocDto>>.Failure(errors, CustomStatusCode.StatusBadRequest);

            var entityList = repository.Entity<ServiceOrderDocument>().Where(t => t.ServiceOrderId == id);

            entityList = Search(entityList, pagination);

            var result = entityList.ApplyPagination(pagination).ToDynamicList<ServiceOrderDocument>().Select(ServiceOrderDocDto.ToDto).ToList();

            await AttachRelatedObject(id, result);

            return Result<IEnumerable<ServiceOrderDocDto>>.SuccessWith(result!, pagination, CustomStatusCode.StatusOk);
        }

        /// <summary>
        /// https://medium.com/@sunside/converting-between-types-in-increasingly-absurd-ways-89414ae6eb7c
        /// </summary>
        /// <param name="id"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task AttachRelatedObject(long id, List<ServiceOrderDocDto> result)
        {
            //Get ServiceOrder objecto to attach to response
            var entityExtra = await repository.GetByIdAsync<ServiceOrder>(id);
            var documentTypes = repository.Entity<DocumentType>();

            foreach (var item in result)
            {
                item.ServiceOrder = CustomServiceOrderDto.ToDto(entityExtra);
                item.DocumentType = DocumentTypeDto.ToDto(await documentTypes.FirstOrDefaultAsync(t => t.Id == item.DocumentTypeId));
            }
        }

        private IQueryable<ServiceOrderDocument> Search(IQueryable<ServiceOrderDocument> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Name!.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
