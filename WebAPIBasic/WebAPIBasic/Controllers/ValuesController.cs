using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIBasic.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        static List<string> stringsList = new List<string>()
        {
            "val0", "val1", "val2", "val3"
        };
        public IEnumerable<string> Get()
        {
            return stringsList;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return stringsList[id];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            stringsList.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            stringsList[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            stringsList.RemoveAt(id);
        }
    }
}
