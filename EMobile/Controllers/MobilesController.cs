using EMobile.Models;
using EMobile.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMobile.Services;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MobilesController : ControllerBase
    {
        private readonly IMobileService _mobileService;

        private readonly PagingOptions _defaultPagingOptions;

        public MobilesController(IMobileService service, IOptions<PagingOptions> defaultPagingOptionsWrapper)
        {
            _mobileService = service;
            _defaultPagingOptions = defaultPagingOptionsWrapper.Value;
        }

        [HttpGet(Name = nameof(GetAllMobiles))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Collection<Mobile>>> GetAllMobiles(
            [FromQuery] PagingOptions pagingOptions, [FromQuery] SortOptions<Mobile, MobileEntity> sortOptions)
        {
            pagingOptions.Offset ??= _defaultPagingOptions.Offset;
            pagingOptions.Limit ??= _defaultPagingOptions.Limit;

            var mobiles = await _mobileService.GetMobilesAsync(pagingOptions, sortOptions);

            var collection = PagedCollection<Mobile>
                .Create(Link.ToCollection(nameof(GetAllMobiles)), mobiles.Items.ToArray(), mobiles.TotalSize, pagingOptions);

            return collection;
        }

        [HttpGet("{mobileId}", Name =nameof(GetMobileById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Mobile>> GetMobileById(Guid mobileId)
        {
            var mobile = await _mobileService.GetMobileAsync(mobileId);

            if (mobile == null) return NotFound();

            return mobile;
        }

        //// GET: api/<MobilesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{

        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<MobilesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<MobilesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<MobilesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MobilesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
