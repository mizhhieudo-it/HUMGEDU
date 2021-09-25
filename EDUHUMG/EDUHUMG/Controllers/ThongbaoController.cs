using EDUHUMG.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EDUHUMG.Common.ClassCommon;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDUHUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongbaoController : ControllerBase
    {
        // GET: api/<ThongbaoController>
        [HttpGet]
        public IEnumerable<Thongbao> Get()
        {
            HUMGEDUContext context = new HUMGEDUContext();
            List<Thongbao> thongbaos = new List<Thongbao>();
            return thongbaos;
        }
        [HttpGet("{thongbao}")]
        public IEnumerable<Thongbao> Gett()
        {
            HUMGEDUContext context = new HUMGEDUContext();
            List<Thongbao> thongbaos = context.Thongbaos.ToList();
            return thongbaos;
        }
        [HttpGet("{laychitiet}")]
        public IEnumerable<Thongbao> Get1(int id)
        {
            HUMGEDUContext context = new HUMGEDUContext();
            List<Thongbao> thongbaos = context.Thongbaos.ToList();
            IEnumerable<Thongbao> ketqua = from d in thongbaos
                                           where d.Idthongbao == id
                                           select d;
            return ketqua;
        }
        [HttpGet("{xoathongbao}")]
        public Status XoaThongBao(int Id)
        {
            Status status = new Status();
            HUMGEDUContext context = new HUMGEDUContext();
            List<Thongbao> thongbaos = context.Thongbaos.ToList();
            Thongbao ketqua = context.Thongbaos.Single(x => x.Idthongbao == Id);
            if (ketqua == null)
            {
                context.Thongbaos.Remove(ketqua);
                context.SaveChanges();
                status.status = true;
                status.message = "success";
                status.code = 200;
            }
            else
            {
                status.status = true;
                status.message = "success";
                status.code = 200;
            }



            return status;
        }

        // GET api/<ThongbaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThongbaoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThongbaoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThongbaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
