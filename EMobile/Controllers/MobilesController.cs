using EMobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MobilesController : ControllerBase
    {
        private readonly EMobileDbContext _context;

        public MobilesController(EMobileDbContext context)
        {
            _context = context;
        }

        [HttpGet("{mobileId}", Name =nameof(GetMobileById))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Mobile>> GetMobileById(Guid mobileId)
        {
            var entity = await _context.Mobiles.SingleOrDefaultAsync(x => x.Id == mobileId);

            if(entity == null)
            {
                return NotFound();
            }

            var resource = new Mobile
            {
                Href = Url.Link(nameof(GetMobileById), new { mobileId = entity.Id }),
                Model = entity.Model,
                Brand = entity.Brand,
                Size = entity.Size,
                Weight = entity.Weight,
                Resolution = entity.Resolution,
                Processor = entity.Processor,
                OperatingSystem = entity.OperatingSystem,
                Price = entity.Price,
                ImagePath = entity.ImagePath,
                VideoPath = entity.VideoPath
            };

            return resource;
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
