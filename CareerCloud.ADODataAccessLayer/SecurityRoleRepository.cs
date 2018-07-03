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
    public class SecurityRoleRepository : BaseADO, IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                int rowsEffected = 0;
                foreach (SecurityRolePoco poco in items)
                {

                    _connection.Open();
                    cmd.CommandText = @"INSERT INTO Security_Roles 
                        ( Id,Role,Is_Inactive ) Values 
                        (@Id, @Role, @Is_Inactive)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
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

        public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            IList<SecurityRolePoco> pocos = new SecurityRolePoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"Select * from Security_Roles";
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    SecurityRolePoco poco = new SecurityRolePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Role = reader.GetString(1);
                    poco.IsInactive = reader.GetBoolean(2);
                    
                    pocos[position] = poco;
                    position++;

                }

                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                foreach (SecurityRolePoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from Security_Roles where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"Update Security_Roles Set" +
                    "  Role = @Role, Is_Inactive = @Is_Inactive where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
    }
}
