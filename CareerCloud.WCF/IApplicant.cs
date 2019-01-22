using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    interface IApplicant
    {
        #region ApplicantEducationPoco
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] pocos);

        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] pocos);

        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] pocos);

        [OperationContract]
        List<ApplicantEducationPoco> GetAllApplicantEducation();

        [OperationContract]
        //ApplicantEducationPoco GetSingleApplicantEducation(Guid id);
        ApplicantEducationPoco GetSingleApplicantEducation(string id);
        #endregion ApplicantEducationPoco

        #region ApplicantProfilePoco
        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] pocos);

        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] pocos);

        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] pocos);

        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();

        [OperationContract]
       // ApplicantProfilePoco GetSingleApplicantProfile(Guid id);
        ApplicantProfilePoco GetSingleApplicantProfile(string id);
        #endregion ApplicantProfilePoco

        #region ApplicantJobApplicationPoco
        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();

        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string id);
        #endregion ApplicantJobApplicationPoco

        #region ApplicantWorkHistoryPoco
        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();

        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string id);
        #endregion ApplicantWorkHistoryPoco

        #region ApplicantSkillPoco
        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] pocos);

        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] pocos);

        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] pocos);

        [OperationContract]
        List<ApplicantSkillPoco> GetAllApplicantSkill();

        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(string id);
        #endregion ApplicantSkillPoco

        #region ApplicantResumePoco
        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] pocos);

        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] pocos);

        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] pocos);

        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();

        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(string id);
        #endregion ApplicantResumePoco

    }

}
