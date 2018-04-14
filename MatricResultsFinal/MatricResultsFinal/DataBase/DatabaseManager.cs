using MatricResultsFinal.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MatricResultsFinal.DataBase
{
    public class DatabaseManager
    {
        private NpgsqlConnection connection = new NpgsqlConnection();
        public void connectToDataBase() {

            string connString = "User ID=nmfrmlfzvaomjq;Password=85c27333ccf49ce60f2fd5a7a67182b743f2658ad731041f0b58e453b031b27f;Host=ec2-79-125-110-209.eu-west-1.compute.amazonaws.com; " +
              "Port=5432;Database=d9hbor8egpger2;Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True;";

            connection = new NpgsqlConnection(connString);
            connection.Open();
        
        }

        public void insertIntoDatabase(List<MatricResultsModel> lsMatricResultsModel)
        {

            List<MatricResultsModel> lsAllExistingMatricResults = this.getAllMatricResults();
            this.connectToDataBase();

            List<MatricResultsModel> lsShouldAdd = new List<MatricResultsModel>();

            //check if school data already exists 
            foreach(MatricResultsModel newMatricResultsModel in lsMatricResultsModel)
            {
                foreach(MatricResultsModel currentMatricResultsModel in lsAllExistingMatricResults)
                {
                    if (currentMatricResultsModel.NameOfSchool.ToLower() == newMatricResultsModel.NameOfSchool.ToLower())
                        continue;
                }

                lsShouldAdd.Add(newMatricResultsModel);
            }


            string sql = "insert into MatricResultsTbl (id , nameofschool , emis , centerno , wrote2014 , passed2014 , wrote2015 , passed2015 , wrote2016, passed2016 ) " +
                "values " ;

            foreach(MatricResultsModel matricResultsModel in lsShouldAdd)
            {
                sql += " ( default , '" + matricResultsModel.NameOfSchool + "' , " + matricResultsModel.Emis + " , " + matricResultsModel.CenterNo + " , " + matricResultsModel.Wrote2014 + "," + matricResultsModel.Passed2014 +
                    " , " + matricResultsModel.Wrote2015 + "," + matricResultsModel.Passed2015 + "," + matricResultsModel.Wrote2016 + "," + matricResultsModel.PassRate2016 + ") ,";
            }

            sql = sql.Remove(sql.LastIndexOf(","), 1);


            if(lsShouldAdd.Count> 0)
            {
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
          
            connection.Close();
        }

        public List<MatricResultsModel> getAllMatricResults()
        {
            List<MatricResultsModel> lsMatricResultsModel = new List<MatricResultsModel>();

            string sql = "SELECT * FROM MatricResultsTbl";
            // data adapter making request from our connection

            NpgsqlCommand command = new NpgsqlCommand(sql, connection);

            // Execute the query and obtain a result set
            NpgsqlDataReader reader = command.ExecuteReader();
            List<Dictionary<String, Object>> objectList = new List<Dictionary<string, object>>();

            // Output rows
            while (reader.Read())
            {
                Dictionary<String, Object> dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string field = reader.GetName(i).ToString();
                    object o = reader.GetValue(i);
                    dict.Add(field, o);
                }
                objectList.Add(dict);
            }
            // clean up
            reader.Close();
            reader = null;
            command.Dispose();

            connection.Close();

            foreach(Dictionary<String, Object> dict in objectList)
            {
                MatricResultsModel matricResultsModel = new MatricResultsModel();
                matricResultsModel.NameOfSchool = dict["nameofschool"] != System.DBNull.Value ? dict["nameofschool"].ToString() : "";
                matricResultsModel.Wrote2014 = dict["wrote2014"] != System.DBNull.Value? Convert.ToInt32(dict["wrote2014"]) : 0;
                matricResultsModel.Passed2014 = dict["passed2014"] != System.DBNull.Value ? Convert.ToInt32(dict["passed2014"]) : 0;
                matricResultsModel.Wrote2015 = dict["wrote2015"] != System.DBNull.Value ? Convert.ToInt32(dict["wrote2015"]) : 0;
                matricResultsModel.Passed2015 = dict["passed2015"] != System.DBNull.Value ? Convert.ToInt32(dict["passed2015"]) : 0;
                matricResultsModel.Wrote2016 = dict["wrote2016"] != System.DBNull.Value ? Convert.ToInt32(dict["wrote2016"]) : 0;
                matricResultsModel.Passed2016 = dict["passed2016"] != System.DBNull.Value ? Convert.ToInt32(dict["passed2016"]) : 0;
                matricResultsModel.CenterNo = dict["centerno"] != System.DBNull.Value ? Convert.ToInt32(dict["centerno"]) : 0;
                matricResultsModel.Emis = dict["emis"] != System.DBNull.Value ? Convert.ToInt32(dict["emis"]) : 0;

                matricResultsModel.populatePassRates();
                lsMatricResultsModel.Add(matricResultsModel);

            }

            return lsMatricResultsModel;



        }
    
    }
}