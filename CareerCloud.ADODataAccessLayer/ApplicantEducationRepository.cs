using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : BaseADO,  IDataRepository<ApplicantEducationPoco>
    {
       

        public void Add(params ApplicantEducationPoco[] items)
        {
            //The command "using" is replacing the set of commands Try {_connection.Open();} Cath {_connection.Close();}
                using(SqlConnection _connection = new SqlConnection(conn))
                { 
                
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = _connection;
                        int rowsEffected = 0;
                        foreach (ApplicantEducationPoco poco in items)
                        {

                        _connection.Open();
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
                            _connection.Close();
                        }
                }
        }
        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IList<ApplicantEducationPoco> pocos = new ApplicantEducationPoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"Select * from Applicant_Educations";
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

               _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
           
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
               return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                foreach (ApplicantEducationPoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText =     @"delete from Applicant_Educations where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using(SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"update Applicant_Educations set " +
                    "Applicant = @Applicant, Major=@Major, Certificate_Diploma = @Certificate_Diploma, Start_Date= @Start_Date, Completion_Date= " +
                    "@Completion_Date, Completion_Percent = @Completion_Percent where Id = @Id";

                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
 
        }
    }
}
