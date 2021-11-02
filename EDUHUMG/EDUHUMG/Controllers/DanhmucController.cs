using EDUHUMG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDUHUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucController : ControllerBase
    {
        private readonly HUMGEDUContext _context;
        public DanhmucController(HUMGEDUContext context)
        {
            _context = context;
        }
        // GET: api/<DanhmucController>
        [HttpGet]
        public async Task<IEnumerable<Danhmuc>> GetAllBaihoc()
        {
            return await _context.Danhmucs.ToListAsync();
        }

        // GET api/<DanhmucController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DanhmucController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DanhmucController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DanhmucController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
