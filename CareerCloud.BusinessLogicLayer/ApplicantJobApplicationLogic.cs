using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
   public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>

    {
        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
        {

        }
        public override void Add(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (ApplicantJobApplicationPoco poco in pocos)
            {
                //if (string.IsNullOrEmpty(poco.Major))
                //{
                //    exceptions.Add(new ValidationException(107, $"Cannot be empty or less than 3 characters - {poco.Id}"));

                //}
                //else
                //if (poco.Major.Length < 3)
                //{
                //    exceptions.Add(new ValidationException(107, $"Cannot be empty or less than 3 characters - {poco.Id}"));
                //}
                //if (poco.StartDate > DateTime.Now)
                //{
                //    exceptions.Add(new ValidationException(108, $"Cannot be greater than today - {poco.Id}"));

                //}
                if (poco.ApplicationDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(110, $"ApplicationDate cannot be greater than today - {poco.Id}"));

                }

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
