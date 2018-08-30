using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheGame.EFRepository;

namespace GameWeb.Controllers
{
    //[Route("api/controller")]
    public class ValuesController : ApiController
    {
        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[HttpGet]
        public IHttpActionResult Get()
        {
            var repository = new GameStateRepository();
            var result = repository.GetById(2);
            //var result = 1;

            return Json(new
            {
                success = true,
                Message = result
            });
        }

        // GET api/values/5
        
        public IHttpActionResult Get(int id) //api/values/2
        {
            var repository = new GameStateRepository();
            var result = repository.GetById(id);
            //var result = 1;

            return Json(new
            {
                success = true,
                Message = result
            });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
