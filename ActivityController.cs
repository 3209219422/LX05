using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ActivityController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Json(DAL.Activity.Instance.GetCount());
        }
        [HttpGet("verifyCount")]
        public ActionResult GetVerifyCount()
        {
            return Json(DAL.Activity.Insance.GetVerifyCount());
        }
        [HttpGet("recommend")]
        public ActionResult GetRecommend()
        {
            var result = DAL.Activity.Insance.GetRecommend();
            if (result != null)
                return Json(Result.Ok(result));
            else
                return Json(Result.Err("记录数为0"));
        }
        [HttpGet("end")]
        public ActionResult GetEnd()
        {
            var result = DAL.Activity.Instance.GetEnd();
            if (result.Count() == 0)
                return Json(Result.Err("没有任何活动"));
            else
                return Json(Result.Ok(result));
        }
    }
}
