using MatricResultsFinal.DataBase;
using MatricResultsFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace MatricResultsFinal.Controllers
{
    public class MatricresultsController : ApiController
    {
      
        // GET: api/Matricresults
        public IEnumerable<MatricResultsModel> Get()
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.connectToDataBase();

            return dbManager.getAllMatricResults();
        }

        // GET: api/Matricresults/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Matricresults
      
        public void Post([FromBody] string jsonString)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.connectToDataBase();

            var js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;

            List<MatricResultsModel> lsDeSerialise = js.Deserialize<List<MatricResultsModel>>(jsonString);

            if (lsDeSerialise.Count > 0)
                dbManager.insertIntoDatabase(lsDeSerialise);
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
