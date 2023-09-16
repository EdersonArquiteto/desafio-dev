using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.CNAB.Domain.Validations.Base
{
    public static class GetValidations
    {
        public static Response GetErrors(this ValidationResult result)
        {
            var response = new Response();

            if (!result.IsValid)
            {
                foreach (var erro in result.Errors)
                {
                    response.Report.Add(new Report()
                    {
                        Code = erro.PropertyName,
                        Message = erro.ErrorMessage
                    });
                }

                return response;
            }

            return response;
        }
    }
}
