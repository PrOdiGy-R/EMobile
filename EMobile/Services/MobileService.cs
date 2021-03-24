using AutoMapper;
using EMobile.Data;
using EMobile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EMobile.Services
{
    public class MobileService : IMobileService
    {
        private readonly EMobileDbContext _context;
        private readonly IMapper _mapper;

        public MobileService(EMobileDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Mobile> GetMobileAsync(Guid id)
        {
            var entity = await _context.Mobiles.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<Mobile>(entity);
        }
    }
}
