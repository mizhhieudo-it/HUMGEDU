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
    public class LoginController : ControllerBase
    {
        // GET: api/<LoginController>
        /*  [HttpPost]
          public IEnumerable<Taikhoan> Post()
          {
              //using ( var context = new HUMGEDUContext())
              // {
              //     return context.Taikhoans.ToList();

              // }

              HUMGEDUContext context = new HUMGEDUContext();
              return context.Taikhoans.ToList();
          }*/
        [HttpPost("thongtinuser"), FormatFilter]
        public IEnumerable<Taikhoan> Thongtin([FromForm] layuser parameter)
        {
            HUMGEDUContext context = new HUMGEDUContext();
            List<Taikhoan> taikhoans = context.Taikhoans.ToList();
            return taikhoans;
        }
        // POST api/<LoginController>
        [HttpPost("layuser"), FormatFilter]
        public IEnumerable<Taikhoan> Post([FromForm] layuser parameter)
        {
            HUMGEDUContext context = new HUMGEDUContext();

            List<Taikhoan> ketqua = new List<Taikhoan>();
            List<Taikhoan> taikhoans = context.Taikhoans.ToList();

            //C1
            int checkLoginSuccess = taikhoans.Where(tk => tk.Username == parameter.user && tk.Password == parameter.pass).Count();

            /* //C2
             int checkLoginSuccess2 = 0;
             foreach (Taikhoan tk in taikhoans)
             {
                 if (tk.Username == parameter.user && tk.Password == parameter.pass)
                 {
                     checkLoginSuccess2++;
                 }
             }*/

            if (checkLoginSuccess > 0)
            {
                ketqua = taikhoans.Where(tk => tk.Iduser == parameter.idcanlay).ToList();

            }
            else
            {
                // không có gì
            }

            return ketqua;


        }

        [HttpPost("login"), FormatFilter]
        public Status Posst([FromForm] layuser parameter)
        {
            HUMGEDUContext context = new HUMGEDUContext();
            List<Taikhoan> taikhoans = context.Taikhoans.ToList();

            Status status = new Status();



            int checkLoginSuccess = taikhoans.Where(tk => tk.Username == parameter.user && tk.Password == parameter.pass).Count();

            if (checkLoginSuccess > 0)
            {
                status.status = true;
                status.message = "success";
                status.code = 200;
               // status.data = taikhoans;


            }
            else
            {
                status.status = false;
                status.message = "fail";
                status.code = 401;
            }

            return status;
        }
    }
}
