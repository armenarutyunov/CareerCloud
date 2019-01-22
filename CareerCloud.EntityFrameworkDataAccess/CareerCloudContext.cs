using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext: DbContext
    {

        public CareerCloudContext(bool createProxy = true) : base(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString)
        {
            Configuration.ProxyCreationEnabled = createProxy;
            

        }
        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfile { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResume { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkill { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescription { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }
        public DbSet<CompanyJobPoco> CompanyJob { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkill { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocation { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfile { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
        public DbSet<SecurityRolePoco> SecurityRole { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCode { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCode { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Cancelation of Pluralization 
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Defining of Foregn Keys and Relationships "Many t0 One"

            //ApplicantProfilePoco
             modelBuilder.Entity<ApplicantProfilePoco>().HasMany(e => e.ApplicantEducations).WithRequired(e => e.ApplicantProfiles)
            .HasForeignKey(e => e.Applicant).WillCascadeOnDelete(false);
             modelBuilder.Entity<ApplicantProfilePoco>().HasMany(e => e.ApplicantJobApplications).WithRequired(e => e.ApplicantProfiles)
            .HasForeignKey(e => e.Applicant).WillCascadeOnDelete(false);
             modelBuilder.Entity<ApplicantProfilePoco>().HasMany(e => e.ApplicantWorkHistories).WithRequired(e => e.ApplicantProfiles)
            .HasForeignKey(e => e.Applicant).WillCascadeOnDelete(false);
             modelBuilder.Entity<ApplicantProfilePoco>().HasMany(e => e.ApplicantSkills).WithRequired(e => e.ApplicantProfiles)
            .HasForeignKey(e => e.Applicant).WillCascadeOnDelete(false);
             modelBuilder.Entity<ApplicantProfilePoco>().HasMany(e => e.ApplicantResumes).WithRequired(e => e.ApplicantProfiles)
            .HasForeignKey(e => e.Applicant).WillCascadeOnDelete(false);

            //CompanyJobPoco
            modelBuilder.Entity<CompanyJobPoco>().HasMany(e => e.ApplicantJobApplications).WithRequired(e => e.CompanyJobs)
           .HasForeignKey(e => e.Job).WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyJobPoco>().HasMany(e => e.CompanyJobDescriptions).WithRequired(e => e.CompanyJobs)
           .HasForeignKey(e => e.Job).WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyJobPoco>().HasMany(e => e.CompanyJobEducations).WithRequired(e => e.CompanyJobs)
           .HasForeignKey(e => e.Job).WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyJobPoco>().HasMany(e => e.CompanyJobSkills).WithRequired(e => e.CompanyJobs)
           .HasForeignKey(e => e.Job).WillCascadeOnDelete(false);

            //CompanyProfilePoco
            modelBuilder.Entity<CompanyProfilePoco>().HasMany(e => e.CompanyDescriptions).WithRequired(e => e.CompanyProfiles)
           .HasForeignKey(e => e.Company).WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyProfilePoco>().HasMany(e => e.CompanyJobs).WithRequired(e => e.CompanyProfiles)
           .HasForeignKey(e => e.Company).WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyProfilePoco>().HasMany(e => e.CompanyLocations).WithRequired(e => e.CompanyProfiles)
           .HasForeignKey(e => e.Company).WillCascadeOnDelete(false);
           

            //SecurityLoginsPoco
            modelBuilder.Entity<SecurityLoginPoco>().HasMany(e => e.SecurityLoginsRoles).WithRequired(e => e.SecurityLogins)
           .HasForeignKey(e => e.Login).WillCascadeOnDelete(false);
            modelBuilder.Entity<SecurityLoginPoco>().HasMany(e => e.SecurityLoginsLogs).WithRequired(e => e.SecurityLogins)
           .HasForeignKey(e => e.Login).WillCascadeOnDelete(false);
            modelBuilder.Entity<SecurityLoginPoco>().HasMany(e => e.ApplicantProfiles).WithRequired(e => e.SecurityLogins)
           .HasForeignKey(e => e.Login).WillCascadeOnDelete(false);

            //SystemCountryCodePoco
            modelBuilder.Entity<SystemCountryCodePoco>().HasMany(e => e.ApplicantProfiles).WithRequired(e => e.SystemCountryCodes)
           .HasForeignKey(e => e.Country).WillCascadeOnDelete(false);
            modelBuilder.Entity<SystemCountryCodePoco>().HasKey(d => d.Code);

            //SystemLanguageCodePoco
            modelBuilder.Entity<SystemLanguageCodePoco>().HasMany(e => e.CompanyDescriptions).WithRequired(e => e.SystemLanguageCodes)
           .HasForeignKey(e => e.LanguageId).WillCascadeOnDelete(false);
            modelBuilder.Entity<SystemLanguageCodePoco>().HasKey(d => d.LanguageID);

            //SecurityRolePoco
            modelBuilder.Entity<SecurityRolePoco>().HasMany(e => e.SecurityLoginsRoles).WithRequired(e => e.SecurityRoles)
           .HasForeignKey(e => e.Role).WillCascadeOnDelete(false);

            //Ignore of Time_Stamp field
            modelBuilder.Entity<ApplicantEducationPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<ApplicantJobApplicationPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<ApplicantProfilePoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<ApplicantSkillPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<CompanyDescriptionPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<CompanyJobEducationPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<CompanyJobSkillPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<CompanyJobPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<CompanyJobDescriptionPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<CompanyLocationPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<SecurityLoginPoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<CompanyProfilePoco>().Ignore(t => t.TimeStamp);
            modelBuilder.Entity<SecurityLoginsRolePoco>().Ignore(t => t.TimeStamp);


            base.OnModelCreating(modelBuilder);
        }
    }
}

