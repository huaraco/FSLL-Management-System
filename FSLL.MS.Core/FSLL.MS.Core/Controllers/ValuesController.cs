using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FSLL.MS.Core.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value3", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            DAL.Repository<DAL.vmember> repo = new DAL.Repository<DAL.vmember>();
            DAL.Repository<DAL.userlogin> repo2 = new DAL.Repository<DAL.userlogin>();
            //return repo2.All().First().memberid.ToString();
            return repo.All().First().Name;
            //return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}