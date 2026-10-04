using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.OrdersOfTheDay
{
    public interface IOrdersOfTheDayRepository
    {
        Task<int> GetMaxOdTypeIdAsync();
        Task<List<OrdersOfTheDayType>> GetAllOdTypesAsync();
        Task<OrdersOfTheDayType> GetOdTypesByIdAsync(int odTypeId);
        Task<bool> AddOdTypeAsync(OrdersOfTheDayType entity);
        Task<bool> EditOdTypeAsync(OrdersOfTheDayType model);
    }
}
