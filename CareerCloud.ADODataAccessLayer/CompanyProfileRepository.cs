using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyProfileRepository : BaseADO,IDataRepository<CompanyProfilePoco>
    { 
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                int rowsEffected = 0;
                foreach (CompanyProfilePoco poco in items)
                {

                    _connection.Open();
                    cmd.CommandText = @"INSERT INTO Company_Profiles 
                        ( Id, Registration_Date, Company_Website, Contact_Phone, Contact_Name, Company_Logo) Values 
                        (@Id, @Registration_Date, @Company_Website, @Contact_Phone, @Contact_Name, @Company_Logo)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);

                    rowsEffected += cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IList<CompanyProfilePoco> pocos = new CompanyProfilePoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"Select * from Company_Profiles";
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    CompanyProfilePoco poco = new CompanyProfilePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.RegistrationDate = (DateTime)reader[1];
                    poco.CompanyWebsite = (reader[2] == DBNull.Value)? null : reader.GetString(2);
                    poco.ContactPhone = reader.GetString(3);
                    poco.ContactName = (reader[4]==DBNull.Value)? null : reader.GetString(4);
                    poco.CompanyLogo = (reader[5]==DBNull.Value)? null :  (byte[])reader[5];
                    poco.TimeStamp = (byte[])reader[6];

                    pocos[position] = poco;
                    position++;

                }

                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                foreach (CompanyProfilePoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from Company_Profiles where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (CompanyProfilePoco poco in items)
                {
                    cmd.CommandText = @"update Company_Profiles set " +
                    " Registration_Date = @Registration_Date, Company_Website = @Company_Website, Contact_Phone =  @Contact_Phone, Contact_Name = @Contact_Name, Company_Logo = @Company_Logo" +
                    " where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
    }
}
