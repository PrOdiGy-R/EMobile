using EMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMobile.Services
{
    public interface IMobileService
    {
        Task<PagedResults<Mobile>> GetMobilesAsync(PagingOptions pagingOptions, SortOptions<Mobile, MobileEntity> sortOptions);

        Task<Mobile> GetMobileAsync(Guid id);
    }
}
