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

            List<Dictionary<string,object>> lsDeSerialise = js.Deserialize<List<Dictionary<string, object>>>(jsonString);
            List<MatricResultsModel> lsMatricResultsModel = new List<MatricResultsModel>();

            foreach (Dictionary<string, object> dict in lsDeSerialise )
            {
                MatricResultsModel matricResultsModel = new MatricResultsModel();
                matricResultsModel.Emis = Convert.ToInt32(dict["Emis"]);
                matricResultsModel.NameOfSchool =dict["NameOfSchool"].ToString();
                matricResultsModel.CenterNo = Convert.ToInt32(dict["CenterNo"]);
                matricResultsModel.Passed2014 = Convert.ToInt32(dict["Passed2014"]);
                matricResultsModel.Wrote2014 = Convert.ToInt32(dict["Wrote2014"]);
                matricResultsModel.Passed2015 = Convert.ToInt32(dict["Passed2015"]);
                matricResultsModel.Wrote2015 = Convert.ToInt32(dict["Wrote2015"]);
                matricResultsModel.Wrote2016 = Convert.ToInt32(dict["Wrote2016"]);
                matricResultsModel.Passed2016 = Convert.ToInt32(dict["Passed2016"]);

                lsMatricResultsModel.Add(matricResultsModel);

            }

            if (lsDeSerialise.Count > 0)
               dbManager.insertIntoDatabase(lsMatricResultsModel);
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
