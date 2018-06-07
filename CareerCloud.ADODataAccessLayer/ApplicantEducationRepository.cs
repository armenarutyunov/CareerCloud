using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : BaseADO,  IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            //The command "using" is replacing the set of commands Try {_connection.Open();} Cath {_connection.Close();

            using (_connection)
          { 
                //SqlConnection conn = new SqlConnection(_connString);
                //Inside of BaseADO we have created the instance of SqlConnection (_connection) and transmitted this value to
                // class ApplicantEducationRepository over Inheritance
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                int rowsEffected = 0;
            foreach (ApplicantEducationPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Applicant_Educations 
            ( Id, Applicant, Major, Certificate_Diploma, Start_Date, Completion_Date, Completion_Percent) Values 
            (@Id, @Applicant, @Major, @Certificate_Diploma, @Start_Date, @Completion_Date, @Completion_Percent)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Major", poco.Major);
                cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

               
              
                rowsEffected += cmd.ExecuteNonQuery();
            }
          }
        }
        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "Select * from Applicant_Educations";
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
               
                int position = 0;
                while (reader.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Major = reader.GetString(2);
                    poco.CertificateDiploma = reader.GetString(3);
                    poco.StartDate = (DateTime?)reader[4];
                    poco.CompletionDate = (DateTime?)reader[5];
                    poco.CompletionPercent = (byte?)reader["Completion_Percent"];
                    poco.TimeStamp = (byte[])reader[7];
                    pocos[position] = poco;
                    position++;

                }


            }
            return pocos;
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (_connection)
            {
                Guid[] TabId = new Guid[1000];
                int pos = 0;
                SqlCommand sqlCom = new SqlCommand("select * from Applicant_Profiles", _connection);
                _connection.Open();
                SqlDataReader rdr = sqlCom.ExecuteReader();
                while (rdr.Read())
                {
                    TabId[pos] = rdr.GetGuid(0);
                    pos++;
                }
                _connection.Close();
                string sqldel = String.Format("delete from Applicant_Profiles where Id = {0}", ApplicantEducationPoco[0]);
               SqlCommand RemRow = new SqlCommand($"(delete )",  + )
                Console.WriteLine($"(ddd = {0})", Row[0].Id);

                Guid[] ar = new Guid[1000];
            }
           
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
