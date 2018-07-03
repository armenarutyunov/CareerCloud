using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    
   public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
        {

        }
        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (ApplicantSkillPoco poco in pocos)
            {
                //if (string.IsNullOrEmpty(poco.Major))
                //{
                //    exceptions.Add(new ValidationException(107, $"Cannot be empty or less than 3 characters - {poco.Id}"));

                //}
                //else
                if ((int)poco.StartMonth > 12)
                {
                    exceptions.Add(new ValidationException(101, $"StartMonth Cannot be greater than 12 - {poco.Id}"));
                }
                if ((int)poco.EndMonth > 12)
                {
                    exceptions.Add(new ValidationException(102, $"EndMonth Cannot be greater than 12 - {poco.Id}"));
                }
                if (poco.StartYear < 1900 )
                {
                    exceptions.Add(new ValidationException(103, $"StartYear Cannot be less then 1900 - {poco.Id}"));

                }
                if (poco.EndYear < poco.StartYear)
                {
                    exceptions.Add(new ValidationException(104, $"EndYear Cannot be less then StartYear - {poco.Id}"));

                }

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
