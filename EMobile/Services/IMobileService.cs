using EMobile.Models;
using System;
using System.Threading.Tasks;

namespace EMobile.Services
{
    public  interface IMobileService
    {
        Task<Mobile> GetMobileAsync(Guid id);
    }
}
