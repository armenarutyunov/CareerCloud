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
    public class SecurityLoginRepository : BaseADO, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                int rowsEffected = 0;
                foreach (SecurityLoginPoco poco in items)
                {

                    _connection.Open();
                    cmd.CommandText = @"INSERT INTO Security_Logins 
                    ( Id, Login, Password, Created_Date, Password_Update_Date, Agreement_Accepted_Date, Is_Locked, Is_Inactive,
                     Email_Address, Phone_Number, Full_Name, Force_Change_Password, Prefferred_Language) Values  
                    (@Id, @Login, @Password, @Created_Date, @Password_Update_Date, @Agreement_Accepted_Date, @Is_Locked, @Is_Inactive,
                     @Email_Address, @Phone_Number, @Full_Name, @Force_Change_Password, @Prefferred_Language)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);

                    rowsEffected += cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IList<SecurityLoginPoco> pocos = new SecurityLoginPoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = @"Select * from Security_Logins";
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    SecurityLoginPoco poco = new SecurityLoginPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetString(1);
                    poco.Password = reader.GetString(2);
                    poco.Created = (DateTime)reader[3];
                    poco.PasswordUpdate = (reader[4]==DBNull.Value)? null :(DateTime?)reader[4];
                    poco.AgreementAccepted = (reader[5] == DBNull.Value) ? null : (DateTime?)reader[5];
                    poco.IsLocked = reader.GetBoolean(6);
                    poco.IsInactive = reader.GetBoolean(7);
                    poco.EmailAddress = reader.GetString(8);
                    poco.PhoneNumber = (reader[9]==DBNull.Value)? null : reader.GetString(9);
                    poco.FullName = (reader[10] == DBNull.Value) ? null : reader.GetString(10);
                    poco.ForceChangePassword = reader.GetBoolean(11);
                    poco.PrefferredLanguage = (reader[12]==DBNull.Value)? null : reader.GetString(12);
                    poco.TimeStamp = (byte[])reader[13];

                    pocos[position] = poco;
                    position++;

                }

                _connection.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                foreach (SecurityLoginPoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from Security_Logins where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (SecurityLoginPoco poco in items)
                {
                    cmd.CommandText = @"update Security_Logins set " +
                    " Login = @Login,Password = @Password, Created_Date = @Created_Date,Password_Update_Date = @Password_Update_Date, Agreement_Accepted_Date = @Agreement_Accepted_Date, " +
                    "Is_Locked = @Is_Locked, Is_Inactive = @Is_Inactive, Email_Address = @Email_Address, Phone_Number = @Phone_Number, Full_Name = @Full_Name,Force_Change_Password = @Force_Change_Password,"+
                    "Prefferred_Language =  @Prefferred_Language"+
                    " where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);

                    

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
    }
}
