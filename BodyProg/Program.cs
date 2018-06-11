using CareerCloud.ADODataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BodyProg
{
    class Program 
    {
        
        static void Main(string[] args)
        {
           
            

            ApplicantEducationRepository repo = new ApplicantEducationRepository();
            ApplicantEducationPoco poco = new ApplicantEducationPoco();
            ApplicantEducationPoco[] Row = new ApplicantEducationPoco[] { poco };
          
           /*
           
           // Row[0].Id = Guid.NewGuid();
            Row[0].Id = Guid.Parse("19D865A4-1CCD-0F2D-A757-0518E0B5E4A6");
            Row[0].Applicant =Guid.Parse("1FC2F63C-08B1-7630-3858-00A0E7C57734");
            Row[0].Major = "Superman";
            Row[0].CertificateDiploma = "Diplom MSU";
            Row[0].StartDate = DateTime.Now;
            Row[0].CompletionDate = DateTime.Now;
            Row[0].CompletionPercent = 99;
            Console.WriteLine(String.Format("Id ={0} Applicant = {1} \nMajor = {2} CerDip = {3} StartDate = {4} CompDate = {5} CompPro = {6}",
            Row[0].Id,Row[0].Applicant,Row[0].Major,Row[0].CertificateDiploma,Row[0].StartDate,Row[0].CompletionDate,Row[0].CompletionPercent));
            Console.ReadLine();

            //repo.Remove(Row);
            // repo.Add(Row);
            //repo.Update(Row);
            ApplicantEducationPoco Ro = repo.GetSingle(t => t.Id == Row[0].Id);
            Console.WriteLine(String.Format("Id ={0} Applicant = {1} \nMajor = {2} CerDip = {3} StartDate = {4} CompDate = {5} CompPro = {6}",
            Ro.Id, Ro.Applicant, Ro.Major, Ro.CertificateDiploma, Ro.StartDate, Ro.CompletionDate, Ro.CompletionPercent));
            Console.ReadLine();
            */
        }
    }
}
