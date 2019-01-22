using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
   
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {

        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyProfilePoco poco in pocos)
            {
               
               
                if (string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, $"Valid Website Cannot be empty and  must end with the following extensions – '.ca', '.com', '.biz' - {poco.Id}"));
                }

                else
                {
                    string s = poco.CompanyWebsite;
                    int l = s.Length;
                    int lofd = s.LastIndexOf(".");
                    if (lofd < 1)
                    {
                        exceptions.Add(new ValidationException(600, $"Valid Website Cannot be empty and  must end with the following extensions – '.ca', '.com', '.biz' - {poco.Id}"));
                    }
                    else
                    {
                        if (s.Substring(lofd, l - lofd) != ".ca" & s.Substring(lofd, l - lofd) != ".com" & s.Substring(lofd, l - lofd) != ".biz")
                        {
                            exceptions.Add(new ValidationException(600, $"Valid Website Cannot be empty and  must end with the following extensions – '.ca', '.com', '.biz' - {poco.Id}"));

                        }
                    }
                }
                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, $"Valid ContactPhone Cannot be empty and Must correspond to a format (e.g. 416-555-1234) - {poco.Id}"));
                }

                else
                {
                    string p = poco.ContactPhone;
                    int pl = p.Length;
                    int lofd = p.LastIndexOf("-");
                    int fofd = p.IndexOf("-");
                    if (fofd !=3 || lofd!=7)
                    {
                        exceptions.Add(new ValidationException(601, $"Valid ContactPhone Cannot be empty and Must correspond to a format (e.g. 416-555-1234) - {poco.Id}"));
                    }
                    else
                    {
                        var k = Convert.ToInt64(9999999999);
                        try
                        { string d = p.Substring(0, 3) + p.Substring(4, 3) + p.Substring(8, pl-8);
                          k = Convert.ToInt64(d);
                        }
                        catch
                        {
                            exceptions.Add(new ValidationException(601, $"Valid ContactPhone Cannot be empty and Must correspond to a format (e.g. 416-555-1234) - {poco.Id}"));
                        }
                        if (9999999999 < k || k < 1000000000)
                        {
                            exceptions.Add(new ValidationException(601, $"Valid ContactPhone Cannot be empty and Must correspond to a format (e.g. 416-555-1234) - {poco.Id}"));
                        }
                    }
                }


                 
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
