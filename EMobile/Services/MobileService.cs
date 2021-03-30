using AutoMapper;
using AutoMapper.QueryableExtensions;
using EMobile.Data;
using EMobile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PagedResults<Mobile>> GetMobilesAsync(PagingOptions pagingOptions, SortOptions<Mobile, MobileEntity> sortOptions)
        {
            IQueryable<MobileEntity> query = _context.Mobiles;
            query = sortOptions.Apply(query);

            var size = await query.CountAsync();

            var items = await query
                .Skip(pagingOptions.Offset.Value)
                .Take(pagingOptions.Limit.Value)
                .ProjectTo<Mobile>(_mapper.ConfigurationProvider)
                .ToArrayAsync();

            return new PagedResults<Mobile>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
