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
    public class ApplicantJobApplicationRepository : BaseADO, IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                int rowsEffected = 0;

                foreach (ApplicantJobApplicationPoco poco in items)
                {

                    _connection.Open();
                    cmd.CommandText = @"INSERT INTO Applicant_Job_Applications 
                       ( Id, Applicant, Job, Application_Date ) Values 
                       ( @Id, @Applicant, @Job, @Application_Date )";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);
                    rowsEffected += cmd.ExecuteNonQuery();
                    _connection.Close();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            //ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];
            IList<ApplicantJobApplicationPoco> pocos = new ApplicantJobApplicationPoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {


                SqlCommand cmd = new SqlCommand();
                SqlConnection _connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                cmd.Connection = _connection1;
                //cmd.Connection = _connection;
                cmd.CommandText = @"Select * from Applicant_Job_Applications";
                _connection1.Open();
                //_connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Job = reader.GetGuid(2);
                    poco.ApplicationDate = (DateTime)reader[3];
                    poco.TimeStamp = (byte[])reader[4];
                    pocos[position] = poco;
                    position++;
                   
                }
                _connection1.Close();
                //_connection.Close();
             }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {


                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from Applicant_Job_Applications where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }


            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (ApplicantJobApplicationPoco poco in items)
                {
                    cmd.CommandText = @"update Applicant_Job_Applications set " +


                       "Applicant = @Applicant, Job = @Job, Application_Date = @Application_Date where Id=@Id";
                     
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
    }
}
