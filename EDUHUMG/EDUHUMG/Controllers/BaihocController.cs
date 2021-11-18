using EDUHUMG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUHUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaihocController : ControllerBase
    {
        private readonly HUMGEDUContext _context;
        public BaihocController(HUMGEDUContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Baihoc>> GetAllBaihoc()
        {
            return await _context.Baihocs.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateKhoachoc(Baihoc ckh)
        {
            if (ckh == null)
            {
                return BadRequest();
            }
            _context.Baihocs.Add(ckh);
            await _context.SaveChangesAsync();
            return StatusCode(201, ckh);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBaihoc(Baihoc bhud, int id)
        {
            if (id != bhud.Idbaihoc)
            {
                return BadRequest();
            }
            _context.Baihocs.Update(bhud);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaihoc(int id)
        {
            var kh = _context.Baihocs.Find(id);
            _context.Baihocs.Remove(kh);
            await _context.SaveChangesAsync();
            return StatusCode(200, kh);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> SearchBaihoc([FromQuery] string tenbh)
        {
            var kq = await _context.Baihocs.Where(x => x.Tieudebaihoc.Contains(tenbh)).ToListAsync();
            return StatusCode(200, kq);
        }
        [HttpGet("SearchByid")]
        public async Task<IActionResult> SearchById(int id)
        {
            var kq = await (from lesson in _context.Baihocs
                            join cou in _context.Khoahocs
                            on lesson.Idkhoahoc equals cou.Idkhoahoc
                            where lesson.Idbaihoc == id
                            select new
                            {
                                less = lesson,
                                titlecourse =  cou.Tenkhoahoc
                            }
                            ).ToListAsync();
            return StatusCode(200, kq);
        }
    }
}
