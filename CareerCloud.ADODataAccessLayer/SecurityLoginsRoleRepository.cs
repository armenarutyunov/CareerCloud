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
    public class SecurityLoginsRoleRepository : BaseADO, IDataRepository<SecurityLoginsRolePoco>
    {
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                int rowsEffected = 0;
                foreach (SecurityLoginsRolePoco poco in items)
                {

                    _connection.Open();
                    cmd.CommandText = @"INSERT INTO Security_Logins_Roles 
                        ( Id, Login, Role) Values 
                        (@Id, @Login, @Role)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);
                    
                    rowsEffected += cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginsRolePoco> pocos = new SecurityLoginsRolePoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"Select * from Security_Logins_Roles";
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetGuid(1);
                    poco.Role = reader.GetGuid(2);
                    poco.TimeStamp = (byte[])reader[3];
                    pocos[position] = poco;
                    position++;

                }

                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                foreach (SecurityLoginsRolePoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from Security_Logins_Roles where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (SecurityLoginsRolePoco poco in items)
                {
                    cmd.CommandText = @"update Security_Logins_Roles set " +
                    " Login = @Login, Role = @Role  where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
    }
}
