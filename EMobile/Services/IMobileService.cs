using EMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMobile.Services
{
    public  interface IMobileService
    {
        Task<PagedResults<Mobile>> GetMobilesAsync(PagingOptions pagingOptions);

        Task<Mobile> GetMobileAsync(Guid id);
    }
}
