using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    
    public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
    {
        public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
        {

        }
        public override void Add(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyJobDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyJobDescriptionPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.JobName))
                {
                    exceptions.Add(new ValidationException(300, $"JobName cannot be Null or Empty - {poco.Id}"));

                }
                if (string.IsNullOrEmpty(poco.JobDescriptions))
                {
                    exceptions.Add(new ValidationException(301, $"JobDescriptions cannot be Null or Empty - {poco.Id}"));

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
