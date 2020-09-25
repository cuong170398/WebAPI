using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testAPI.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        [Route("GetCatalog")]
        [HttpGet]
        public string Get()
        {
            return "Hello Word";
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        [Route("aa")]
        public string Post()
        {
            return "Thêm gì không";
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
