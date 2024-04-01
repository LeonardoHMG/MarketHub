using MarketHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketHub.Domain.Interfaces
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllVendorsAsync();
        Task<Vendor> GetByIdAsync(Guid id);
        Task<Vendor> AddAsync(Vendor vendor);
        Task<Vendor> UpdateAsync(Vendor vendor);
        Task<Vendor> DeleteAsync(Guid id);
        Task<Vendor> InactiveAsync(Guid id);
    }
}
