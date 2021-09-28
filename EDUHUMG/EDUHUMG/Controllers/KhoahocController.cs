using EDUHUMG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace EDUHUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoahocController : ControllerBase
    {
        private readonly HUMGEDUContext _context;
        public KhoahocController(HUMGEDUContext context)
        {
            _context = context; 
        }
        [HttpGet]
        public async Task<IEnumerable<Khoahoc>> GetAllKhoahoc()
        {
            return await _context.Khoahocs.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateKhochoc(Khoahoc ckh)
        {
            if(ckh == null)
            {
                return BadRequest();
            }
            _context.Khoahocs.Add(ckh);
            await _context.SaveChangesAsync();
            return StatusCode(201, ckh);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhoahoc(Khoahoc khud,int id)
        {
            if(id != khud.Idkhoahoc)
            {
                return BadRequest();
            }
            _context.Khoahocs.Update(khud);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoahoc(int id)
        {
            var kh = _context.Khoahocs.Find(id);
            _context.Khoahocs.Remove(kh);
            await _context.SaveChangesAsync();
            return StatusCode(200, kh);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> SearchKhoahoc([FromQuery] string tenkh)
        {
            var kq = await _context.Khoahocs.Where(x => x.Tenkhoahoc.Contains(tenkh)).ToListAsync();
            return StatusCode(200, kq);
        }
    }
    
}
