﻿using FSA.Core.DataTypes;
using FSA.Core.Dtos;
using FSA.Core.Extensions;
using FSA.Core.Interfaces;
using FSA.Core.ServiceOrders.Dtos;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.Utils;
using System.Linq.Dynamic.Core;
using WebApiSO.Data.Dtos;
using WebApiSO.Models;

namespace WebApiSO.Features.ServiceOrderTasks.GetBySOId
{
    public class GetServiceOrdersTasksBySOIdHandler : IServiceHandler<long, IEnumerable<ServiceOrderTaskDto>>
    {
        private readonly IRepository repository;

        public GetServiceOrdersTasksBySOIdHandler([FromKeyedServices("SO_Repository")] IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// <see cref="Handle"/>: Obtiene un listado de todas las tareas de una orden de servicio partiendo del id de una orden de servicio.
        /// </summary>
        /// <param name="id">The service order's id</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public async Task<Result<IEnumerable<ServiceOrderTaskDto>>> Handle(long id)
        {
            Pagination pagination = new Pagination(10);

            List<string> errors = [];
            if (!repository.Exist<ServiceOrderRegister>(id))
                errors.Add($"{typeof(ServiceOrderRegister).Name} not found");

            if (errors.Count > 0)
                return Result<IEnumerable<ServiceOrderTaskDto>>.Failure(errors, CustomStatusCode.StatusBadRequest);

            var entity = repository.Entity<CustomServiceOrderTask>().Where(e => e.ServiceOrderId == id);

            entity = Search(entity, pagination);

            var result = entity.ApplyPagination(pagination).ToDynamicList<CustomServiceOrderTask>().Select(ServiceOrderTaskDto.ToDto).ToList();

            await Task.FromResult(result);

            return Result<IEnumerable<ServiceOrderTaskDto>>.SuccessWith(result!, pagination, CustomStatusCode.StatusOk);
        }

        private IQueryable<CustomServiceOrderTask> Search(IQueryable<CustomServiceOrderTask> query, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(pagination.FilterTerm))
                return query.Where(q => q.Observations!.Contains(pagination.FilterTerm));
            return query;
        }
    }
}
