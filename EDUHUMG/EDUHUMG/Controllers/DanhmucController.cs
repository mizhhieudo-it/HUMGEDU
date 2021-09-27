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
    public class DanhmucController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<DanhmucChicoten> Get()
        {

            HUMGEDUContext context = new HUMGEDUContext();
            List<Danhmuc> danhmucs = context.Danhmucs.ToList();

            IEnumerable<DanhmucChicoten> ketqua = (from d in danhmucs
                                                   select new DanhmucChicoten()
                                                   { tendanhmuc = d.Tendanhmuc });
            return ketqua;
        }

        [HttpGet("timdm/{id}")]
        public IEnumerable<Danhmuc> Timdanhmuc(int id)
        {
            HUMGEDUContext context = new HUMGEDUContext();
            List<Danhmuc> danhmucs = context.Danhmucs.ToList();
            IEnumerable<Danhmuc> ketqua = from d in danhmucs
                                          where d.Iddanhmuc == id
                                          select d; ;
            return ketqua;
        }

        [HttpGet("xoadm/{id}")]
        public Status Xoadm(int id)
        {
            Status status = new Status();
            HUMGEDUContext context = new HUMGEDUContext();
            List<Danhmuc> danhmucs = context.Danhmucs.ToList();
            Danhmuc ketqua = context.Danhmucs.Single(x => x.Iddanhmuc == id);
            if (ketqua != null)
            {
                context.Danhmucs.Remove(ketqua);
                context.SaveChanges();
                status.status = true;
                status.message = "success";
                status.code = 200;


            }
            else
            {
                status.status = false;
                status.message = "fail";
                status.code = 401;
            }

            return status;

        }

        // POST api/<DanhmucController>
        [HttpPost("themdm")]
        public Status Post([FromBody] Danhmuc dulieu)
        {
            Status status1 = new Status();
            HUMGEDUContext context = new HUMGEDUContext();
            List<Danhmuc> danhmucs = context.Danhmucs.ToList();

            if (dulieu != null)
            {
                context.Danhmucs.Add(dulieu);
                context.SaveChanges();
                status1.code = 200;
                status1.status = true;
                status1.message = "suucces";
                status1.data = dulieu;
            }
            else
            {

                status1.code = 401;
                status1.status = false;
                status1.message = "fail";
            }
            return status1;
        }
        /*[HttpPost("suadm/{id}")]

        public Status Suadm([FromBody] Danhmuc dulieu)
        {

        }*/
        // DELETE api/<DanhmucController>/5

    }
}
