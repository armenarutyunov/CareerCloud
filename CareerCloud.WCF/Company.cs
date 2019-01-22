﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    class Company : ICompany
    {
        
        #region Add
        public void AddCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            CompanyDescriptionLogic logic = new CompanyDescriptionLogic(repo);
            logic.Add(pocos);
        }

        public void AddCompanyJob(CompanyJobPoco[] pocos)
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>(false);
            CompanyJobLogic logic = new CompanyJobLogic(repo);
            logic.Add(pocos);
        }

        public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
            CompanyJobDescriptionLogic logic = new CompanyJobDescriptionLogic(repo);
            logic.Add(pocos);
        }

        public void AddCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>(false);
            CompanyJobEducationLogic logic = new CompanyJobEducationLogic(repo);
            logic.Add(pocos);
        }

        public void AddCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>(false);
            CompanyJobSkillLogic logic = new CompanyJobSkillLogic(repo);
            logic.Add(pocos);
        }

        public void AddCompanyLocation(CompanyLocationPoco[] pocos)
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>(false);
            CompanyLocationLogic logic = new CompanyLocationLogic(repo);
            logic.Add(pocos);
        }

        public void AddCompanyProfile(CompanyProfilePoco[] pocos)
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>(false);
            CompanyProfileLogic logic = new CompanyProfileLogic(repo);
            logic.Add(pocos);
        }
        #endregion Add
        #region GetAll

        public List<CompanyDescriptionPoco> GetAllCompanyDescription()
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            CompanyDescriptionLogic logic = new CompanyDescriptionLogic(repo);
            return logic.GetAll();
        }

        public List<CompanyJobPoco> GetAllCompanyJob()
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>(false);
            CompanyJobLogic logic = new CompanyJobLogic(repo);
            return logic.GetAll();
        }

        public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
            CompanyJobDescriptionLogic logic = new CompanyJobDescriptionLogic(repo);
            return logic.GetAll();
        }

        public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>(false);
            CompanyJobEducationLogic logic = new CompanyJobEducationLogic(repo);
            return logic.GetAll();
        }

        public List<CompanyJobSkillPoco> GetAllCompanyJobSkill()
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>(false);
            CompanyJobSkillLogic logic = new CompanyJobSkillLogic(repo);
            return logic.GetAll();
        }

        public List<CompanyLocationPoco> GetAllCompanyLocation()
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>(false);
            CompanyLocationLogic logic = new CompanyLocationLogic(repo);
            return logic.GetAll();
        }

        public List<CompanyProfilePoco> GetAllCompanyProfile()
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>(false);
            CompanyProfileLogic logic = new CompanyProfileLogic(repo);
            return logic.GetAll();
        }
        #endregion GetAll
        #region GetSingle
        public CompanyDescriptionPoco GetSingleCompanyDescription(string id)
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            CompanyDescriptionLogic logic = new CompanyDescriptionLogic(repo);
            return logic.Get(Guid.Parse(id));
        }

        public CompanyJobPoco GetSingleCompanyJob(string id)
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>(false);
            CompanyJobLogic logic = new CompanyJobLogic(repo);
            return logic.Get(Guid.Parse(id));
        }

        public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string id)
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
            CompanyJobDescriptionLogic logic = new CompanyJobDescriptionLogic(repo);
            return logic.Get(Guid.Parse(id));
        }

        public CompanyJobEducationPoco GetSingleCompanyJobEducation(string id)
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>(false);
            CompanyJobEducationLogic logic = new CompanyJobEducationLogic(repo);
            return logic.Get(Guid.Parse(id));
        }

        public CompanyJobSkillPoco GetSingleCompanyJobSkill(string id)
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>(false);
            CompanyJobSkillLogic logic = new CompanyJobSkillLogic(repo);
            return logic.Get(Guid.Parse(id));
        }

        public CompanyLocationPoco GetSingleCompanyLocation(string id)
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>(false);
            CompanyLocationLogic logic = new CompanyLocationLogic(repo);
            return logic.Get(Guid.Parse(id));
        }

        public CompanyProfilePoco GetSingleCompanyProfile(string id)
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>(false);
            CompanyProfileLogic logic = new CompanyProfileLogic(repo);
            return logic.Get(Guid.Parse(id));
        }
        #endregion GetSingle
        #region Remove
        public void RemoveCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            CompanyDescriptionLogic logic = new CompanyDescriptionLogic(repo);
            logic.Delete(pocos);
        }

        public void RemoveCompanyJob(CompanyJobPoco[] pocos)
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>(false);
            CompanyJobLogic logic = new CompanyJobLogic(repo);
            logic.Delete(pocos);
        }

        public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
            CompanyJobDescriptionLogic logic = new CompanyJobDescriptionLogic(repo);
            logic.Delete(pocos);
        }

        public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>(false);
            CompanyJobEducationLogic logic = new CompanyJobEducationLogic(repo);
            logic.Delete(pocos);
        }

        public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>(false);
            CompanyJobSkillLogic logic = new CompanyJobSkillLogic(repo);
            logic.Delete(pocos);
        }

        public void RemoveCompanyLocation(CompanyLocationPoco[] pocos)
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>(false);
            CompanyLocationLogic logic = new CompanyLocationLogic(repo);
            logic.Delete(pocos);
        }

        public void RemoveCompanyProfile(CompanyProfilePoco[] pocos)
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>(false);
            CompanyProfileLogic logic = new CompanyProfileLogic(repo);
            logic.Delete(pocos);
        }
        #endregion Remove
        #region Update
        public void UpdateCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            CompanyDescriptionLogic logic = new CompanyDescriptionLogic(repo);
            logic.Update(pocos);
        }

        public void UpdateCompanyJob(CompanyJobPoco[] pocos)
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>(false);
            CompanyJobLogic logic = new CompanyJobLogic(repo);
            logic.Update(pocos);
        }

        public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
            CompanyJobDescriptionLogic logic = new CompanyJobDescriptionLogic(repo);
            logic.Update(pocos);
        }

        public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>(false);
            CompanyJobEducationLogic logic = new CompanyJobEducationLogic(repo);
            logic.Update(pocos);
        }

        public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>(false);
            CompanyJobSkillLogic logic = new CompanyJobSkillLogic(repo);
            logic.Update(pocos);
        }

        public void UpdateCompanyLocation(CompanyLocationPoco[] pocos)
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>(false);
            CompanyLocationLogic logic = new CompanyLocationLogic(repo);
            logic.Update(pocos);
        }

        public void UpdateCompanyProfile(CompanyProfilePoco[] pocos)
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>(false);
            CompanyProfileLogic logic = new CompanyProfileLogic(repo);
            logic.Update(pocos);
        }
        #endregion Update
    }
}
