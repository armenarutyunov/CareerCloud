using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantResumeRepository : BaseADO , IDataRepository<ApplicantResumePoco>
    {
        
        public void Add(params ApplicantResumePoco[] items)
        {
          using(SqlConnection _connection = new SqlConnection(conn))
          {
                
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            int rowsEffected = 0;

            foreach (ApplicantResumePoco poco in items)
            {

                _connection.Open();
                cmd.CommandText = @"INSERT INTO  Applicant_Resumes
                        ( Id, Applicant, Resume, Last_Updated) Values 
                        (@Id, @Applicant,@Resume,@Last_Updated)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                cmd.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);
                
                rowsEffected += cmd.ExecuteNonQuery();
                _connection.Close();


             }
          }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IList<ApplicantResumePoco> pocos = new ApplicantResumePoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {


                SqlCommand cmd = new SqlCommand();
                SqlConnection _connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

                cmd.Connection = _connection1;
                cmd.CommandText = @"Select * from Applicant_Resumes ";
                _connection1.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    ApplicantResumePoco poco = new ApplicantResumePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Resume = reader.GetString(2);
                    // poco.LastUpdated = (DateTime?)reader["Last_Updated"];
                    if (reader[3] == DBNull.Value) { poco.LastUpdated = null; } else { poco.LastUpdated = (DateTime?)reader[3]; }                   

                    pocos[position] = poco; 
                    position++;

                }

                _connection1.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {

                IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {


                foreach (ApplicantResumePoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from Applicant_Resumes where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }


            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (ApplicantResumePoco poco in items)
                {
                    cmd.CommandText = @"update Applicant_Resumes set " +
                    "Applicant = @Applicant, Resume=@Resume, Last_Updated = @Last_Updated " +
                    " where Id = @Id";

                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
        
    }
}
