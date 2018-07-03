using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    
   public class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
    {
        public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : base(repository)
        {

        }
        public override void Add(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantResumePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (ApplicantResumePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Resume))
                {
                    exceptions.Add(new ValidationException(113, $"Resume cannot be empty - {poco.Id}"));

                }
                //else
                //if (poco.Major.Length < 3)
                //{
                //    exceptions.Add(new ValidationException(107, $"Cannot be empty or less than 3 characters - {poco.Id}"));
                //}
                //if (poco.StartDate > DateTime.Now)
                //{
                //    exceptions.Add(new ValidationException(108, $"Cannot be greater than today - {poco.Id}"));

                //}
                //if (poco.CompletionDate < poco.StartDate)
                //{
                //    exceptions.Add(new ValidationException(109, $"CompletionDate cannot be earlier than StartDate - {poco.Id}"));

                //}

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
