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
    public class SecurityLoginsLogRepository : BaseADO, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                int rowsEffected = 0;
                foreach (SecurityLoginsLogPoco poco in items)
                {

                    _connection.Open();
                    cmd.CommandText = @"INSERT INTO Security_Logins_Log 
                        ( Id, Login,Source_IP, Logon_Date, Is_Succesful) Values 
                        (@Id, @Login, @Source_IP, @Logon_Date, @Is_Succesful)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);
                   
                    rowsEffected += cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginsLogPoco> pocos = new SecurityLoginsLogPoco[2000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"Select * from Security_Logins_Log";
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetGuid(1);
                    poco.SourceIP= reader.GetString(2);
                    poco.LogonDate = (DateTime)reader[3];
                    poco.IsSuccesful = reader.GetBoolean(4);
                    
                    pocos[position] = poco;
                    position++;

                }

                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from Security_Logins_Log where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (SecurityLoginsLogPoco poco in items)
                {
                    cmd.CommandText = @"Update Security_Logins_Log Set" +
                    " Login = @Login, Source_IP = @Source_IP, Logon_Date =  @Logon_Date, Is_Succesful = @Is_Succesful" +
                    " where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
    } 
}
