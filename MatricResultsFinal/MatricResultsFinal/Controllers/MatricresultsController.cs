using MatricResultsFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MatricResultsFinal.Controllers
{
    public class MatricresultsController : ApiController
    {
        MatricResultsModel[] test = new MatricResultsModel[]
        {
                new MatricResultsModel { Emis = 20  }
        };

        // GET: api/Matricresults
        public IEnumerable<MatricResultsModel> Get()
        {
            return test;
        }

        // GET: api/Matricresults/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Matricresults
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Matricresults/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Matricresults/5
        public void Delete(int id)
        {
        }
    }
}
