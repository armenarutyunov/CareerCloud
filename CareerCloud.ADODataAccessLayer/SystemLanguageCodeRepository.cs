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
    public class SystemLanguageCodeRepository : BaseADO, IDataRepository<SystemLanguageCodePoco>
    {
        public void Add(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                int rowsEffected = 0;
                foreach (SystemLanguageCodePoco poco in items)
                {

                    _connection.Open();
                    cmd.CommandText = @"INSERT INTO System_Language_Codes 
                    (LanguageID, Name, Native_Name) Values 
                    (@LanguageID, @Name, @Native_Name)";
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);

                    rowsEffected += cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IList<SystemLanguageCodePoco> pocos = new SystemLanguageCodePoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"Select * from System_Language_Codes";
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
                    poco.LanguageID = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                    poco.NativeName = reader.GetString(2);
                        
                    pocos[position] = poco;
                    position++;

                }

                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                foreach (SystemLanguageCodePoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from System_Language_Codes where LanguageID = @LanguageID";
                    RemRow.Parameters.AddWithValue("@LanguageID", poco.LanguageID);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (SystemLanguageCodePoco poco in items)
                {
                    cmd.CommandText = @"update System_Language_Codes set " +
                    " Name = @Name, Native_Name = @Native_Name  where LanguageID = @LanguageID";

                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
    }
}
