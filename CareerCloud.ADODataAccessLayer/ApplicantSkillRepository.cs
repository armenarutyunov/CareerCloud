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
    public class ApplicantSkillRepository : BaseADO , IDataRepository<ApplicantSkillPoco>
    {
 
        public void Add(params ApplicantSkillPoco[] items)
        {
          using(SqlConnection _connection = new SqlConnection(conn))
          { 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            int rowsEffected = 0;

                foreach (ApplicantSkillPoco poco in items)
                {

                        _connection.Open();
                        cmd.CommandText = @"INSERT INTO Applicant_Skills  
                   ( Id, Applicant, Skill, Skill_Level, Start_Month, Start_Year, End_Month, End_Year) Values 
                   ( @Id, @Applicant, @Skill, @Skill_Level, @Start_Month, @Start_Year, @End_Month, @End_Year)";

                        cmd.Parameters.AddWithValue("@Id", poco.Id);
                        cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                        cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                        cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                        cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                        cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                        cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);

                        rowsEffected += cmd.ExecuteNonQuery();
                        _connection.Close();

                }
          } 
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IList<ApplicantSkillPoco> pocos = new ApplicantSkillPoco[1000];

            using (SqlConnection _connection = new SqlConnection(conn))
            {


                SqlCommand cmd = new SqlCommand();
                SqlConnection _connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

                cmd.Connection = _connection1;
                cmd.CommandText = @"Select * from Applicant_Skills";
                _connection1.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {

                    ApplicantSkillPoco poco = new ApplicantSkillPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Skill = reader.GetString(2);
                    poco.SkillLevel = reader.GetString(3);
                    poco.StartMonth = reader.GetByte(4);
                    poco.StartYear = (Int32)reader[5];
                    poco.EndMonth = reader.GetByte(6);
                    poco.EndYear = (Int32)reader[7];
                    poco.TimeStamp = (byte[])reader[8];

                    pocos[position] = poco;
                    position++;

                }

                _connection1.Close();
            }
            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {

                IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
                return pocos.Where(where).FirstOrDefault();
            }
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {


                foreach (ApplicantSkillPoco poco in items)
                {
                    _connection.Open();
                    SqlCommand RemRow = new SqlCommand();
                    RemRow.Connection = _connection;
                    RemRow.CommandText = @"delete from Applicant_Skills where Id = @Id";
                    RemRow.Parameters.AddWithValue("@Id", poco.Id);
                    RemRow.ExecuteNonQuery();
                    _connection.Close();
                }


            }
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection _connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                _connection.Open();
                foreach (ApplicantSkillPoco poco in items)
                {
                    cmd.CommandText = @"update Applicant_Skills set " +

                    
              "Applicant = @Applicant, Skill = @Skill, Skill_Level = @Skill_Level, Start_Month = @Start_Month, " +
              "Start_Year = @Start_Year, End_Month = @End_Month, End_Year = @End_Year where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);

                    cmd.ExecuteNonQuery();

                }
                _connection.Close();

            }
        }
      
    }
}
