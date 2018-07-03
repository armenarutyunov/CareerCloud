using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
   public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {

        }
        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyDescriptionPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyDescription))
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription Cannot be empty and Must be greater than 2 characters - {poco.Id}"));

                }
                else
                if (poco.CompanyDescription.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription Cannot be empty and Must be greater than 2 characters - {poco.Id}"));
                }
                if (string.IsNullOrEmpty(poco.CompanyName))
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName Cannot be empty and Must be greater than 2 characters - {poco.Id}"));
                }
                else
               if (poco.CompanyName.Length < 3)
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName Cannot be empty and Must be greater than 2 characters - {poco.Id}"));
                }
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
