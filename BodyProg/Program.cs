using CareerCloud.ADODataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyProg
{
    class Program : BaseADO
    {
        
        static void Main(string[] args)
        {
            //protected int hh = ff;
            //SqlCommand sqlCom = new SqlCommand("select * from Applicant_Profiles", _connection);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            SqlCommand sqlCom = new SqlCommand("select * from Applicant_Profiles", conn);
            conn.Open();
            SqlDataReader rdr = sqlCom.ExecuteReader();
            
            Guid[] ar = new Guid[1000];
            int i = 0;
            while (rdr.Read())
            {
                ar[i] = rdr.GetGuid(0);
                i++;
            }
            conn.Close();

            ApplicantEducationRepository repo = new ApplicantEducationRepository();

            ApplicantEducationPoco poco = new ApplicantEducationPoco();
            


            ApplicantEducationPoco[] Row = new ApplicantEducationPoco[] { poco };

            Console.WriteLine($"(ddd = {0})", Row[0].Id);
            
            Row[0].Id = Guid.NewGuid();
            Row[0].Applicant = ar[0];
            Row[0].Major = "sjsjsjs";
            Row[0].CertificateDiploma = "Diplom MSU";
            Row[0].StartDate = DateTime.Now;
            Row[0].CompletionDate = DateTime.Now;
            Row[0].CompletionPercent = 99;
            Console.WriteLine(String.Format("Id ={0} Applicant = {1} \nMajor = {2} CerDip = {3} StartDate = {4} CompDate = {5} CompPro = {6}",
            Row[0].Id,Row[0].Applicant,Row[0].Major,Row[0].CertificateDiploma,Row[0].StartDate,Row[0].CompletionDate,Row[0].CompletionPercent));
            Console.ReadLine();
           // repo.Add(Row);
        }
    }
}
